using System;
using System.Collections.Generic;
using System.Text;

namespace tinycrm
{
    public class SearchCustomerOptions
    {
        public int? CustomerId { get; set; }

        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public decimal? TotalGross { get; set; }
        public bool? IsActive { get; set; }
    }
}
