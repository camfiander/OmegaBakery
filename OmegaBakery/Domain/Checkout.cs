﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaBakery.Domain
{
    internal class Checkout
    {
        public Order Order { get; set; }
        public void checkout()
        {
            foreach(LineItem item in Order.LineItems)
            {
                
            }
        }
    }
}