# Houston Metro Transit Arrivals API client

A .NET library to interact with the Houston Metro arrivals api

[![Travis](https://img.shields.io/travis/syncromatics/Syncromatics.Clients.HoustonMetro.svg)](https://travis-ci.org/syncromatics/Syncromatics.Clients.HoustonMetro)
[![NuGet](https://img.shields.io/nuget/v/Syncromatics.Clients.HoustonMetro.Api.svg)](https://www.nuget.org/packages/Syncromatics.Clients.HoustonMetro.Api/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Syncromatics.Clients.HoustonMetro.Api.svg)](https://www.nuget.org/packages/Syncromatics.Clients.HoustonMetro.Api/)

## Quickstart

```bash
dotnet add package Syncromatics.Clients.HoustonMetro.Api
```

Then use it to do a thing:

```csharp
ClientSettings settings = new ClientSettings
{
    // Sign up at https://developer-portal.ridemetro.org/products to get an API key
    ApiKey = ""
};
HoustonMetroClient client = new HoustonMetroClient(settings);
Stop stop = await client.GetArrivalsAsync(661);
foreach (Arrival arrival in stop.ResultSet.Arrivals) {}
```

## Building
```
dotnet build
```

## Testing
```
dotnet test tests/Syncromatics.Clients.HoustonMetro.Api.Tests
```

## Code of Conduct

We are committed to fostering an open and welcoming environment. Please read our [code of conduct](CODE_OF_CONDUCT.md) before participating in or contributing to this project.

## Contributing

We welcome contributions and collaboration on this project. Please read our [contributor's guide](CONTRIBUTING.md) to understand how best to work with us.

## License and Authors

[![GMV Syncromatics Engineering logo](https://secure.gravatar.com/avatar/645145afc5c0bc24ba24c3d86228ad39?size=16) GMV Syncromatics Engineering](https://github.com/syncromatics)

[![license](https://img.shields.io/github/license/syncromatics/Syncromatics.Clients.HoustonMetro.svg)](https://github.com/syncromatics/Syncromatics.Clients.HoustonMetro/blob/master/LICENSE)
[![GitHub contributors](https://img.shields.io/github/contributors/syncromatics/Syncromatics.Clients.HoustonMetro.svg)](https://github.com/syncromatics/Syncromatics.Clients.HoustonMetro/graphs/contributors)

This software is made available by GMV Syncromatics Engineering under the MIT license.