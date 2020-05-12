using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tinycrm.UpdateOptions;

namespace tinycrm
{
    public interface IProductService
    {
        IQueryable<Product> SearchProduct(SearchProductsOptions options);
        Product CreateProduct(CreateProductOptions options);
        Product UpdateProduct(UpdateProductOptions options);
        Product GetProductById(string id);
    }
}
