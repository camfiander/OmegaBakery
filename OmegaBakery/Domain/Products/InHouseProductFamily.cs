using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    internal class InHouseProductFamily : ProductFamily
    {
        private List<BakeryInHouseProduct> _products;
        private string _name;

        public override List<IProduct> Products => _products.Cast<IProduct>().ToList();

        public override string Name => _name;

        public InHouseProductFamily(string name, List<BakeryInHouseProduct> products)
        {
            _name = name;
            _products = products;
        }

    }
}
