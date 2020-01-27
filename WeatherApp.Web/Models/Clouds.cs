using Newtonsoft.Json;

namespace WeatherApp.Web.Models
{
    public class Clouds
    {
        
        [JsonProperty("all")]
        public long All { get; set; }
    }
}