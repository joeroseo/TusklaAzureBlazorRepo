using TusklaBlazor.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOrderItemsController : ControllerBase
    {
        private readonly IVehicleOrderItems _IVehicleOrderItems;

        public VehicleOrderItemsController(IVehicleOrderItems iVehicleOrderItems)
        {
            _IVehicleOrderItems = iVehicleOrderItems;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VehicleOrderItems> vehicleOrderItems = _IVehicleOrderItems.GetVehicleOrderItems();
            return Ok(vehicleOrderItems);
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(int? orderId)
        {
            VehicleOrderItems vehicleOrderItem = _IVehicleOrderItems.GetVehicleOrderItemData(orderId);
            if (vehicleOrderItem != null)
            {
                return Ok(vehicleOrderItem);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(VehicleOrderItems vehicleOrderItem)
        {
            _IVehicleOrderItems.AddVehicleOrderItem(vehicleOrderItem);
        }

        [HttpPut]
        public void Put(VehicleOrderItems vehicleOrderItem)
        {
            _IVehicleOrderItems.UpdateVehicleOrderItemDetails(vehicleOrderItem);
        }

        [HttpDelete("{orderId}")]
        public IActionResult Delete(int? orderId)
        {
            _IVehicleOrderItems.DeleteVehicleOrderItem(orderId);
            return Ok();
        }
    }
}

