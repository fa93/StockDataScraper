
# Stock Market Data Scraper 

This is a Worker Service project to scrape  stock data from [Dhaka Stock Exchange](https://www.dsebd.org/) as a background service.
## Installation

1) Clone the project
```bash
  https://github.com/fa93/StockDataScraper.git
```
2) Run the file with extension ` .Sln ` on Visual Studio

3) Set the `DefaultConnection` in `appsettings.json` file 
```bash
"ConnectionStrings": {
    "DefaultConnection": ""
  },
```

4) Now, Update the migrations by running the following command on ``` Package Manager Console ```
```bash
  dotnet ef database update --project DataScraper.Service --context DseDbContext
```
⚠️ Must install ` Microsoft Visual Studio `, ` Microsoft SQL Server` and `SQL Server Management Studio` on your device

## Environment Setup

To run this project as Background Service, you will need to do the following  Steps

`# Publish the worker service project`

`# Install .exe file `

`# Open the Service app to see the service`

`# Start the service`


## Tech Stack

**Backend:** ASP.NET Core 6, Entity Framework core

**Server:**  Microsoft SQL Server

**Web Scrapper:** HTML Agility Pack 

**Logger:** Serilog

**Dependency Injection:** Autofac

**Design Patterns:** Repository & Unit of Work

**Architecture:** Layered Architecture (UI, Business Logic & Data Access Layer)

