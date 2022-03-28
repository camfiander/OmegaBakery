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
            foreach (var product in products)
            {
                _stockList.Add(new ProductStock(product, ProductService.GetStockForProduct(product.ProductId)));
            }
        }

        private static ProductStockManager _instance;

        private List<ProductStock> _stockList;

        public static ProductStockManager GetInstance() { 
            if( _instance == null)
            {
                _instance = new ProductStockManager();
            }
            return _instance;
        }

        public int GetStockCount(IProduct product)
        {
            return _stockList.First(x => x.Product.Equals(product)).AvailableCount;
        }

        public bool SellStock(IProduct product, int count)
        {
            if (count <= 0)
            {
                return false;
            }
            if (GetStockCount(product) < count)
            {
                return false;
            }
            IEnumerator<ProductStock> productStocks = _stockList.FindAll(x => x.Product.Equals(product)).GetEnumerator();
            int countRemaining = count;

            while (countRemaining > 0)
            {
                productStocks.MoveNext();
                countRemaining -= productStocks.Current.Sell(countRemaining);
            }
            return true;
        }

        public void RestoreStock(IProduct product, int count)
        {
            _stockList.Add(new ProductStock(product, count));
        }
    }
}
