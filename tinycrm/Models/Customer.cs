using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tinycrm
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; set; }
        public bool IsActive { get; set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        public bool IsValidVatNumber(string vat)
        {
            return
                !string.IsNullOrWhiteSpace(vat) &&
                vat.Length == 9;
        }

        public bool IsValidEmail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
            {
                return false;
            }

            mail = mail.Trim();

            if (mail.Contains("@") && mail.EndsWith(".com"))
            {
                var count = mail.Count(x => x == '@');

                return count == 1;
            }
            return false;
        }

        public bool IsAdult(int age)
        {
            return age >= 18 && age <= 100;
        }

        public bool IsValidAFM(string afm)
        {
            if (!string.IsNullOrWhiteSpace(afm))
            {
                return (afm.Trim().Length == 9) && int.TryParse(afm.Trim(), out var _afm);
            }
            return false;
        }
    }
}
