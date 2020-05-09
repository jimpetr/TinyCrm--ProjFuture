using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tinycrm
{
    public interface ICustomerService
    {
        IQueryable<Customer> SearchCustomers(SearchCustomerOptions options);
        Customer CreateCustomer(CreateCustomerOptions options);
    }
}
