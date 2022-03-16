// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

//using HotChocolate.Execution.Configuration;
//using HotChocolate.Types;
//using HotChocolate.Types.Descriptors;
//using HotChocolate.Types.Descriptors.Definitions;
//using TCDev.ApiGenerator.Attributes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace TCDev.ApiGenerator.GraphQL.Types
//{
//    public class CustomTypeModule : ITypeModule
//    {
//        public event EventHandler<EventArgs> TypesChanged;

//        public ValueTask<IReadOnlyCollection<ITypeSystemMember>> CreateTypesAsync(IDescriptorContext context, CancellationToken cancellationToken)
//        {
//            var types = new List<ITypeSystemMember>();
//            var loadedAssembly = Assembly.Load(Assembly.GetEntryAssembly().FullName);
//            var customClasses = loadedAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GraphQLAttribute>().Any());

//            foreach (var type in customClasses)
//            {
//                var typeDefinition = new ObjectTypeDefinition(type.FullName!);

//                foreach (var field in type.GetProperties())
//                {
//                    typeDefinition.Fields.Add(
//                        new ObjectFieldDefinition(
//                            field.Name,
//                            type: TypeReference.Parse(field.GetType().Name),
//                            pureResolver: ctx => 

//                            "foo"
//                            ));
//                }

//                types.Add(ObjectType.CreateUnsafe(typeDefinition));
//            }


//            return types;
//        }
//    }


//    //public class CustomTypeModule : ITypeModule
//    //{
//    //    private readonly string _file;
//    //    private readonly FileSystemWatcher _watcher;

//    //    public event EventHandler<EventArgs>? TypesChanged;

//    //    public CustomTypeModule(string file)
//    //    {
//    //        _file = file;
//    //        _watcher = new FileSystemWatcher(Path.GetDirectoryName(_file)!);

//    //        _watcher.NotifyFilter = NotifyFilters.Attributes
//    //            | NotifyFilters.CreationTime
//    //            | NotifyFilters.FileName
//    //            | NotifyFilters.LastAccess
//    //            | NotifyFilters.LastWrite
//    //            | NotifyFilters.Size;

//    //        _watcher.EnableRaisingEvents = true;
//    //        _watcher.Changed += (sender, args) => TypesChanged?.Invoke(this, EventArgs.Empty);
//    //    }

//    //    public async ValueTask<IReadOnlyCollection<ITypeSystemMember>> CreateTypesAsync(
//    //        IDescriptorContext context,
//    //        CancellationToken cancellationToken)
//    //    {
//    //        var types = new List<ITypeSystemMember>();

//    //        await using var file = File.OpenRead(_file);
//    //        using var json = await JsonDocument.ParseAsync(file, cancellationToken: cancellationToken);

//    //        foreach (var type in json.RootElement.EnumerateArray())
//    //        {
//    //            var typeDefinition = new ObjectTypeDefinition(type.GetProperty("name").GetString()!);

//    //            foreach (var field in type.GetProperty("fields").EnumerateArray())
//    //            {
//    //                typeDefinition.Fields.Add(
//    //                    new ObjectFieldDefinition(
//    //                        field.GetString()!,
//    //                        type: TypeReference.Parse("String!"),
//    //                        pureResolver: ctx => "foo"));
//    //            }

//    //            types.Add(
//    //                type.GetProperty("extension").GetBoolean()
//    //                    ? ObjectTypeExtension.CreateUnsafe(typeDefinition)
//    //                    : ObjectType.CreateUnsafe(typeDefinition));
//    //        }

//    //        return types;
//    //    }
//    //}
//}

