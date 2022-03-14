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
            List<IProduct> products = ProductService.GetProducts();
            _stockList = new List<ProductStock>();
            foreach (var product in products)
            {
                _stockList.Add(new ProductStock(product, 12));
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
    


}
}
