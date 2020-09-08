using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace REST.Elements.DTO.Response
{
    public class ElementsSummary
    {
        [JsonProperty(PropertyName = "content")]
        public List<Element> Elements { get; set; } = new List<Element>();

        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; set; }

        public ElementsSummary()
        { }
    }
}
