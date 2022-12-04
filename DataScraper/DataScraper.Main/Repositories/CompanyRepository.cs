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
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(IDseDbContext context) : base((DbContext)context)
        {
        }
    }
}
