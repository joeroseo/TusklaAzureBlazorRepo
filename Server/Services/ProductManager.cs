using TusklaBlazor.Server.Interfaces;
using TusklaBlazor.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TusklaBlazor.Server.Services;
using TusklaBlazor.Shared.Models;

namespace TusklaBlazor.Server.Services
{
    public class ProductManager : IProductManager
    {
        readonly DatabaseContext _dbContext;

        public ProductManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddProduct(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return product.ProductId;
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProductDetails(Product product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Product GetProductData(int productId)
        {
            try
            {
                Product product = _dbContext.Products.Find(productId);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                Product product = _dbContext.Products.Find(productId);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
