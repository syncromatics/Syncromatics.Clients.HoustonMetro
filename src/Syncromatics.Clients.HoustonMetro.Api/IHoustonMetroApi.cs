using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RestEase;

//required for RestEase to use internal interfaces
[assembly: InternalsVisibleTo(RestClient.FactoryAssemblyName)]

namespace Syncromatics.Clients.HoustonMetro.Api
{
    internal interface IHoustonMetroApi
    {
        [Get("data/Stops('{stopId}')/Arrivals?$format=json")]
        Task<Response<Arrival>> GetArrivalsAsync(
            [Header("Ocp-Apim-Subscription-Key")]string apiKey,
            [Path]string stopId);

        [Get("data/Stops('{stopId}')/Routes?$format=json")]
        Task<Response<Route>> GetRoutesAsync(
            [Header("Ocp-Apim-Subscription-Key")]string apiKey,
            [Path]string stopId);
    }
}
