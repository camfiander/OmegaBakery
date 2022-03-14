﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain.Products
{
    //Holds placeholder data for now, could be replaced by a DB service later
    internal class ProductService
    {
        public static List<IProduct> GetProducts()
        {
            return new List<IProduct>()
            {
                new BakeryInHouseProduct(0,"bread","let them eat cake",2.50,TimeSpan.FromDays(7)),
                new BakeryInHouseProduct(1,"bagel","all toasters toast bagels",4.00,TimeSpan.FromDays(4)),
                new BakeryInHouseProduct(2,"smoothie","fruits and milk",6.00,TimeSpan.FromDays(9))
            };
        }

        public static List<ProductFamily> GetProductFamilies()
        {
            return new List<ProductFamily>
            {
                new InHouseProductFamily("Baked goods",GetProducts().Cast<BakeryInHouseProduct>().ToList())
            };
        }
    }
}