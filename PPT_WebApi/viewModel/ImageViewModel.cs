
using Newtonsoft.Json;

namespace PPTWebApiService.ViewModel
{
    public class ImageViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("url")]
        public required string Url { get; set; }
    }
}

