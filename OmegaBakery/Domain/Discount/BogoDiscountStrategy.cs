using OmegaBakery.Domain.Order;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Discount
{
    internal class BogoDiscountStrategy : IDiscountStrategy
    {
        public double getDiscountSubtotal(ILineItem item, double baseSubtotal)
        {
            //For every pair of items, remove the cost of one
            // e.g. 5 items => discount = subtotal * (-2/5)
            return baseSubtotal * Math.Floor((double)item.Count/2)/item.Count * -1;
        }

    }
}
