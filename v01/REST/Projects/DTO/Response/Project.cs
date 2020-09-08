using Newtonsoft.Json;
using REST.Models.DTO.Response;
using System.Collections.Generic;

namespace REST.Projects.DTO.Response
{
    public class Project
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "models")]
        public List<int> ModelIds { get; set; } = new List<int>();

        public List<Model> Models { get; set; } = new List<Model>();

        [JsonProperty(PropertyName = "children")]
        public List<int> Children { get; set; } = new List<int>();

        [JsonProperty(PropertyName = "globalId")]
        public string GlobalId { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "parent")]
        public int? Parent { get; set; }

        public Project()
        { ; }
    }
}
