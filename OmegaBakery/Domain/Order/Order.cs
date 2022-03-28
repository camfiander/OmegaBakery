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
        public int OrderId { get; private set; }
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
            if (product == null) return;
            _lineItems.Find(x => x.ProductType.Equals(product.ProductType))
                .UpdateCount(product,newCount);
            
        }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            double total = 0;
            foreach(ILineItem lineItem in LineItems)
            {
                total += lineItem.Subtotal;
                sb.AppendLine(lineItem.Render());
            }
            sb.AppendLine("TOTAL: " + total.ToString("C"));
            return sb.ToString();
        }
        
    }
}
