using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal abstract class ProductFamily
    {
        public abstract List<IProduct> Products { get; }

        public abstract string Name { get; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            foreach(IProduct product in Products)
            {
                sb.AppendLine(product.Render());
            }

            return sb.ToString();
        }

        
    }
}
