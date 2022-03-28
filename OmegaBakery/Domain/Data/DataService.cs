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

        private static DataService _instance;

        public static DataService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataService();
            }
            return _instance;
        }

        protected static CSVService _csvService;

        public DataService()
        {
            _csvService = new CSVService();
        }

        public IEnumerable<IProduct> GetDataForProduct(string family)
        {
            if (family.Equals("Baked goods"))
            {
                return GetInHouseProducts();
            }
            else if(family.Equals("Packaged items"))
            {
                return GetOutsideProducts();
            }
            else if (family.Equals("All"))
            {
                var products = GetInHouseProducts().Cast<IProduct>().ToList();
                products.AddRange(GetOutsideProducts().Cast<IProduct>().ToList());
                return products;
            }
            return null;
        }

<<<<<<< HEAD
        public int GetStockForProduct(int productId)
        {

        }

        public static List<BakeryInHouseProduct> GetInHouseProducts()
=======
        public static List<InHouseProduct> GetInHouseProducts()
>>>>>>> master
        {
            var csvConfig = AppService.InitOptions<CSVConfig>("CSV FileName");
            var products = _csvService.ReadCSVFile<BIHProductMap, InHouseProduct>(
                                                    csvConfig.Path + csvConfig.BInHouseFileName + ".csv");
            return products.ToList();
        }

        public static List<OutsideProduct> GetOutsideProducts()
        {
            var csvConfig = AppService.InitOptions<CSVConfig>("CSV FileName");
            var products = _csvService.ReadCSVFile<BOProductMap, OutsideProduct>(
                                                    csvConfig.Path + csvConfig.BOutsideFileName + ".csv");
            return products.ToList();
        }

        public static HashSet<int> GetStock()
        {
            var csvConfig = AppService.InitOptions<CSVConfig>("CSV FileName");
            var stocks = _csvService.ReadCSVFile<ProductStockMap, ProductStockData>(
                                                    csvConfig.Path + csvConfig.ProductStockFileName + ".csv");
            HashSet<int> set = new HashSet<int>();
            foreach (var stock in stocks)
            {
                set.Add(stock.ProductId,stock.)
            }
        }

    }
}
