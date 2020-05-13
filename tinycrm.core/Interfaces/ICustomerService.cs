using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tinycrm.core.model;
using tinycrm.core.services.Options;

namespace tinycrm.core.Interfaces
{
    public interface ICustomerService
    {
        IQueryable<Customer> SearchCustomers(SearchCustomerOptions options);
        Customer CreateCustomer(CreateCustomerOptions options);
        Customer UpdateCustomer(UpdateCustomerOptions options);
        Customer GetCustomerById(int? id);
    }
}
