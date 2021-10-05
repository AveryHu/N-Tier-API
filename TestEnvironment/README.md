# How to build up the test environment

## What you need

Make sure you have docker and docker-compose installed and running.

Docker-containers

* SQL Server 2019
  * port 1433
  * user sa with password <Pass!W0rd>

# Start

Build API
```dotnet build .\NetCoreWebAPI.sln``` 

Start SQL
```.\TestEnvironment\docker-compose up```

Start API Service
```dotnet run --project .\WebAPI\WebAPI.ServiceLayer.csproj``` 
