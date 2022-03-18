using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal class Order
    {
        public int Id { get; private set; }
        public IReadOnlyCollection<ILineItem> LineItems { get => _lineItems; }

        private List<ILineItem> _lineItems;

        public Order(List<ILineItem> lineItems)
        {
            _lineItems = lineItems;
        }

        public void addLineItem(ILineItem lineItem)
        {
            _lineItems.Add(lineItem);
        }
        
    }
}
