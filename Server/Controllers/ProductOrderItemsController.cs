using TusklaBlazor.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TusklaBlazor.Server.Models;

namespace TusklaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderItemsController : ControllerBase
    {
        private readonly IProductOrderItems _IProductOrderItems;

        public ProductOrderItemsController(IProductOrderItems iProductOrderItems)
        {
            _IProductOrderItems = iProductOrderItems;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ProductOrderItems> productOrderItems = _IProductOrderItems.GetProductOrderItems();
            return Ok(productOrderItems);
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(int? orderId)
        {
            List<ProductOrderItems> orderItemsList = _IProductOrderItems.GetProductOrderItems(orderId);
            if (orderItemsList != null)
            {
                return Ok(orderItemsList);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(ProductOrderItems productOrderItem)
        {
            _IProductOrderItems.AddProductOrderItem(productOrderItem);
        }

        [HttpPut]
        public void Put(ProductOrderItems productOrderItem)
        {
            _IProductOrderItems.UpdateProductOrderItemDetails(productOrderItem);
        }

        [HttpDelete("{orderId}")]
        public IActionResult Delete(int? orderId)
        {
            _IProductOrderItems.DeleteProductOrderItem(orderId);
            return Ok();
        }
    }
}

