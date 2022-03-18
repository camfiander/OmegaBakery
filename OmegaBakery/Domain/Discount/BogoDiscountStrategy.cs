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
        public double getDiscountSubtotal(List<ProductLineItem> items)
        {
            return items.Sum(x => x.Product.BasePrice * Math.Floor((double)(x.Count / 2))) * -1;
        }

    }
}
