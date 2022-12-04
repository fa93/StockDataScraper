using DataScraper.Data;
using DataScraper.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Main.UnitOfWorks
{
    public interface IDseUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Comapnies { get; }
        IStockPriceRepository StockPrices { get; }
    }
}
