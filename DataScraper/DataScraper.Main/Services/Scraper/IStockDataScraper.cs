using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Main.Services.Scraper
{
    public interface IStockDataScraper
    {
        public List<List<string>> DataScraper();
        public string Status(); 
    }
}
