using TusklaBlazor.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderInfoController : ControllerBase
    {
        private readonly IProductOrderInfo _IProductOrderInfo;

        public ProductOrderInfoController(IProductOrderInfo iProductOrderInfo)
        {
            _IProductOrderInfo = iProductOrderInfo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ProductOrderInfo> productOrderInfoList = _IProductOrderInfo.GetProductOrderInfo();
            return Ok(productOrderInfoList);
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(int orderId)
        {
            ProductOrderInfo productOrderInfo = _IProductOrderInfo.GetProductOrderInfoData(orderId);
            if (productOrderInfo != null)
            {
                return Ok(productOrderInfo);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(ProductOrderInfo productOrderInfo)
        {
            try
            {
                int orderId = _IProductOrderInfo.AddProductOrderInfo(productOrderInfo);
                return Ok(orderId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public void Put(ProductOrderInfo productOrderInfo)
        {
            _IProductOrderInfo.UpdateProductOrderInfoDetails(productOrderInfo);
        }

        [HttpDelete("{orderId}")]
        public IActionResult Delete(int orderId)
        {
            _IProductOrderInfo.DeleteProductOrderInfo(orderId);
            return Ok();
        }
    }
}
