using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal class DiscountedLineItem : LineItem
    {
        private ProductLineItem productLineItem;

        private Discount discount;

        public int Count => productLineItem.Count;

        public Product Product => productLineItem.Product;

        public DiscountedLineItem(ProductLineItem productLineItem, Discount discount)
        {
            this.productLineItem = productLineItem;
            this.discount = discount;
        }
    
    }
}
