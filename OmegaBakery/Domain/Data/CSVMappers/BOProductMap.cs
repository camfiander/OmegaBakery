using CsvHelper.Configuration;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Data.CSVMappers
{
    internal class BOProductMap : ClassMap<OutsideProduct>
    {
        public BOProductMap()
        {
            Map(x=>x.ProductId).Name("ProductId");
            Map(x=>x.Name).Name("Name");
            Map(x=>x.Company).Name("Company");
            Map(x=>x.Description).Name("Description");
            Map(x=>x.BasePrice).Name("BasePrice");
            Map(x=>x.LocationId).Name("LocationId");
            Map(x => x.ProductType).Name("ProductType");
        }
    }
}
