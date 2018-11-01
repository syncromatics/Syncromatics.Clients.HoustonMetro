using Newtonsoft.Json;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class Response<TResult> where TResult : class
    {
        [JsonProperty("d")]
        public ResultSet<TResult> ResultSet { get; set; }
    }
}
