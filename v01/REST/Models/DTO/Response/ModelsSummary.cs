using Newtonsoft.Json;
using System.Collections.Generic;

namespace REST.Models.DTO.Response
{
    public class ModelsSummary
    {
        [JsonProperty(PropertyName = "content")]
        public List<Model> Models { get; set; } = new List<Model>();
        
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; set; }

        public ModelsSummary()
        { }
    }
}
