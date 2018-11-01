using System.Threading.Tasks;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public interface IHoustonMetroClient
    {
        Task<Response<Arrival>> GetArrivalsAsync(int stopId);
        Task<Response<Route>> GetRoutesAsync(int stopId);
    }
}
