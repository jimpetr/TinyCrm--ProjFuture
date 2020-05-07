using System;
using System.Collections.Generic;
using System.Text;

namespace tinycrm
{
    public class SearchProductsOptions
    {
        public string ProductId {get;set;}
        public decimal PriceFrom {get;set;}
        public decimal PriceTo {get;set;}
        public string Categories {get;set;}
    }
}
