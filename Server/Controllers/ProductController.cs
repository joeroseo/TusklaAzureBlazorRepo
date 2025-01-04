using TusklaBlazor.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TusklaBlazor.Server.Models;
using TusklaBlazor.Shared.Models;

namespace TusklaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Product> productList = _productManager.GetProducts();
            return Ok(productList);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            Product product = _productManager.GetProductData(productId);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                int productId = _productManager.AddProduct(product);
                return Ok(productId);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public void Put(Product product)
        {
            _productManager.UpdateProductDetails(product);
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            _productManager.DeleteProduct(productId);
            return Ok();
        }
    }
}
