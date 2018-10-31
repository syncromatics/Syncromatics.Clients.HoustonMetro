using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestEase;

namespace Syncromatics.Clients.HoustonMetro.Api
{
    public interface IHoustonMetroClient
    {
        [Get("data/Stops('MeTrAuOfHaCo_{stopId}')/Arrivals?subscription-key=34111af5524b49eea8030a63d8285854&$format=json")]
        Task<Stop> GetArrivalsAsync([Path]int stopId);
    }
}
