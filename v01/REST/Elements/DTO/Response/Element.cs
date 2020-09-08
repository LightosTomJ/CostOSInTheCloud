using Newtonsoft.Json;
using REST.Elements.DTO.Response.Elements;
using System.Collections.Generic;

namespace REST.Elements.DTO.Response
{
    public class Element
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "globalId")]
        public string GlobalId { get; set; }

        [JsonProperty(PropertyName = "model")]
        public int ModelId { get; set; }

        [JsonProperty(PropertyName = "spatial")]
        public bool Spatial { get; set; }

        [JsonProperty(PropertyName = "hasGeometry")]
        public bool HasGeometry { get; set; }

        [JsonProperty(PropertyName = "layer")]
        public string Layer { get; set; }

        [JsonProperty(PropertyName = "tagId")]
        public string TagId { get; set; }

        [JsonProperty(PropertyName = "containedBy")]
        public int ContainedBy { get; set; }

        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string Material { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "materials")]
        public List<Material> Materials { get; set; }

        [JsonProperty(PropertyName = "contains")]
        public List<int> Contains { get; set; } = new List<int>();

        [JsonProperty(PropertyName = "children")]
        public List<int> Children { get; set; } = new List<int>();

        public List<Hierarchy> Hierarchy { get; set; } = new List<Hierarchy>();

        public List<Property> Properties { get; set; } = new List<Property>();

        public List<Quantity> Quantities { get; set; } = new List<Quantity>();

        public Element()
        { }
    }
}
