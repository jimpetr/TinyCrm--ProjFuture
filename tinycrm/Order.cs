using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;




namespace tinycrm
{
    public class Order
    {
        public string OrderId { get; private set; }
        public string DeliveryAddres { get; set; }
        private decimal totalamount;
        public List<Product> Products { get; set; }

        public decimal TotalAmount
        {
            get { return totalamount = Products.Select(x => x.Price).Sum();  }
            
        }
    }
}
