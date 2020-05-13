using System;
using System.Collections.Generic;
using System.Text;
using tinycrm;
using tinycrm.core.model;

namespace tinycrm
{
    public class SearchProductsOptions
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
