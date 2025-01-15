using TusklaBlazor.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOrderInfoController : ControllerBase
    {
        private readonly IVehicleOrderInfo _IVehicleOrderInfo;

        public VehicleOrderInfoController(IVehicleOrderInfo iVehicleOrderInfo)
        {
            _IVehicleOrderInfo = iVehicleOrderInfo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VehicleOrderInfo> vehicleOrderInfoList = _IVehicleOrderInfo.GetVehicleOrderInfo();
            return Ok(vehicleOrderInfoList);
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(int orderId)
        {
            VehicleOrderInfo vehicleOrderInfo = _IVehicleOrderInfo.GetVehicleOrderInfoData(orderId);
            if (vehicleOrderInfo != null)
            {
                return Ok(vehicleOrderInfo);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(VehicleOrderInfo vehicleOrderInfo)
        {
            try
            {
                int orderId = _IVehicleOrderInfo.AddVehicleOrderInfo(vehicleOrderInfo);
                return Ok(orderId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public void Put(VehicleOrderInfo vehicleOrderInfo)
        {
            _IVehicleOrderInfo.UpdateVehicleOrderInfoDetails(vehicleOrderInfo);
        }

        [HttpDelete("{orderId}")]
        public IActionResult Delete(int orderId)
        {
            _IVehicleOrderInfo.DeleteVehicleOrderInfo(orderId);
            return Ok();
        }
    }
}
