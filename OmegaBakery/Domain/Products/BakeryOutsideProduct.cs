﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal class BakeryOutsideProduct : IOutsideProduct
    {
        public int ProductId { get; private set; }

        public string Name { get; private set; }
        public string Company { get; private set; }

        public string Description { get; private set; }

        public double BasePrice { get; private set; }

        public int LocationId { get; private set; }

        public bool Equals(IProduct? other)
        {
            throw new NotImplementedException();
        }

        public BakeryOutsideProduct(int productId, string name, string description, double basePrice, int locationId, string company)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            BasePrice = basePrice;
            LocationId = locationId;
            Company = company;
        }

        public BakeryOutsideProduct()
        {
            Name = String.Empty;
            Company = String.Empty;
            Description = String.Empty;
        }
        public string Render()
        {
            throw new NotImplementedException();
        }
    }
}
