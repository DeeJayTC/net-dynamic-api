// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

//using GraphQL;
//using GraphQL.EntityFramework;
//using GraphQL.Types;
//using TCDev.ApiGenerator.Data;
//using TCDev.ApiGenerator.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Graph;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TCDev.ApiGenerator.GraphQL
//{
//    public class GenericGraphQLEFQuery: QueryGraphType<GenericDbContext> 
//    {

//        public GenericGraphQLEFQuery(IEfGraphQLService<GenericDbContext> service) : base(service)
//        {

//            FieldAsync<ListGraphType<AutoRegisteringObjectGraphType<Person>>>("appearsIn", "Which movie they appear in.",
//                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
//                resolve: async context =>
//                {
//                    return new Person() { CompanyName = "huhu" };
//                });


//            //FieldAsync<GenericObjectGraphType<T, TEntityId>>("find",
//            //    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
//            //    resolve: async context =>
//            //    {
//            //        return await repository.GetAsync(context.GetArgument<TEntityId>("id"));
//            //    });

//            //FieldAsync<ListGraphType<GenericObjectGraphType<T, TEntityId>>>("query",
//            //    arguments: new QueryArguments {
//            //    new QueryArgument<IntGraphType> { Name = "skip", DefaultValue = 0 },
//            //    new QueryArgument<IntGraphType> { Name = "take", DefaultValue = 10 },
//            //    },
//            //    resolve: async context =>
//            //    {
//            //        var skip = context.GetArgument<int>("skip");
//            //        var take = context.GetArgument<int>("take");
//            //        return await repository.Get().Skip(skip).Take(take).ToListAsync();
//            //    });


//        }
//    }


//    public class GenericGraphQLQuery<T, TEntityId> : ObjectGraphType where T : class, IObjectBase<TEntityId>
//    {
//        public GenericGraphQLQuery(IGenericRespository<T, TEntityId> repository)
//        {
//            FieldAsync<GenericObjectGraphType<T, TEntityId>>("find",
//                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
//                resolve: async context =>
//                {
//                    return await repository.GetAsync(context.GetArgument<TEntityId>("id"));
//                });

//            FieldAsync<ListGraphType<GenericObjectGraphType<T, TEntityId>>>("query",
//                arguments: new QueryArguments {
//                new QueryArgument<IntGraphType> { Name = "skip", DefaultValue = 0 },
//                new QueryArgument<IntGraphType> { Name = "take", DefaultValue = 10 },
//                },
//                resolve: async context =>
//                {
//                    var skip = context.GetArgument<int>("skip");
//                    var take = context.GetArgument<int>("take");
//                    return await repository.Get().Skip(skip).Take(take).ToListAsync();
//                });
//        }
//    }
//}

