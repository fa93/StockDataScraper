using DataScraper.Data;
using DataScraper.Main.DbContexts;
using DataScraper.Main.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Main.UnitOfWorks
{
    public class DseUnitOfWork : UnitOfWork, IDseUnitOfWork
    {
        public ICompanyRepository Comapnies { get; private set; }
        public IStockPriceRepository StockPrices { get; private set; }


        public DseUnitOfWork(IDseDbContext dbContext,
            ICompanyRepository companyRepository,
            IStockPriceRepository stockPriceRepository) : base((DbContext)dbContext)
        {
            Comapnies = companyRepository;
            StockPrices = stockPriceRepository;
        }
    }
}
