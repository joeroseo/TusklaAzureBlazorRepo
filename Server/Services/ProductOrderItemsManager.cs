using TusklaBlazor.Server.Interfaces;
using TusklaBlazor.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Services
{
    public class ProductOrderItemsManager : IProductOrderItems
    {
        readonly DatabaseContext _dbContext;

        public ProductOrderItemsManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductOrderItems> GetProductOrderItems()
        {
            try
            {
                return _dbContext.ProductOrderItems.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddProductOrderItem(ProductOrderItems productOrderItem)
        {
            try
            {
                _dbContext.ProductOrderItems.Add(productOrderItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProductOrderItemDetails(ProductOrderItems productOrderItem)
        {
            try
            {
                _dbContext.Entry(productOrderItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public ProductOrderItems GetProductOrderItemData(int? orderId)
        {
            try
            {
                ProductOrderItems? orderItem = _dbContext.ProductOrderItems.Find(orderId);

                if (orderItem != null)
                {
                    return orderItem;
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

        public void DeleteProductOrderItem(int? orderId)
        {
            try
            {
                ProductOrderItems? orderItem = _dbContext.ProductOrderItems.Find(orderId);

                if (orderItem != null)
                {
                    _dbContext.ProductOrderItems.Remove(orderItem);
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

        public List<ProductOrderItems> GetProductOrderItems(int? orderId)
        {
            try
            {
                if (orderId.HasValue)
                {
                    return _dbContext.ProductOrderItems.Where(item => item.OrderId == orderId.Value).ToList();
                }
                else
                {
                    return _dbContext.ProductOrderItems.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}