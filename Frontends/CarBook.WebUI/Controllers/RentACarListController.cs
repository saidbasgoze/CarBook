using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
	public class RentACarListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RentACarListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

        public async Task<IActionResult> Index(int id)
        {
            var locationId = TempData["locationId"];
            if (locationId == null)
            {
                // Hata yönetimi veya varsayılan bir değer ayarlama
                // Örneğin:
                return BadRequest("LocationId cannot be null");
            }

            id = int.Parse(locationId.ToString());
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:7154/api/RentACars?LocationId={id}&Available=true";
            var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
