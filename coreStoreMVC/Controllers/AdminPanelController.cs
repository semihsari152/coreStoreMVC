using coreStoreMVC.Models.Product.response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace coreStoreMVC.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminPanelController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyProducts()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44350");

                var response =  client.GetAsync("/api/product/get").Result;
                
                if (response.IsSuccessStatusCode)
                {
                    var responseContent =  response.Content.ReadAsStringAsync().Result;
                    var productList = JsonConvert.DeserializeObject<List<ProductResponseModel>>(responseContent);

                    return View(productList);
                }
                else
                {
                    // Başarısız durumu işleyin
                    ViewBag.ErrorMessage = "HTTP isteği başarısız. Durum Kodu: " + (int)response.StatusCode;

                    // API'den gelen içeriği göster
                    var responseContent =  response.Content.ReadAsStringAsync();
                    ViewBag.ErrorContent = responseContent;

                    return View();
                }
        }
    }
}