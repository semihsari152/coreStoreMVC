using coreStoreAPI.Models;
using coreStoreAPI.Models.Request.Product;
using coreStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace coreStoreAPI.Controllers
{

    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("Insert")]
        public ActionResult<Product> Insert(ProductRequestModel request)
        {
            var newItem = _productService.Insert(request);
            return Ok(newItem);
        }

        [HttpPut("Update")]
        public IActionResult Update(int productId, ProductRequestModel request)
        {
            var updatedProduct = _productService.Update(productId, request);
            if (updatedProduct != null)
            {
                return Ok(updatedProduct);
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

        [HttpGet("GetWomenProducts")]
        public IActionResult GetWomenProducts()
        {
            var products = _productService.GetListByGender("Kadın");
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }


        [HttpGet("get")]
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