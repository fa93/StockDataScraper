using DataScraper.Main.Services;
using DataScraper.Main.Services.Scraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Worker.Models
{
    public class StockDataScraperModel
    {
        private readonly IStockDataScraper _stockDataScraper;
        private readonly ICompanyService _companyService;
        private readonly IStockPriceService _stockPriceService;

        public StockDataScraperModel(IStockDataScraper stockDataScraper, 
            IStockPriceService stockPriceService,
            ICompanyService companyService)
        {
            _stockDataScraper = stockDataScraper;
            _companyService = companyService;
            _stockPriceService = stockPriceService;
        }

        public string GetStatus()
        {
            return _stockDataScraper.Status();
        }

        public void GetMarketStockData()
        {
            var data = _stockDataScraper.DataScraper();
            var companies = new List<string>();
            var stockPrices = new List<List<string>>();
            
            foreach(var item in data)
            {
                var singleStock = new List<string>();
                companies.Add(item[1]);
                for (int i = 1; i < item.Count(); i++)
                {                    
                    singleStock.Add(item[i]);                 
                }
                stockPrices.Add(singleStock);
            }

            InsertCompanies(companies);
            InsertStockPrices(stockPrices);
        }

        public void InsertCompanies(List<string> companies)
        {
            _companyService.AddCompany(companies);
        }

        public void InsertStockPrices(List<List<string>> stockPrices)
        {
            _stockPriceService.AddStockPriceData(stockPrices);
        }
    }
}
