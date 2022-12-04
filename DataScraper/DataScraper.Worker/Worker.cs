using DataScraper.Worker.Models;

namespace DataScraper.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly StockDataScraperModel _stockDataScraperModel;

        public Worker(ILogger<Worker> logger, StockDataScraperModel stockDataScraperModel)
        {
            _logger = logger;
            _stockDataScraperModel = stockDataScraperModel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                if(_stockDataScraperModel.GetStatus().ToLower() == "open")
                {
                    _stockDataScraperModel.GetMarketStockData();
                }
                else
                {
                    _logger.LogInformation("Market Status Closed at: {time}", DateTimeOffset.Now);
                }

                await Task.Delay(6000, stoppingToken);
            }
        }
    }
}