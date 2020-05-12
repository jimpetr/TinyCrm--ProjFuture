using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm;

namespace tinycrm
{

    public class OrderService : IOrderService
    {
        private TinyCrmDbContext context_;
        private ICustomerService customerservice_;
        private IProductService productService;
 

        public OrderService(TinyCrmDbContext context, ICustomerService customerservice, IProductService productservice)
        {
            context_ = context;
            customerservice_ = customerservice;
            productService = productservice;
        }

        public Order CreateOrder(CreateOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = customerservice_.SearchCustomers(new SearchCustomerOptions()
            {
                CustomerId = options.CustomerId,
            }).SingleOrDefault();

            if (customer == null)
            {
                return null;
            }

            var order = new Order()
            {
                DeliveryAddress = options.DeliveryAddress,
            };

            foreach (var prod in options.ProductsIds)
            {
                if (prod == null) continue;

                var product = productService.SearchProduct
                    (new SearchProductsOptions()
                    {
                        ProductId = prod
                    }
                    ).SingleOrDefault();

                if (product != null)
                {
                    var orderProd = new OrderProduct()
                    {
                        Product = product,
                    };

                    order.OrderProducts.Add(orderProd);
                }
                else
                {
                    return null;
                }
            }

            if (order.OrderProducts.Count == 0)
            {
                return null;
            }

            customer.Orders.Add(order);

            context_.Update(customer);

            return context_.SaveChanges() > 0 ? order : null;
        }


        public IQueryable<Order> SearchOrders(SearchOrderOptions options)
        {
            if (options == null) return null;

            var query = context_
                .Set<Order>()
                .AsQueryable();

            if (options.OrderId != null)
            {
                query = query.Where(x => x.OrderId == options.OrderId);
            }

            if (options.DeliveryAddress != null)
            {
                query = query.Where(x => x.DeliveryAddress == options.DeliveryAddress);
            }

            if (options.PriceFrom != null)
            {
                query = query.Where(x => x.TotalAmount >= options.PriceFrom);
            }

            if (options.PriceTo != null)
            {
                query = query.Where(x => x.TotalAmount <= options.PriceTo);
            }

            return query.AsQueryable();
        }


        public Order UpdateOrder(UpdateOrderOptions options)
        {
            if (options == null || options.OrderId == null) return null;
            var order = context_
                 .Set<Order>()
                .Where(x => x.OrderId == options.OrderId)
               .Include(o => o.OrderProducts)
                .SingleOrDefault();

            if (order == null)
            {
                return null;
            }

            if (options.DeliveryAddress != null)
            {
                order.DeliveryAddress = options.DeliveryAddress;
            }

            order.OrderProducts.Clear();

            order.TotalAmount = 0M;

            foreach (var id in options.ProductIds)
            {
                var product = productService.GetProductById(id);

                if (product == null)
                {
                    return null;
                }

                order.OrderProducts.Add(new OrderProduct()
                {
                    Product = product,
                });

                order.TotalAmount += product.Price;
            }

            return context_.SaveChanges() > 0 ? order : null;

        }
    }
}
