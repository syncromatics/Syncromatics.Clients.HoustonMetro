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
        [InlineData(79)]
        [InlineData(244)]
        [InlineData(661)]
        [InlineData(681)]
        [InlineData(9045)]
        [InlineData(9953)]
        [InlineData(10055)]
        public async Task ShouldGetArrivals(int stopId)
        {
            Stop result = null;
            await RetryPolicy().ExecuteAsync(async () =>
            {
                result = await _client.GetArrivalsAsync(stopId);
            });

            result.Should().NotBeNull();
            result.ResultSet.Should().NotBeNull();
            result.ResultSet.Arrivals.Should().NotBeNull();

            foreach (var arrival in result.ResultSet.Arrivals) {
                arrival.RouteName.Should().NotBeNullOrEmpty();
                arrival.DestinationName.Should().NotBeNullOrEmpty();
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
