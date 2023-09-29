using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TwitterXScheduler.Controllers.Models
{
    public class PostTweetRequestDto
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;
    }
}