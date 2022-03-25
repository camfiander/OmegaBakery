using OmegaBakery.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Discount
{
    internal interface IDiscountStrategy
    {
        public double getDiscountSubtotal(ILineItem item, double baseSubtotal);
    }
}
