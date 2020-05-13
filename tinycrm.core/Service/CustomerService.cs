using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tinycrm.core.Interfaces;
using tinycrm.core.model;
using tinycrm.core.services.Options;

namespace tinycrm.core.service
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context_;
        public CustomerService(TinyCrmDbContext context)
        {
            context_ = context;
        }

        public Customer CreateCustomer(CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = new Customer()
            {
                LastName = options.Lastname,
                FirstName = options.Firstname,
                VatNumber = options.Vatnumber,
                Email = options.Email,
                Phone = options.Phone,
            };
            context_.Add(customer);
            return context_.SaveChanges() > 0 ? customer : null;
        }


        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (options.CustomerId != null)
            {
                query = query.Where(x => x.CustomerId == options.CustomerId);
            }

            if (!string.IsNullOrWhiteSpace(options.FirstName))
            {
                query = query.Where(x => x.FirstName == options.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(options.LastName))
            {
                query = query.Where(x => x.LastName == options.LastName);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(x => x.VatNumber == options.VatNumber);
            }

            if (options.CreatedFrom != null)
            {
                query = query.Where(x => x.Created >= options.CreatedFrom);
            }

            if (options.CreatedTo != null)
            {
                query = query.Where(x => x.Created <= options.CreatedTo);
            }

            if (options.IsActive != null)
            {
                query = query.Where(x => x.IsActive == options.IsActive);
            }

            return query;
        }

        public Customer UpdateCustomer(UpdateCustomerOptions options)
        {

            if (options == null || options.CustomerId == null)
            {
                return null;
            }
            var customer = context_
                .Set<Customer>()
                .Where(x => x.CustomerId == options.CustomerId)
                .SingleOrDefault();

            if (customer == null)
            {
                return null;
            }

            if (options.Email != null)
            {
                customer.Email = options.Email;
            }

            if (options.FirstName != null)
            {
                customer.FirstName = options.FirstName;
            }

            if (options.LastName != null)
            {
                customer.LastName = options.LastName;
            }

            if (options.Phone != null)
            {
                customer.Phone = options.Phone;
            }

            if (options.IsActive != null)
            {
                customer.IsActive = (bool)options.IsActive;
            }

            return context_.SaveChanges() > 0 ? customer : null;
        }

        public Customer GetCustomerById(int? id)
        {
            if (id == null) return null;

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            return query
                      .Where(x => x.CustomerId == id)
                      .SingleOrDefault();
        }
    }

}
