using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Interfaces
{
    public interface IVehicleOrderItems
    {
        List<VehicleOrderItems> GetVehicleOrderItems();

        void AddVehicleOrderItem(VehicleOrderItems vehicleOrderItem);

        void UpdateVehicleOrderItemDetails(VehicleOrderItems vehicleOrderItem);

        VehicleOrderItems GetVehicleOrderItemData(int? orderId);

        void DeleteVehicleOrderItem(int? orderId);
    }
}
