﻿using OmegaBakery.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Order
{
    internal class CompositeLineItem : ILineItem
    {
        protected List<ILineItem> _items;
        public int Count => _items.Sum(x => x.Count);

        public virtual double Subtotal => _items.Sum(x => x.Subtotal);

        public ProductType ProductType { get; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _items)
            {
                sb.Append("\t");
                sb.Append(item.Render());
            }
            return sb.ToString();
        }

        public CompositeLineItem(ProductType productType)
        {
            ProductType = productType;
        }

        public void AddLineItem(ILineItem lineItem)
        {
            if(lineItem.ProductType != ProductType)
            {
                return;
            }

            _items.Add(lineItem);
        }
    }
}