using TusklaBlazor.Server.Interfaces;
using TusklaBlazor.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Services
{
    public class VehicleOrderItemsManager : IVehicleOrderItems
    {
        readonly DatabaseContext _dbContext;

        public VehicleOrderItemsManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<VehicleOrderItems> GetVehicleOrderItems()
        {
            try
            {
                return _dbContext.VehicleOrderItems.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddVehicleOrderItem(VehicleOrderItems vehicleOrderItem)
        {
            try
            {
                _dbContext.VehicleOrderItems.Add(vehicleOrderItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateVehicleOrderItemDetails(VehicleOrderItems vehicleOrderItem)
        {
            try
            {
                _dbContext.Entry(vehicleOrderItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public VehicleOrderItems GetVehicleOrderItemData(int? orderId)
        {
            try
            {
                VehicleOrderItems? orderItem = _dbContext.VehicleOrderItems.Find(orderId);

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

        public void DeleteVehicleOrderItem(int? orderId)
        {
            try
            {
                VehicleOrderItems? orderItem = _dbContext.VehicleOrderItems.Find(orderId);

                if (orderItem != null)
                {
                    _dbContext.VehicleOrderItems.Remove(orderItem);
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