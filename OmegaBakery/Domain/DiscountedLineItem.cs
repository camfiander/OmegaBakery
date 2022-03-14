using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal class DiscountedLineItem : ILineItem
    {
        private ProductLineItem productLineItem;

        private IDiscount discount;

        public int Count => productLineItem.Count;

        public IProduct Product => productLineItem.Product;

        public double Subtotal => throw new NotImplementedException();

        public DiscountedLineItem(ProductLineItem productLineItem, IDiscount discount)
        {
            this.productLineItem = productLineItem;
            this.discount = discount;
        }
    
    }
}
