using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Interfaces
{
    public interface IVehicleOrderInfo
    {
        List<VehicleOrderInfo> GetVehicleOrderInfo();

        int AddVehicleOrderInfo(VehicleOrderInfo vehicleOrderInfo); // Change return type to int

        void UpdateVehicleOrderInfoDetails(VehicleOrderInfo vehicleOrderInfo);

        VehicleOrderInfo GetVehicleOrderInfoData(int orderId);

        void DeleteVehicleOrderInfo(int orderId);
    }
}
