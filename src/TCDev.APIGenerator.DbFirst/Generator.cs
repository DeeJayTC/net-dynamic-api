// TCDev.de 2022/04/05
// TCDev.APIGenerator.Generator.cs
// https://www.github.com/deejaytc/dotnet-utils

using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace TCDev.ApiGenerator.Json;

public class JsonClassBuilder
{
   public const string TestClass = $@" // Auto-generated code
         using System;
         using Swashbuckle.AspNetCore.Annotations;
         using System;
         using System.ComponentModel.DataAnnotations;
         using System.ComponentModel.DataAnnotations.Schema;
         using System.Text.Json.Serialization;
         using TCDev.ApiGenerator.Attributes;
         using TCDev.ApiGenerator.Interfaces;

         namespace TCDev.ApiGenerator
         {{
             [Api('/carsgen')]
             public class CarsGenerated : IObjectBase<int>
             {{
                 public int Id {{ get; set;}}
                 public string Name {{ get; set;}}
             }}
         }}
         ";

   public void LoadJsonClass()
   {

      var compilation = CSharpCompilation.Create("DynamicAssembly", new[] { CSharpSyntaxTree.ParseText(TestClass) },
         new[]
         {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
         },
         new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

      using (var ms = new MemoryStream())
      {
         var emitResult = compilation.Emit(ms);

         if (!emitResult.Success)
         {
            // handle, log errors etc
            Debug.WriteLine("Compilation failed!");
            return;
         }

         ms.Seek(0, SeekOrigin.Begin);
         var assembly = Assembly.Load(ms.ToArray());
         var candidates = assembly.GetExportedTypes();

      }
   }
}
