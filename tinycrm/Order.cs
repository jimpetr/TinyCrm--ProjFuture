using System;
using System.Collections.Generic;
using System.Text;

namespace tinycrm
{
    class Order
    {
        public string OrderId { get; private set; }
        public string DeliveryAddres { get; set; }
        public decimal TotalAmount { get; set; }

        public Order(string str)
        {
            OrderId = str;
        }
    }
}
