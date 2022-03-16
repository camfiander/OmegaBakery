using OmegaBakery.Domain.Data.CSVMappers;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Data
{
    internal class DataService
    {
        public static List<IProduct> GetDataForProduct()
        {
            var csvConfig = AppService.InitOptions<CSVConfig>("CSV FileName");
            var products = CSVService.ReadCSVFile<BIHProductMap, IProduct>(csvConfig.BInHouseFileName);
            products.AddRange(CSVService.ReadCSVFile<BOProductMap, IProduct>(csvConfig.BOutsideFileName));
            return products;
        }
    }
}
