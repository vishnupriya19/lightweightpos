﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MerchantId { get; set; }

        public virtual Merchant Merchant { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
