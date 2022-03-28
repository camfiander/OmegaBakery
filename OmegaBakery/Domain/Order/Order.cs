using OmegaBakery.Domain.Discount;
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

        private List<IDiscount> _discounts;

        public Order()
        {
            _lineItems = new List<CompositeLineItem>();
            _discounts = DiscountService.GetDiscounts();
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

        
        public bool UpdateCount(IProduct product, int newCount)
        {
            return _lineItems.Find(x => x.ProductType.Equals(product.ProductType))
                .UpdateCount(product,newCount);
            
        }

        public string Render()
        {
            UpdateDiscounts();
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

        private void UpdateDiscounts()
        {
            List<CompositeLineItem> newCart = new List<CompositeLineItem>(); 
            foreach(CompositeLineItem lineItem in _lineItems)
            {
                bool discounted = false;
                foreach(IDiscount discount in _discounts)
                {
                    if (discount.isDiscounted(lineItem) && !(lineItem is DiscountedLineItem))
                    {
                        DiscountedLineItem discountedLineItem = new DiscountedLineItem(lineItem, discount);
                        newCart.Add(discountedLineItem);
                        discounted = true;
                        break;
                    }
                }
                if (!discounted)
                {
                    newCart.Add(lineItem);
                }
            }

            _lineItems = newCart;
        }
        
    }
}
