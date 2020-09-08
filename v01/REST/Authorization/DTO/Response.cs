using System.Text.Json.Serialization;

namespace REST.Authorization.DTO
{
    public class Response
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
