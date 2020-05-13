using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tinycrm.core.model;
using tinycrm.core.services.Options;

namespace tinycrm.core.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderOptions options);
        Order UpdateOrder(UpdateOrderOptions options);
        IQueryable<Order> SearchOrders(SearchOrderOptions options);
    }
}
