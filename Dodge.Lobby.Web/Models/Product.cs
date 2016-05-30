using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dodge.Lobby.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }

        public List<Product> GetProducts(int id)
        {
            try
            {
                List<Product> productLst = new List<Product>();
                productLst.Add(new Product() { Id = 1, Name = "DGN", Abbrev = "PNP", Logo = "dgn.png", Url = @"http://localhost.dodgedev.com/DGN/Home.aspx" });
                productLst.Add(new Product() { Id = 1, Name = "Dodge BI", Abbrev = "BI", Logo = "bi.png", Url = @"http://localhost.dodgedev.com/BI/Home.aspx" });
                
                return productLst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}