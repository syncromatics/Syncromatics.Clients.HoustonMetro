using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestEase;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class HoustonMetroClient : IHoustonMetroClient
    {
        private readonly IHoustonMetroClient _client;

        public HoustonMetroClient() : this(new ClientSettings())
        {

        }

        public HoustonMetroClient(ClientSettings clientSettings)
        {
            var handler = new HttpClientHandler { MaxConnectionsPerServer = clientSettings.MaxConnections };
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(clientSettings.ServerRootUrl)
            };

            _client = new RestClient(httpClient).For<IHoustonMetroClient>();
        }

        public Task<Stop> GetArrivalsAsync([Path] int stopId)
        {
            return _client.GetArrivalsAsync(stopId);
        }
    }
}
