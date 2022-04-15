// TCDev.de 2022/04/07
// TCDev.APIGenerator.Schema.JsonClassDefinition.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

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
        public bool EnableCaching { get; set; }

        [JsonProperty("idType")]
        public string IdType { get; set; } = "int";

        public bool Authorize { get; set; } = false;

        [JsonProperty("ScopesRead")]
        public List<string> ScopesReadList { get; set; } = new List<string>();

        [JsonProperty("ScopesWrite")]
        public List<string> ScopesWriteList { get; set; } = new List<string>();


        [JsonIgnore]
        public string ScopesRead {
            get
            {
                return ScopesReadList.Any() ? string.Join(",", ScopesReadList.Select(p => $"\"{p}\"").ToList()) : string.Empty;
            }
        }
        [JsonIgnore]
        public string ScopesWrite
        {
            get
            {
                return ScopesWriteList.Any() ? string.Join(",", ScopesWriteList.Select(p => $"\"{p}\"").ToList()) : string.Empty;
            }
        }

        public List<Field> Fields { get; set; }
    }


    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public string MaxLength { get; set; }
    }
}
