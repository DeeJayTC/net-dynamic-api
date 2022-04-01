// TCDev.de 2022/03/31
// TCDev.APIGenerator.DBScaffolder.cs
// https://www.github.com/deejaytc/dotnet-utils

//using System.Collections.Generic;
//using System.Data.Common;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using Microsoft.EntityFrameworkCore.Scaffolding;
//using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
//using Microsoft.EntityFrameworkCore.SqlServer.Diagnostics.Internal;
//using Microsoft.EntityFrameworkCore.SqlServer.Scaffolding.Internal;
//using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
//using Microsoft.EntityFrameworkCore.Storage;
//using Microsoft.Extensions.DependencyInjection;

//namespace TCDev.APIGenerator.Data.DBReader;

//public class DbScaffolder
//{
//   [SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "We need it")]
//   public static IReverseEngineerScaffolder CreateMssqlScaffolder()
//   {
//      return new ServiceCollection()
//         .AddEntityFrameworkSqlServer()
//         .AddLogging()
//         .AddEntityFrameworkDesignTimeServices()
//         .AddSingleton<LoggingDefinitions, SqlServerLoggingDefinitions>()
//         .AddSingleton<IRelationalTypeMappingSource, SqlServerTypeMappingSource>()
//         .AddSingleton<IAnnotationCodeGenerator, AnnotationCodeGenerator>()
//         .AddSingleton<IDatabaseModelFactory, SqlServerDatabaseModelFactory>()
//         .AddSingleton<IProviderConfigurationCodeGenerator, SqlServerCodeGenerator>()
//         .AddSingleton<IScaffoldingModelFactory, RelationalScaffoldingModelFactory>()
//         .AddSingleton<ProviderCodeGeneratorDependencies>()
//         .AddSingleton<AnnotationCodeGeneratorDependencies>()
//         .BuildServiceProvider()
//         .GetRequiredService<IReverseEngineerScaffolder>();
//   }


//   public static List<MetadataReference> CompilationReferences(bool enableLazyLoading)
//   {
//      var refs = new List<MetadataReference>();
//      var referencedAssemblies = Assembly.GetExecutingAssembly()
//         .GetReferencedAssemblies();
//      refs.AddRange(referencedAssemblies.Select(a => MetadataReference.CreateFromFile(Assembly.Load(a)
//         .Location)));

//      refs.Add(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
//      refs.Add(MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.0.0.0")
//         .Location));
//      refs.Add(MetadataReference.CreateFromFile(typeof(DbConnection).Assembly.Location));
//      refs.Add(MetadataReference.CreateFromFile(typeof(Expression).Assembly.Location));

//      //if (enableLazyLoading)
//      //{
//      //   refs.Add(MetadataReference.CreateFromFile(typeof(ProxiesExtensions).Assembly.Location));
//      //}

//      return refs;
//   }

//   private static CSharpCompilation GenerateCode(List<string> sourceFiles, bool enableLazyLoading)
//   {
//      var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp8);

//      var parsedSyntaxTrees = sourceFiles.Select(f => SyntaxFactory.ParseSyntaxTree(f, options));

//      return CSharpCompilation.Create("DataContext.dll",
//         parsedSyntaxTrees,
//         CompilationReferences(enableLazyLoading),
//         new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
//            optimizationLevel: OptimizationLevel.Release,
//            assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
//   }
//}


//   public static void GenerateClasses()
//   {
//      var connectionString = @"";

//      var scaffolder = CreateMssqlScaffolder();

//      var dbOpts = new DatabaseModelFactoryOptions();
//      var modelOpts = new ModelReverseEngineerOptions();
//      var codeGenOpts = new ModelCodeGenerationOptions
//      {
//         RootNamespace = "TypedDataContext",
//         ContextName = "DataContext",
//         ContextNamespace = "TypedDataContext.Context",
//         ModelNamespace = "TypedDataContext.Models",
//         SuppressConnectionStringWarning = true
//      };

//      var scaffoldedModelSources = scaffolder.ScaffoldModel(connectionString, dbOpts, modelOpts, codeGenOpts);
//      var sourceFiles = new List<string>
//      {
//         scaffoldedModelSources.ContextFile.Code
//      };
//      sourceFiles.AddRange(scaffoldedModelSources.AdditionalFiles.Select(f => f.Code));
//   }
//}


