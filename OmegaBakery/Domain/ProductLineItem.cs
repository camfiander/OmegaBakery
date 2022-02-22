using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal class ProductLineItem : LineItem
    {
        private int count;
        private Product product;
        public int Count => count;

        public Product Product => product;

        public double Subtotal 
        { 
            get {
                return Count * Product.BasePrice;
            } 
        }

        public ProductLineItem(Product product, int count)
        {
            this.product = product;
            this.count = count;
        }
    }


}
}
