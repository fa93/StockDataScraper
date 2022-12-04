using DataScraper.Main.BusinessObjects;
using DataScraper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataScraper.Main.UnitOfWorks;

namespace DataScraper.Main.Services
{
    public interface ICompanyService 
    {
        void AddCompany(List<string> company);
    }
}
