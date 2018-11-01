using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class Stop
    {
        [JsonProperty("d")]
        public ResultSet ResultSet { get; set; }
    }
}
