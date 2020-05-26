using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA.Models
{
    public class ProductsViewModel
    {
        public IQueryable<Product> Products { get; set; }
        public string Text { get; set; }
    }
}
