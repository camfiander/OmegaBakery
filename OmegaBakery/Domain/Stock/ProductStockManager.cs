using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Stock
{
    internal sealed class ProductStockManager
    {
        private ProductStockManager() 
        {
            List<IProduct> products = ProductService.GetProducts("All").Cast<IProduct>().ToList();
            _stockList = new List<ProductStock>();
            var productGroupCount = products.GroupBy(
                                    prod => prod.Name,
                                    (key, g) => new { prodName = key, prodCount = g.Count() });
            foreach (var product in products)
            {
                _stockList.Add(new ProductStock(product, productGroupCount.First(x=>x.prodName.Equals(product.Name)).prodCount));
            }
        }

        private static ProductStockManager _instance;

        private List<ProductStock> _stockList;

        public static ProductStockManager getInstance() { 
            if( _instance == null)
            {
                _instance = new ProductStockManager();
            }
            return _instance;
        }

        public int getStockCount(IProduct product)
        {
            return _stockList.Where(x => x.Product.Equals(product)).Sum(x => x.AvailableCount);
        }

        public bool sellStock(IProduct product, int count)
        {
            if (count <= 0)
            {
                return false;
            }
            if (getStockCount(product) < count)
            {
                return false;
            }
            IEnumerator<ProductStock> productStocks = _stockList.FindAll(x => x.Product.Equals(product)).GetEnumerator();
            int countRemaining = count;

            while (countRemaining > 0)
            {
                productStocks.MoveNext();
                countRemaining -= productStocks.Current.sell(countRemaining);
            }
            return true;
        }

        //public void addNewStock()
        //{
        //    CheckPoint1:
        //    Console.Clear();
        //    Console.WriteLine("Select\n1. Add Stock\n2. Add New Product\n3. Exit");
        //    var choice = Console.ReadLine();
        //    int x = 0;
        //    if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out x))
        //    {
        //        goto CheckPoint1;
        //    }
        //    switch (x)
        //    {
        //        case 1:
        //            CheckPoint2:
        //            Console.Clear();
        //            Console.WriteLine("Select\n1. InHouse\n2. Outside");
        //            var prodType = Console.ReadLine();
        //            int y = 0;
        //            if (string.IsNullOrWhiteSpace(prodType) || !int.TryParse(prodType, out y) || y > _stockList.Count())
        //            {
        //                goto CheckPoint2;
        //            }
        //            switch(y)
        //            {
        //                case 1:
        //                    Checkpoint3:
        //                    Console.WriteLine("Select Product Number\n");
        //                    int i = 1;
        //                    foreach (var product in _stockList)
        //                    {
        //                        Console.WriteLine(i.ToString(), ". ", product.Product.Name, " [", product.AvailableCount, "]");
        //                    }
        //                    var prodNum = Console.ReadLine();
        //                    int z = 0;
        //                    if (string.IsNullOrWhiteSpace(prodNum) || !int.TryParse(prodNum, out y) || y > _stockList.Count())
        //                    {
        //                        goto Checkpoint3;
        //                    }
        //                    var newInProduct = new BakeryInHouseProduct();
        //                    Console.WriteLine("Enter count");
        //                    break;
        //                case 2:
        //                    Console.WriteLine("Select Product Number\n");
        //                    int i = 1;
        //                    foreach (var product in _stockList)
        //                    {
        //                        Console.WriteLine(i.ToString(), ". ", product.Product.Name, " [", product.AvailableCount, "]");
        //                    }
        //                    var prodNum = Console.ReadLine();
        //                    int y = 0;
        //                    if (string.IsNullOrWhiteSpace(prodNum) || !int.TryParse(prodNum, out y) || y > _stockList.Count())
        //                    {
        //                        goto CheckPoint2;
        //                    }
        //                    var newProduct = new BakeryOutsideProduct();
        //                    Console.WriteLine("Enter count");

        //                    break;
        //            }
        //    }
        //}
    }
}
