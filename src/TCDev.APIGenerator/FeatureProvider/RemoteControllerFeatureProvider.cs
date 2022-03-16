// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using TCDev.ApiGenerator;

namespace TCDev.Controllers
{
   public class DatabaseControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
   {
      public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
      {
         var remoteCode = new HttpClient().GetStringAsync("").GetAwaiter().GetResult();
         var compilation = CSharpCompilation.Create("DynamicAssembly", new[] {CSharpSyntaxTree.ParseText(remoteCode)},
            new[]
            {
               MetadataReference.CreateFromFile(typeof(object).Assembly.Location), MetadataReference.CreateFromFile(typeof(DatabaseControllerFeatureProvider).Assembly.Location)
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

            foreach (var candidate in candidates)
               feature.Controllers.Add(typeof(GenericController<,>).MakeGenericType(candidate, typeof(string))
                  .GetTypeInfo());
         }
      }
   }
}