using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Data.CSVMappers
{
    internal class ProductStockMap : ClassMap<ProductStockData>
    {
        public ProductStockMap()
        {
            Map(x => x.ProductId).Name("ProductId");
            Map(x => x.Count).Name("Count");
        } 
    }
}
