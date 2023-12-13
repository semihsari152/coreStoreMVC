using coreStoreAPI.Models.Request.Category;
using coreStoreAPI.Models;
using coreStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using coreStoreAPI.Models.Request.Admin;
using coreStoreAPI.Models.Request.Product;

namespace coreStoreAPI.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IProductService _productService;


        public AdminController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("Insert")]
        public ActionResult<Product> Insert([FromBody] ProductRequestModel request)
        {
            var newItem = _productService.Insert(request);

            return Ok(newItem);
        }

        [HttpPut("Update")]
        public IActionResult Update(int productId, [FromBody] ProductRequestModel request)
        {
            var updatedCustomer = _productService.Update(productId, request);
            if (updatedCustomer != null)
            {
                return Ok(updatedCustomer);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok("Müşteri başarıyla silindi.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu." + ex + "");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("Get")]
        public IActionResult GetProduct()
        {
            var product = _productService.GetList();
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
