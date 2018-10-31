using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestEase;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public interface IHoustonMetroClient
    {
        Task<Stop> GetArrivalsAsync(int stopId);
    }
}
