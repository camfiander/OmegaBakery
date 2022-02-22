using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal class DiscountedItem : LineItem
    {
        private LineItem line;
        private Discount discount;
        public DiscountedItem(LineItem line, Discount discount)
        {
            this.line = line;
            this.discount = discount;
        }

        public LineItem pop()
        {
            return line;
        }
    }
}
