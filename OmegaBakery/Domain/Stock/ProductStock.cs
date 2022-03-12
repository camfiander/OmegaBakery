using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Stock
{
    internal class ProductStock
    {
        public Product Product { get; private set; }

        public int InitialCount { get; private set; }

        public int AvailableCount { get; private set;  }

        public int LocationId { get; private set; }
        public DateTime CreationTime { get; private set; }

        public ProductStock(Product product, int count)
        {
            Product = product;
            InitialCount = count;
            AvailableCount = count;
            CreationTime = DateTime.Now;
        }

        public int sell(int count)
        {
            if (count <= 0)
            {
                return 0;
            }
            if(count > AvailableCount)
            {
                int soldCount = AvailableCount;
                AvailableCount = 0;
                return soldCount;
            }
            AvailableCount -= count;
            return count;
        }
    }
}
