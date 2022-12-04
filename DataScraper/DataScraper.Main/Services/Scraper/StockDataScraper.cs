using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScraper.Main.Services.Scraper
{
    public class StockDataScraper : IStockDataScraper
    {
        public HtmlDocument getHtmlDoc()
        {
            var html = @"https://www.dse.com.bd/latest_share_price_scroll_l.php";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            return htmlDoc;
        }

        public  List<List<string>> DataScraper()
        {
            var htmlDoc = getHtmlDoc();

            //method 1 to get the table
            var tableNode = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/section[1]/div[1]/div[3]/div[1]/div[2]/div[1]/table").ChildNodes;
            var rows = tableNode.Where(node => node.NodeType == HtmlNodeType.Element);

            var companies = new List<string>();
            var stockData = new List<List<string>>();

            foreach (var item in rows)
            {              
                var result = item.InnerText.Split('\t','\r','\n');     
                /*if(result.Contains("#"))
                {
                    companies = filter(result.ToList());
                }
                else 
                {
                    stockData.Add(filter(result.ToList()));
                }  */ 
                if(!result.Contains("#"))
                    stockData.Add(filter(result.ToList()));
            }

            //method 2 to get the table
            /*var tableNodes = htmlDoc
                .DocumentNode.Descendants("table")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("shares-table")).ToList();*/   
            
            return  stockData;
        }

        public List<string> filter(List<string> text)
        {
            var result =new List<string>();
            foreach(var col in text)
            {
                var isEmpty = col.Length == 0;
                
                if (!isEmpty)
                {
                    var onlySpace = col.ToArray().Where(x => x.Equals(' ')).Count() == col.Length;
                    if(!onlySpace)
                    {
                        if (col == "--")
                        {
                            result.Add("0");
                        }
                        else
                        {
                            result.Add(col);
                        }
                    }
                    
                }
            }
            return result;
        }

        public string Status()
        {
            var htmlDoc = getHtmlDoc();
            var status = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]" +
               "/div[1]/header[1]/div[1]/span[3]/span[1]/b[1]");

            return status.InnerText;
        }
    }
}
