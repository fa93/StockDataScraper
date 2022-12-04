using DataScraper.Main.BusinessObjects;
using DataScraper.Main.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoCkPriceEO = DataScraper.Main.Entities.StockPrice;
namespace DataScraper.Main.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IDseUnitOfWork _dseUnitOfWork;
        public StockPriceService(IDseUnitOfWork dSEUnitOfWork)
        {
            _dseUnitOfWork = dSEUnitOfWork;
        }
        public void AddStockPriceData(List<List<string>> stockPrices)
        {
            for(int i = 0;i < stockPrices.Count; i++)
            {
                var companyId = GetId(stockPrices[i][0]);
                var entity = new StoCkPriceEO
                {
                    CompanyId = companyId,
                    LastTradingPrice = Convert.ToDouble(stockPrices[i][1]),
                    High = double.Parse(stockPrices[i][2]),
                    Low = double.Parse(stockPrices[i][3]),
                    ClosePrice = double.Parse(stockPrices[i][4]),
                    YesterdayClosePrice = double.Parse(stockPrices[i][5]),
                    Change = double.Parse(stockPrices[i][6]),
                    Trade = double.Parse(stockPrices[i][7]),
                    Value = double.Parse(stockPrices[i][8]),
                    Volume = double.Parse(stockPrices[i][9])
                };
                _dseUnitOfWork.StockPrices.Add(entity);
            }
            _dseUnitOfWork.Save();

        }

        public int GetId(string tradeCode)
        {
            var Company = _dseUnitOfWork.Comapnies.Get(i => i.TradeCode.Equals(tradeCode), "").FirstOrDefault();
            return Company.Id;
        }
    }
}
