using OmegaBakery.Domain.Discount;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal class DiscountedLineItem : CompositeLineItem
    {
        private IDiscount _discount;

        public override double Subtotal => _items.Sum(x => x.Subtotal) + _discount.getDiscountSubtotal(this,base.Subtotal);

        public DiscountedLineItem(ILineItem lineItem, IDiscount discount) : base(lineItem.ProductType)
        {
            AddLineItem(lineItem);
            _discount = discount;
        }

        public string Render()
        {
            double discountAmount = _discount.getDiscountSubtotal(this, base.Subtotal);
            if(discountAmount > 0)
            {
                return base.Render() + $"{_discount.Name}\t{discountAmount.ToString("C")}";
            }
            return base.Render();
        }
    }
}
