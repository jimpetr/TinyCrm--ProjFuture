using System;
using System.Collections.Generic;
using System.Text;

namespace tinycrm
{
    public class Customer
    {
        public string VatNumber { get; private set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }

        public DateTime Created { get; set; }

        public Customer(string vatnumber)
        {
            if (!IsValidVatNumber(vatnumber))
            {
                throw new Exception("Invalid VatNumber");
            }

            VatNumber = vatnumber;
            Created = DateTime.Now;
        }

        public bool IsValidVatNumber(string vatnumber)
        {
            return vatnumber.Length != 9 && !string.IsNullOrWhiteSpace(vatnumber);
        }

        public bool IsValidEmail()
        {
            if (Email.Contains('@') && (Email.EndsWith(".com") || Email.EndsWith(".gr")))
            {
                return true;
            }
            return false;
        }
    }
}
