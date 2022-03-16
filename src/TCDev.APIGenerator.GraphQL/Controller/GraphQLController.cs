// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

//using GraphQL;
//using GraphQL.Types;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TCDev.ApiGenerator.GraphQL.Controller
//{
//    [Route("graphql")]
//    public class GraphQLController : Controller
//    {
//        private IDocumentExecuter _documentExecuter { get; set; }
//        private ISchema _schema { get; set; }
//        private readonly ILogger _logger;

//        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema, ILogger<GraphQLController> logger)
//        {
//            _documentExecuter = documentExecuter;
//            _schema = schema;
//            _logger = logger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
//        {
//            if (query == null) { throw new ArgumentNullException(nameof(query)); }

//            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query };

//            try
//            {
//                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

//                if (result.Errors?.Count > 0)
//                {
//                    _logger.LogError("GraphQL errors: {0}", result.Errors);
//                    return BadRequest(result);
//                }

//                _logger.LogDebug("GraphQL execution result: {result}", JsonConvert.SerializeObject(result.Data));
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError("Document exexuter exception", ex);
//                return BadRequest(ex);
//            }
//        }
//    }
//}

