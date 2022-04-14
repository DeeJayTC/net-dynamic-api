// TCDev.de 2022/04/05
// TCDev.APIGenerator.Generator.cs
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using TCDev.ApiGenerator.Interfaces;
using TCDev.APIGenerator.Schema;

namespace TCDev.ApiGenerator.Json;


public class JsonClassBuilder
{
    public static List<Type> CreateTypes(List<JsonClassDefinition> definitions)
    {
        try
        {
            var trees = definitions.Select(def => CreateTree(def))
                .ToList();

            MetadataReference[] assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(p => !p.IsDynamic)
                .Where(a => !string.IsNullOrEmpty(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .ToArray();

            var compilation = CSharpCompilation
                .Create("TCDev.ApiGenerator")
                .AddSyntaxTrees(trees)
                .AddReferences(assemblies)
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using var ms = new MemoryStream();
            var result = compilation.Emit(ms);

            if (result.Success)
            {
                ms.Seek(0, SeekOrigin.Begin);
                var assembly = Assembly.Load(ms.ToArray());
                return assembly.ExportedTypes.ToList();
            }

            var failures = result.Diagnostics.Where(diagnostic =>
                diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);


            foreach (var diagnostic in failures)
            {
                Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
            }

            throw new Exception("Failed to parse JSON Definitions, could not compile assemblies",
                new Exception(string.Join(",", failures.Select(p => p.GetMessage()))));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static SyntaxTree CreateTree(JsonClassDefinition definition)
    {
        var classCode = $@" // Auto-generated code
         using System;
         using Swashbuckle.AspNetCore.Annotations;
         using System.ComponentModel.DataAnnotations;
         using System.ComponentModel.DataAnnotations.Schema;
         using System.Text.Json.Serialization;
         using TCDev.ApiGenerator.Attributes;
         using TCDev.ApiGenerator.Interfaces;

         namespace TCDev.ApiGenerator
         {{
             [Api(""{definition.RouteTemplate}"" ";

        if (definition.Authorize)
        {
            classCode += $@",authorize: true";
            if(definition.ScopesRead != string.Empty) classCode += $@",requiredReadScopes: new string[] {{ { definition.ScopesRead } }}";
            if (definition.ScopesWrite != string.Empty) classCode += $@",requiredWriteScopes: new string[] {{ { definition.ScopesWrite } }}";
        }
               
        classCode += $@")]          

           public class {definition.Name} : IObjectBase<{definition.IdType}>
            
            // Add Properties
            {{
               public {definition.IdType} Id {{ get; set;}}
          ";

        // Add all fields
        var result1 = definition.Fields.Aggregate(string.Empty, (current, field) =>
            current + $@" public {field.Type} {field.Name}{(field.Nullable ? "?" : "")} {{ get; set;}}");

        // Complete class
        classCode += result1;
        classCode += @"} }";


        classCode = FormatUsingRoslyn(classCode);

        return CSharpSyntaxTree.ParseText(classCode);
    }

    public static string FormatUsingRoslyn(string csCode)
    {
      var tree = CSharpSyntaxTree.ParseText(csCode);
      var root = tree.GetRoot()
         .NormalizeWhitespace();
      var result = root.ToFullString();
      return result;
   }

}
