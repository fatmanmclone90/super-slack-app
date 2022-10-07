using System.Text.Json.Serialization;

namespace Slack.App
{
    public class ChallengeRequest
    {
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }
    }
}
