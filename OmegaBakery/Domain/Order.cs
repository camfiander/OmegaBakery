using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal class Order
    {
        public int Id { get; private set; }
        public IReadOnlyCollection<LineItem> LineItems { get => _lineItems; }

        private List<LineItem> _lineItems;

        public Order(List<LineItem> lineItems)
        {
            _lineItems = lineItems;
        }

        public void addLineItem(LineItem lineItem)
        {
            _lineItems.Add(lineItem);
        }
        
    }
}
