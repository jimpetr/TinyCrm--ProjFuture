using System;
using System.Collections.Generic;
using System.Text;
using tinycrm.core.model;

namespace tinycrm.tinycrm.core.services.Options
{
    public class UpdateProductOptions
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
