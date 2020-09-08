using Newtonsoft.Json;

namespace REST.Elements.DTO.Response.Elements
{
    public class Property
    {
        [JsonProperty(PropertyName = "propertyId")]
        public int PropertyId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "groupName")]
        public string GroupName { get; set; }

        [JsonProperty(PropertyName = "numberValue")]
        public double NumberValue { get; set; }

        [JsonProperty(PropertyName = "textValue")]
        public string TextValue { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "quantityType")]
        public int QuantityType { get; set; }

        public Property()
        { ; }

    }
}
