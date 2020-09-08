using Newtonsoft.Json;

namespace REST.Elements.DTO.Response.Elements
{
    public class Quantity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "nameId")]
        public string NameId { get; set; }

        [JsonProperty(PropertyName = "groupName")]
        public string GroupName { get; set; }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }

        [JsonProperty(PropertyName = "quantityType")]
        public string QuantityType { get; set; }

        public Quantity()
        { }

        public enum Type
        {
            SPOT = 1,
            LENGTH = 2,
            AREA = 3,
            VOLUME = 4
        }
    }
}
