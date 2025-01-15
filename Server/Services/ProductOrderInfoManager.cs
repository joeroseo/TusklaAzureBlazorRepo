using TusklaBlazor.Server.Interfaces;
using TusklaBlazor.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TusklaBlazor.Server.Services;

namespace TusklaBlazor.Server.Services
{
    public class ProductOrderInfoManager : IProductOrderInfo
    {
        readonly DatabaseContext _dbContext;

        public ProductOrderInfoManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductOrderInfo> GetProductOrderInfo()
        {
            try
            {
                return _dbContext.ProductOrderInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddProductOrderInfo(ProductOrderInfo productOrderInfo)
        {
            try
            {
                _dbContext.ProductOrderInfo.Add(productOrderInfo);
                _dbContext.SaveChanges();
                return productOrderInfo.OrderId; // Return the OrderId
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProductOrderInfoDetails(ProductOrderInfo productOrderInfo)
        {
            try
            {
                _dbContext.Entry(productOrderInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public ProductOrderInfo GetProductOrderInfoData(int orderId)
        {
            try
            {
                ProductOrderInfo? orderInfo = _dbContext.ProductOrderInfo.Find(orderId);

                if (orderInfo != null)
                {
                    return orderInfo;
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

        public void DeleteProductOrderInfo(int orderId)
        {
            try
            {
                ProductOrderInfo? orderInfo = _dbContext.ProductOrderInfo.Find(orderId);

                if (orderInfo != null)
                {
                    _dbContext.ProductOrderInfo.Remove(orderInfo);
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

