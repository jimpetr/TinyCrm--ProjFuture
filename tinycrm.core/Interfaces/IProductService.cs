using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tinycrm.core.model;
using tinycrm.core.services.Options;
using tinycrm.tinycrm.core.services.Options;

namespace tinycrm.core.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> SearchProduct(SearchProductsOptions options);
        Product CreateProduct(CreateProductOptions options);
        Product UpdateProduct(UpdateProductOptions options);
        Product GetProductById(string id);
    }
}
