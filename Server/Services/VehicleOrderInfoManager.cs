using TusklaBlazor.Server.Interfaces;
using TusklaBlazor.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Services
{
    public class VehicleOrderInfoManager : IVehicleOrderInfo
    {
        readonly DatabaseContext _dbContext;

        public VehicleOrderInfoManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<VehicleOrderInfo> GetVehicleOrderInfo()
        {
            try
            {
                return _dbContext.VehicleOrderInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddVehicleOrderInfo(VehicleOrderInfo vehicleOrderInfo)
        {
            try
            {
                _dbContext.VehicleOrderInfo.Add(vehicleOrderInfo);
                _dbContext.SaveChanges();
                return vehicleOrderInfo.OrderId; // Return the OrderId
            }
            catch
            {
                throw;
            }
        }

        public void UpdateVehicleOrderInfoDetails(VehicleOrderInfo vehicleOrderInfo)
        {
            try
            {
                _dbContext.Entry(vehicleOrderInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public VehicleOrderInfo GetVehicleOrderInfoData(int orderId)
        {
            try
            {
                VehicleOrderInfo? orderInfo = _dbContext.VehicleOrderInfo.Find(orderId);

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

        public void DeleteVehicleOrderInfo(int orderId)
        {
            try
            {
                VehicleOrderInfo? orderInfo = _dbContext.VehicleOrderInfo.Find(orderId);

                if (orderInfo != null)
                {
                    _dbContext.VehicleOrderInfo.Remove(orderInfo);
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

