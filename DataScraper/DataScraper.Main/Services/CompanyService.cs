using DataScraper.Main.BusinessObjects;
using DataScraper.Main.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComapnyEO = DataScraper.Main.Entities.Company;

namespace DataScraper.Main.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IDseUnitOfWork _dseUnitOfWork;
        public CompanyService(IDseUnitOfWork dSEUnitOfWork)
        {
            _dseUnitOfWork = dSEUnitOfWork;
        }
        public void AddCompany(List<string> companies)
        {
            foreach(var companyTradeCode in companies)
            {
                var getId = _dseUnitOfWork.Comapnies.Get(x => x.TradeCode == companyTradeCode, "").FirstOrDefault();
                if(getId == null)
                {
                    var entity = new ComapnyEO()
                    {
                        TradeCode = companyTradeCode
                    };
                    _dseUnitOfWork.Comapnies.Add(entity);
                }
                
            }
            
            _dseUnitOfWork.Save(); 
        }
    }
}
