using OmegaBakery.Domain.Products;
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

        private List<CompositeLineItem> _lineItems;

        public Order()
        {
            _lineItems = new List<CompositeLineItem>();
        }

        public void AddLineItem(ILineItem lineItem)
        {
            //Add to composite line item with same product type
            CompositeLineItem? lineItemForType = _lineItems.Find(x => x.ProductType.Equals(lineItem.ProductType));
            if (lineItemForType == null)
            {
                lineItemForType = new CompositeLineItem(lineItem.ProductType);
                _lineItems.Add(lineItemForType);

            }
            lineItemForType.AddLineItem(lineItem);
        }

        
        public void updateCount(IProduct product, int newCount)
        {
            
        }
        
    }
}
