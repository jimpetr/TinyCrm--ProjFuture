using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tinycrm
{
    public class DummyCustomerService : ICustomerService
    {
        public Customer CreateCustomer(CreateCustomerOptions options)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            var customer = new Customer()
            {
                FirstName = "Dummy",
                LastName = "Customer",
                CustomerId = 3
            };

            var list = new List<Customer>();
            list.Add(customer);
            return list.AsQueryable();
        }
    }
}
