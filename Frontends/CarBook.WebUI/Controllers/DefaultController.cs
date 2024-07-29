using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
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
			}
			else
			{
				// Hata durumunda varsayılan bir SelectListItem ekleniyor
				ViewBag.v = new List<SelectListItem>
				{
					new SelectListItem
					{
						Text = "Veriler yüklenemedi",
						Value = "0"
					}
				};
			}
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];

            return View();
		}
		[HttpPost]
		public IActionResult Index(string book_pick_date,string book_off_date,string time_pick,string time_pickoff,string locationId)
		{
			TempData["bookpickdate"] = book_pick_date;
			TempData["bookoffdate"] = book_off_date;
			TempData["timepick"] = time_pick;
			TempData["timepickoff"] = time_pickoff;
			TempData["locationId"] = locationId;
			return RedirectToAction("Index", "RentACarList");
		}
	}
}