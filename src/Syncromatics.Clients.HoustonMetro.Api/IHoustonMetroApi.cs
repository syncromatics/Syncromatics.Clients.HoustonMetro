using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestEase;

//required for RestEase to use internal interfaces
[assembly: InternalsVisibleTo(RestClient.FactoryAssemblyName)]

namespace Syncromatics.Clients.HoustonMetro.Api
{
    internal interface IHoustonMetroApi
    {
        [Get("data/Stops('MeTrAuOfHaCo_{stopId}')/Arrivals?$format=json")]
        Task<Stop> GetArrivalsAsync(
            [Header("Ocp-Apim-Subscription-Key")]string apiKey,
            [Path]int stopId);
    }
}
