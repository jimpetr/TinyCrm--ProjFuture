﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tinycrm.core.model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

        public decimal TotalAmount { get; set; }

        public Order()
        {
            Created = DateTimeOffset.Now;
            OrderProducts = new List<OrderProduct>();
        }
    }
}
