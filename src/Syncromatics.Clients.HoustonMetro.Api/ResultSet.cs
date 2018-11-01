using System.Collections.Generic;
using Newtonsoft.Json;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class ResultSet<TResult> where TResult : class
    {
        [JsonProperty("results")]
        public List<TResult> Results { get; set; }
    }
}
