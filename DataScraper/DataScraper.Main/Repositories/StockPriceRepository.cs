using DataScraper.Data;
using DataScraper.Main.DbContexts;
using DataScraper.Main.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Main.Repositories
{
    public class StockPriceRepository : Repository<StockPrice, int>, IStockPriceRepository
    {
        public StockPriceRepository(IDseDbContext context) : base((DbContext)context)
        {
        }
    }
}
