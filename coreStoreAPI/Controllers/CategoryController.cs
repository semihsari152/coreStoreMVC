using coreStoreAPI.Models.Request.Product;
using coreStoreAPI.Models;
using coreStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using coreStoreAPI.Models.Request.Category;

namespace coreStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("Insert")]
        public ActionResult<Category> Insert([FromBody] CategoryRequestModel request)
        {
            var newItem = _categoryService.Insert(request);

            return Ok(newItem);
        }

        [HttpPut("Update/{categoryId}")]
        public IActionResult Update(int categoryId, [FromBody] CategoryRequestModel request)
        {
            var updatedCategory = _categoryService.Update(categoryId, request);
            if (updatedCategory != null)
            {
                return Ok(updatedCategory);
            }
            return NotFound();
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                var categories = _categoryService.Get();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu." + ex + "");
            }
        }


        [HttpGet("SearchCustomers")]
        public IActionResult SearchCustomers(string searchTerm)
        {
            try
            {
                var categories = _categoryService.SearchProduct(searchTerm);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu." + ex + "");

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
                return Ok("Başarıyla silindi.");
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
    }
}
