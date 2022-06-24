// TCDev.de 2022/04/05
// TCDev.APIGenerator.Generator.cs
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using TCDev.APIGenerator.Schema;


namespace TCDev.APIGenerator.Json;

public class JsonClassBuilder
{

   public static Type CreateClass(JsonClassDefinition definition)
   {
      try
      {
         var classCode = $@" // Auto-generated code
         using System;
         using Swashbuckle.AspNetCore.Annotations;
         using System.ComponentModel.DataAnnotations;
         using System.ComponentModel.DataAnnotations.Schema;
         using System.Text.Json.Serialization;
         using TCDev.APIGenerator.Attributes;
         using TCDev.APIGenerator.Interfaces;

         namespace TCDev.APIGenerator
         {{
             [Api(""{ definition.RouteTemplate }"")]
             public class { definition.Name } : IObjectBase<{definition.IdType}>
            
            // Add Properties
            {{
               public {definition.IdType} Id {{ get; set;}}
          ";

         // Add all fields
         var result1 = definition.Fields.Aggregate(string.Empty, (current, field) => 
            current + $@" public {field.Type} {field.Name}{(field.Nullable ? "?" : "")} {{ get; set;}}");
         
         // Complete class
         classCode += result1;
         classCode += $@"}} }}";

         MetadataReference[] assemblies = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(a => !string.IsNullOrEmpty(a.Location))
            .Select(a => MetadataReference.CreateFromFile(a.Location))
            .ToArray();
         classCode = FormatUsingRoslyn(classCode);

         var syntaxTree = CSharpSyntaxTree.ParseText(classCode);

         var compilation = CSharpCompilation
            .Create("TCDev.APIGenerator")
            .AddSyntaxTrees(syntaxTree)
            .AddReferences(assemblies)
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

         using var ms = new MemoryStream();
         var result = compilation.Emit(ms);

         if (result.Success)
         {
            ms.Seek(0, SeekOrigin.Begin);
            var assembly = Assembly.Load(ms.ToArray());

            var newTypeFullName = $"TCDev.APIGenerator.{definition.Name}";

            var type = assembly.GetType(newTypeFullName);
            return type;
         }

         var failures = result.Diagnostics.Where(diagnostic =>
            diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);

         foreach (var diagnostic in failures) Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());

         return null;
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
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
