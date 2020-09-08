using Newtonsoft.Json;
using System.Collections.Generic;

namespace REST.Projects.DTO.Response
{
    public class ProjectSummary
    {
        [JsonProperty("content")]
        public List<Project> Projects { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }
        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        public ProjectSummary()
        { ; }
    }
}
