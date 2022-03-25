using OmegaBakery.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Discount
{
    internal class FlatDiscountStrategy : IDiscountStrategy
    {
        private double _discount;
        public double getDiscountSubtotal(ILineItem item, double baseSubtotal)
        {
            return _discount * -1;
        }

        public FlatDiscountStrategy(double discount)
        {
            _discount = discount;
        }
    }
}
