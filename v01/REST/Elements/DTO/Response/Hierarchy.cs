using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Elements.DTO.Response.Elements
{
    public class Hierarchy
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "contains")]
        public List<Hierarchy> Contains { get; set; } = new List<Hierarchy>();

        [JsonProperty(PropertyName = "children")]
        public List<Hierarchy> Children { get; set; } = new List<Hierarchy>();

        public Hierarchy()
        { }
    }
}
