using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace REST.Projects.DTO
{
    public class Request
    {
        [JsonPropertyName("dir")]
        public string Dir { get; set; } = "ASC";

        [JsonPropertyName("fields")]
        public string Fields { get; set; } = "all";

        [JsonPropertyName("page")]
        public int Page { get; set; } = 0;

        [JsonPropertyName("search")]
        public string Search { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; } = 100;

        [JsonPropertyName("sort")]
        public string Sort { get; set; }

        public Request()
        { ; }
    }
}
