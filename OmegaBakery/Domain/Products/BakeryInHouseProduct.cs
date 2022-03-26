using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal class BakeryInHouseProduct : IInHouseProduct
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double BasePrice { get; private set; }

        public DateTime ExpiryDate { get; private set; }

        public int? LocationId { get; private set; }

        public DateTime DateAdded { get; private set; }

        public BakeryInHouseProduct(int productId, string name, string description, double basePrice, int locationId, DateTime expiryDate, DateTime dateAdded)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            BasePrice = basePrice;
            LocationId = locationId;
            ExpiryDate = expiryDate;
            DateAdded = dateAdded;
        }

        public BakeryInHouseProduct() 
        {
            Name = String.Empty;
            Description = String.Empty;
        }

        public string Render()
        {
            return Name + " - " + Description + " - " + BasePrice.ToString("C");
        }

        public bool Equals(IProduct? other)
        {
            if (other == null)
            {
                return false;
            }
            return other.Name.Equals(Name);
        }
    }
}
