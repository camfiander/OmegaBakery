using OmegaBakery.Domain.Discount;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal class DiscountedLineItem : ILineItem
    {
        private List<ProductLineItem> _productLineItems;

        private IDiscount discount;

        public int Count => 0;

        public DiscountedLineItem(ProductLineItem productLineItem, IDiscount discount)
        {
            this.productLineItem = productLineItem;
            this.discount = discount;
        }
    
    }
}
