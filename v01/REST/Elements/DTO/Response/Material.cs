using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Elements.DTO.Response.Elements
{
    public class Material
    {
        [JsonProperty(PropertyName = "thickness")]
        public double Thickness { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public Material()
        { }
    }
}
