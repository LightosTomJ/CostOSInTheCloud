using Newtonsoft.Json;
using REST.Elements.DTO.Response;
using System.Collections.Generic;

namespace REST.Models.DTO.Response
{
    public class Model
    {
        [JsonProperty(PropertyName="applicationName")]
        public string ApplicationName { get; set; }

        [JsonProperty(PropertyName = "defaultRevision")]
        public bool DefaultRevision { get; set; }

        [JsonProperty(PropertyName = "failCause")]
        public string FailCause { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "project")]
        public int Project { get; set; }

        [JsonProperty(PropertyName = "revision")]
        public string Revision { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        public List<Element> Elements { get; set; } = new List<Element>();

        public Element BuildingType { get; set; } = new Element();

        public List<Element> Levels { get; set; } = new List<Element>();

        public Model()
        { }
    }
}
