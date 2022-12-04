
using DataScraper.Main.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Main.Services
{
    public interface IStockPriceService
    {
        int GetId(string tradeCode);
        void AddStockPriceData(List<List<string>> stockPrice);
    }
}
