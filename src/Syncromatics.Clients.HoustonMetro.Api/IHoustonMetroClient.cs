using System.Threading.Tasks;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public interface IHoustonMetroClient
    {
        Task<Response<Arrival>> GetArrivalsAsync(string stopId);
        Task<Response<Route>> GetRoutesAsync(string stopId);
    }
}
