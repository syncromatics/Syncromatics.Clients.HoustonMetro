using System;
using System.Threading.Tasks;
using FluentAssertions;
using Polly;
using Xunit;

namespace Syncromatics.Clients.HoustonMetro.Api.Tests.Integration
{
    public class HoustonMetroClientTests
    {
        private readonly HoustonMetroClient _client;

        public HoustonMetroClientTests()
        {
            var apiKey = Environment.GetEnvironmentVariable("METRO_API_KEY");

            apiKey.Should().NotBeNullOrEmpty(
                "you must specify an environment variable 'METRO_API_KEY' to run these tests");

            _client = new HoustonMetroClient(
                new ClientSettings { ApiKey = apiKey });
        }

        [Theory]
        [InlineData("MeTrAuOfHaCo_79")]
        [InlineData("MeTrAuOfHaCo_244")]
        [InlineData("MeTrAuOfHaCo_661")]
        [InlineData("MeTrAuOfHaCo_681")]
        [InlineData("MeTrAuOfHaCo_9045")]
        [InlineData("MeTrAuOfHaCo_9953")]
        [InlineData("MeTrAuOfHaCo_10055")]
        public async Task ShouldGetArrivals(string stopId)
        {
            Response<Arrival> result = null;
            await RetryPolicy().ExecuteAsync(async () =>
            {
                result = await _client.GetArrivalsAsync(stopId);
            });

            result.Should().NotBeNull();
            result.ResultSet.Should().NotBeNull();
            result.ResultSet.Results.Should().NotBeNull();

            foreach (var arrival in result.ResultSet.Results) {
                arrival.RouteName.Should().NotBeNullOrEmpty();
                arrival.DestinationName.Should().NotBeNullOrEmpty();
            }
        }

        [Theory]
        [InlineData("MeTrAuOfHaCo_79")]
        [InlineData("MeTrAuOfHaCo_244")]
        [InlineData("MeTrAuOfHaCo_661")]
        [InlineData("MeTrAuOfHaCo_681")]
        [InlineData("MeTrAuOfHaCo_9045")]
        [InlineData("MeTrAuOfHaCo_9953")]
        [InlineData("MeTrAuOfHaCo_10055")]
        public async Task ShouldGetRoutes(string stopId)
        {
            Response<Route> result = null;
            await RetryPolicy().ExecuteAsync(async () =>
            {
                result = await _client.GetRoutesAsync(stopId);
            });

            result.Should().NotBeNull();
            result.ResultSet.Should().NotBeNull();
            result.ResultSet.Results.Should().NotBeNull();

            foreach (var route in result.ResultSet.Results)
            {
                route.AgencyAbbreviation.Should().NotBeNullOrEmpty();
                route.LongName.Should().NotBeNullOrEmpty();
                route.RouteId.Should().NotBeNullOrEmpty();
                route.RouteName.Should().NotBeNullOrEmpty();
                route.RouteType.Should().NotBeNullOrEmpty();
            }
        }

        private Policy RetryPolicy() =>
            Policy
                .Handle<RestEase.ApiException>()
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: (i) =>
                        TimeSpan.FromSeconds(5 + Math.Pow(2, i)),
                    onRetry: (ex, ts) =>
                        Console.WriteLine($"{ex.Message} Retrying after {ts.TotalSeconds}s"));
    }
}
