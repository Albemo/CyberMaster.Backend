# CyberMaster.Backend system built on .Net Core 5.0


## Visual Studio 2019 and PostgeSQL

#### Prerequisites

- PostgreSQL
- [Visual Studio 2019 version 16.8 with .NET Core SDK 5.0 ](https://dotnet.microsoft.com/download)

#### Steps to run

- Create a database in PostgreSQL
- Update the connection string in appsettings.json in CyberMaster.Backend.WebApi
- Build whole solution.
- Open Package Manager Console Window and type "Update-Database" then press "Enter". This action will create database schema.
- Execute src/Database/StaticData.sql on the created database to insert seed data.
- In Visual Studio, press "Control + F5".

## Technologies and frameworks used:
- ASP.NET Core 5.0
- Entity Framework Core 5.0.4
- ASP.NET Identity Core 5.0.4

## The architecture highlight

The CyberMaster.Backend.Api contains controllers, services
The CyberMaster.Backend.Infrastructure contains the conexión to the database
The CyberMaster.Backend.Core contains domain models
