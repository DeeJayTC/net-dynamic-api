using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema
{
   [Flags]
   public enum Events
   {
      POST,
      PUT,
      DELETE,
      ALL = POST | PUT | DELETE
   }


   public class JsonClassDefinition
   {
      public string Name { get; set; }

      [JsonProperty("route")]
      public string RouteTemplate { get; set; } = "/";

      [JsonProperty("caching")]
      public bool EnableCaching { get; set; } = false;

      [JsonProperty("idType")]
      public string IdType { get; set; } = "int";

      public bool Authorize { get; set; } = false;
        
      public List<Field> Fields { get; set; }
   }


   public class Field
   {
      public string Name { get; set; }
      public string Type { get; set; }
      public bool Nullable { get; set; }
   }
}
