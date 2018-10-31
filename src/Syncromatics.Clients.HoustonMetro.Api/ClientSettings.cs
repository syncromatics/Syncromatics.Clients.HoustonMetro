using System;
using System.Collections.Generic;
using System.Text;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class ClientSettings
    {
        public int MaxConnections { get; set; } = 2;
        public string ServerRootUrl { get; set; } = "https://api.ridemetro.org";
    }
}
