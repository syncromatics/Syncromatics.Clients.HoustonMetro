using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class ResultSet
    {
        [JsonProperty("results")]
        public List<Arrival> Arrivals { get; set; }
    }
}
