using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal class BakeryInHouseProduct : IInHouseProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int? LocationId { get; set; }

        public DateTime DateAdded { get; set; }
        public ProductType ProductType { get; set; }

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
