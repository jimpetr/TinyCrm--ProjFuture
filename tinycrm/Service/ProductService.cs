using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using tinycrm.UpdateOptions;
using TinyCrm;

namespace tinycrm
{
    public class ProductService : IProductService
    {
        private TinyCrmDbContext context_;
        public ProductService(TinyCrmDbContext context)
        {
            context_ = context;
        }
        public IQueryable<Product> SearchProduct(SearchProductsOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Product>()
                .AsQueryable();


            if (options.Category != null)
            {
                query = query.Where(x => x.Category == options.Category);
            }

            if (options.Description != null)
            {
                query = query.Where(x => x.Description == options.Description);
            }

            if (options.Name != null)
            {
                query = query.Where(x => x.Name == options.Name);
            }

            if (options.PriceFrom != null)
            {
                query = query.Where(x => x.Price >= options.PriceFrom);
            }

            if (options.PriceTo != null)
            {
                query = query.Where(x => x.Price <= options.PriceTo);
            }

            if (options.ProductId != null)
            {
                query = query.Where(x => x.ProductId == options.ProductId);
            }

            return query;
        }

        public Product CreateProduct(CreateProductOptions options)
            {
                if (options == null || options.ProductId == null) return null;

                var checkForExistingProduct = context_
                    .Set<Product>()
                    .Where(x => x.ProductId == options.ProductId)
                    .SingleOrDefault();

                if (checkForExistingProduct != null)
                    throw new Exception("This product already exists.");

                var product = new Product()
                {
                    ProductId = options.ProductId,
                    Description = options.Description,
                    Name = options.Name,
                };
                if (options.Category != null)
                {
                    product.Category = (ProductCategory)options.Category;
                }

                if (options.Price != null)
                {
                    product.Price = (decimal)options.Price;
                }

                context_.Add(product);

                return context_.SaveChanges() > 0 ? product : null;
            }

        public Product UpdateProduct(UpdateProductOptions options)
        {
            if (options == null || options.ProductId == null)
            {
                return null;
            }

            var product = context_
                .Set<Product>()
                .Where(x => x.ProductId == options.ProductId)
                .SingleOrDefault();

            if (product == null)
            {
                return null;
            }

            if (options.Category != null)
            {
                product.Category = (ProductCategory)options.Category;
            }

            if (options.Description != null)
            {
                product.Description = options.Description;
            }

            if (options.Name != null)
            {
                product.Name = options.Name;
            }

            if (options.Price != null)
            {
                product.Price = (decimal)options.Price;
            }

            return context_.SaveChanges() > 0 ? product : null;
        }

        public Product GetProductById(string id)
        {
            if (id == null)
            {
                return null;
            }

            return context_
                .Set<Product>()
                .Where(x => x.ProductId == id)
                .SingleOrDefault();
        }



    }
    
}
