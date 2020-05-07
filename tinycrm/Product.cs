using System;
using System.Collections.Generic;
using System.Text;

namespace tinycrm
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductCategory { get; set; }

        //public Product(string ProductId, string Description, string Name, decimal Price)
        //{
        //  this.ProductId = ProductId;
        // this.Description = Description;
        //this.Name = Name;
        //this.Price = Price;
        //}
    }
   
}
