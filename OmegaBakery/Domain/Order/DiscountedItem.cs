using OmegaBakery.Domain.Discount;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal class DiscountedItem : ILineItem
    {
        private ProductLineItem line;
        private IDiscount discount;
        public DiscountedItem(ProductLineItem line, IDiscount discount)
        {
            this.line = line;
            this.discount = discount;
        }

        public int Count => throw new NotImplementedException();

        public IProduct Product => throw new NotImplementedException();

        public double Subtotal => throw new NotImplementedException();

        public ProductLineItem pop()
        {
            return line;
        }
    }
}
