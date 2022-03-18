using OmegaBakery.Domain.Order;
using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Discount
{
    internal class Discount : IDiscount
    {
        private IDiscountStrategy strategy;
        private List<IProduct> _discountableProducts;

        public double getDiscountSubtotal(List<ProductLineItem> items)
        {
            return strategy.getDiscountSubtotal(items);
        }

        public bool isDiscounted(List<ProductLineItem> items)
        {
            foreach (ProductLineItem item in items)
            {
                if (!_discountableProducts.Any(x => x.Equals(item.Product)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
