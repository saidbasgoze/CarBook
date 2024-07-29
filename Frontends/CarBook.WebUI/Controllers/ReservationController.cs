using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralam";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7154/api/Locations");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.LocationID.ToString()
                                                }).ToList();

                ViewBag.v = values2;
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData2 = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client.PostAsync("https://localhost:7154/api/Reservations/", stringContent);
            if (responseMessage2.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Rezervasyon işleminiz başarıyla tamamlandı. E-posta gönderildi, lütfen kontrol edin.";
                return RedirectToAction("Index", "Default");
            }
            TempData["ErrorMessage"] = "Rezervasyon işlemi sırasında bir hata oluştu.";
            return View();
        }
    }
}