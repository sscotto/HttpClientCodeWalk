using System.Text.Json.Serialization;

namespace HttpClientCodeWalk.Models
{
    public class CatFactResponse
    {
        [JsonPropertyName("fact")]
        public string Fact { get; set; }
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
