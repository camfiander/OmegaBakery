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
        private IDiscountStrategy _strategy;

        private Predicate<ILineItem> _predicate;

        public string Name { get; set; }

        public double getDiscountSubtotal(ILineItem item)
        {
            return _strategy.getDiscountSubtotal(item,item.Subtotal);
        }

        public double getDiscountSubtotal(ILineItem item, double baseSubtotal)
        {
            if (isDiscounted(item))
            {
                return _strategy.getDiscountSubtotal(item, baseSubtotal);
            }
            return 0;
        }

        public bool isDiscounted(ILineItem item)
        {
            return _predicate.Invoke(item);
        }

        public Discount(IDiscountStrategy strategy, string name, Predicate<ILineItem> predicate)
        {
            _strategy = strategy;
            Name = name;
            _predicate = predicate;
        }
    }
}
