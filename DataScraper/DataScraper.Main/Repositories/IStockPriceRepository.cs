using DataScraper.Data;
using DataScraper.Main.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Main.Repositories
{
    public interface IStockPriceRepository : IRepository<StockPrice, int>
    {
    }
}
