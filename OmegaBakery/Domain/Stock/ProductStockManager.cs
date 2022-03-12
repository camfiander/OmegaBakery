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
            _stockList = new List<ProductStock>();
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

        public int getStockCount(Product product)
        {
            return _stockList.Where(x => x.Product == product).Sum(x => x.AvailableCount);
        }

        public Boolean sellStock(Product product, int count)
        {
            if (count <= 0)
            {
                return false;
            }
            if (getStockCount(product) < count)
            {
                return false;
            }
            IEnumerator<ProductStock> productStocks = _stockList.FindAll(x => x.Product == product).GetEnumerator();
            int countRemaining = count;

            while (countRemaining > 0)
            {
                countRemaining -= productStocks.Current.sell(countRemaining);
                productStocks.MoveNext();
            }
            return true;
        }
    


}
}
