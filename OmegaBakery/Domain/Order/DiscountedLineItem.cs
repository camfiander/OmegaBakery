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

        private IDiscount _discount;

        public int Count => 0;

        public double Subtotal => throw new NotImplementedException();

        public DiscountedLineItem(List<ProductLineItem> productLineItems, IDiscount discount)
        {
            _productLineItems = productLineItems;
            _discount = discount;
        }

        public string Render()
        {
            throw new NotImplementedException();
        }
    }
}
