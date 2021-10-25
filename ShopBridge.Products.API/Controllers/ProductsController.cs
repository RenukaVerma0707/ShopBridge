using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridge.Infrastrusture.Interfaces;
using ShopBridge.Infrastrusture.Models;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridge.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _productsService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProducts productsService, ILogger<ProductsController> logger)
        {
            _productsService = productsService;
            _logger = logger;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productsService.GetProducts();
            if (result != null)
            {
                _logger.LogInformation("getting Product Data");
                return Ok(result);
            }

            else
            {
                _logger.LogError("No products in inventory");
                return NotFound(result);
            }
        }
        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productsService.AddProduct(product);
            if (result != null)
            {
                _logger.LogInformation("Adding Product Data {0}");
                return Ok(result);
            }

            else
            {
                _logger.LogError("Not Found Subscription Details {0}");
                return NotFound(product);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ShopBridge.Infrastrusture.Models.Products product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productsService.UpdateProduct(product);
            if (result != null)
            {
                _logger.LogInformation("Updating Product Data for id {0}", product.ProductId);
                return Ok(result);
            }

            else
            {
                _logger.LogError("Error in Updating Product Data for id {0}", product);
                return StatusCode(StatusCodes.Status404NotFound, "Product Id " + product.ProductId + " Not Found");
            }

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productsService.Delete(id);
            if (result != null)
            {
                _logger.LogInformation("Deleting Product Data {0}", id);
                return Ok(result);
            }
            else
            {
                _logger.LogError("error in deleting data", id);
                return StatusCode(StatusCodes.Status404NotFound, "Product Id " + id + " Not Found");
            }
        }
    }
}
