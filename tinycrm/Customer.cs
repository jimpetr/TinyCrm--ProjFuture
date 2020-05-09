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
        private decimal TotalGross { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        //public List<Order> ListOfOrders=new List<Order>() ;

        //public Customer(string vatNumber)
        //{
        //   if (!IsValidVatNumber(vatNumber))
        //  {
        //      throw new Exception("Invalid VatNumber");
        // }

        //  VatNumber = vatNumber;
        // Created = DateTime.Now;
        //}

        //public decimal TotalGross
        //{
        //   get { return _TotalGross = ListOfOrders.Select(x => x.TotalAmount).Sum(); }
        //}

        public bool IsValidVatNumber(string vatNumber)
        {
            return
                !string.IsNullOrWhiteSpace(vatNumber) &&
                vatNumber.Length == 9;
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }
    }
}
