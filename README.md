# CluedIn.Crawling.ExampleRest

[![Build Status](https://dev.azure.com/CluedIn-io/CluedIn%20Crawlers/_apis/build/status/CluedIn-io.CluedIn.Crawling.ExampleRest?branchName=master)](https://dev.azure.com/CluedIn-io/CluedIn%20Crawlers/_build/latest?definitionId=TODO&branchName=master)
------

## Overview

This is an example of a crawler for REST APIs.
Its purpose is to show how a crawler might be setup to fetch data from a REST API for use in CluedIn.

## Helper configuration

When registering the provider, the helper configuration has the following format:
```
{
  "helperConfiguration": {
    "Url": "www.some.url.com",
    "Token": "Your bearer token",
    "Endpoints": [
      "some/endpoint",
      "another/endpoint",
      ...
      "last/endpoint"
    ],
    "NumRetry": 4,
    "TimeBetweenRequests": 10000
  }
}
```

The `NumRetry` property specifies the number of times the crawler will try to fetch data from an endpoint. 
`NumRetry` defaults to 1 if it is not set in the helper configuration.

The `TimeBetweenRequests` property specifies how much time in milliseconds the crawler will wait between every request to the API.
This might be necessary if the API only allows for a certain amount of requests in a given time interval. 
`TimeBetweenRequests` defaults to 0 if it is not set in the helper configuration.

## Running Tests

<!-- A mocked environment is required to run `integration` and `acceptance` tests. The mocked environment can be built and run using the following [Docker](https://www.docker.com/) command:

```Shell
docker-compose up --build -d
``` -->

To run all `unit` and `integration` tests

```Shell
dotnet test --filter Unit
```

To run only `integration` tests

```Shell
dotnet test --filter Integration
```

To run [Pester](https://github.com/pester/Pester) `acceptance` tests

```PowerShell
invoke-pester test\acceptance
```

<!-- 
To review the [WireMock](http://wiremock.org/) HTTP proxy logs

```Shell
docker-compose logs wiremock
``` -->

## References

* [ExampleRest](TODO)

### Tooling

* [Docker](https://www.docker.com/)
* [Pester](https://github.com/pester/Pester)
<!-- * [WireMock](http://wiremock.org/) -->
