using OmegaBakery.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Discount
{
    internal class PercentDiscountStrategy : IDiscountStrategy
    {
        private double _discount;
        public double getDiscountSubtotal(List<ProductLineItem> items)
        {
            return items.Sum(x => x.Subtotal) * _discount * -1;
        }

        public PercentDiscountStrategy(double discount)
        {
            _discount = discount;
        }
    }
}
