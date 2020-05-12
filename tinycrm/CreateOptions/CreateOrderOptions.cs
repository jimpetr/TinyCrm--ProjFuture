using System;
using System.Collections.Generic;
using System.Text;

namespace tinycrm
{
    public class CreateOrderOptions
    {
        public int CustomerId { get; set; }
        public List<string> ProductsIds { get; set; }
        public string DeliveryAddress { get; set; }


        public CreateOrderOptions()
        {
            ProductsIds = new List<string>();
        }
    }
}
