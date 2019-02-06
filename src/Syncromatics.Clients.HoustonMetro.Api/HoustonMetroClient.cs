using System;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public class HoustonMetroClient : IHoustonMetroClient
    {
        private readonly IHoustonMetroApi _client;
        private readonly ClientSettings _settings;

        public HoustonMetroClient(ClientSettings clientSettings)
        {
            _settings = clientSettings;
            var handler = new HttpClientHandler { MaxConnectionsPerServer = _settings.MaxConnections };
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(_settings.ServerRootUrl)
            };

            _client = new RestClient(httpClient).For<IHoustonMetroApi>();
        }

        public Task<Response<Arrival>> GetArrivalsAsync(string stopId) =>
            _client.GetArrivalsAsync(_settings.ApiKey, stopId);

        public Task<Response<Route>> GetRoutesAsync(string stopId) =>
            _client.GetRoutesAsync(_settings.ApiKey, stopId);
    }
}
