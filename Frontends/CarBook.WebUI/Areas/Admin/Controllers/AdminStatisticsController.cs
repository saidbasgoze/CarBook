using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminStatisticsController : Controller
    {
       
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {

            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region İstatistik1
            var responseMessage = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.CarCount;
                ViewBag.CarCountRandom = v1;
            }
            #endregion

            #region İstatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:7154/api/Statistics/GetLocationCount");
            
            if (responseMessage2.IsSuccessStatusCode)
            {
                int v2 = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
                ViewBag.LocationCountRandom = v2;
            }
            #endregion

            #region İstatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:7154/api/Statistics/GetAuthorCount");

            if (responseMessage3.IsSuccessStatusCode)
            {
                int v3 = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.authorCount = values3.AuthorCount;
                ViewBag.authorCountRandom = v3;
            }
            #endregion

            #region İstatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:7154/api/Statistics/GetBlogCount");

            if (responseMessage4.IsSuccessStatusCode)
            {
                int v4 = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = values4.BlogCount;
                ViewBag.blogCountRandom = v4;
            }
            #endregion

            #region İstatistik5
            var responseMessage5 = await client.GetAsync("https://localhost:7154/api/Statistics/GetBrandCount");

            if (responseMessage5.IsSuccessStatusCode)
            {
                int v5 = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = values5.BrandCount;
                ViewBag.brandCountRandom = v5;
            }
            #endregion

            #region İstatistik6
            var responseMessage6 = await client.GetAsync("https://localhost:7154/api/Statistics/GetAvgRentPriceForDaily");

            if (responseMessage6.IsSuccessStatusCode)
            {
                int v6 = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.avgRentPriceForDaily = values6.AvgPriceForDaily.ToString("0.00");
                ViewBag.avgRentPriceForDailyRandom = v6;
            }
            #endregion

            #region İstatistik7
            var responseMessage7 = await client.GetAsync("https://localhost:7154/api/Statistics/GetAvgRentPriceForWeekly");

            if (responseMessage7.IsSuccessStatusCode)
            {
                int v7 = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = values7.AvgPriceForWeekly.ToString("0.00");
                ViewBag.avgRentPriceForWeeklyRandom = v7;
            }
            #endregion

            #region İstatistik8
            var responseMessage8 = await client.GetAsync("https://localhost:7154/api/Statistics/GetAvgRentPriceForMonthly");

            if (responseMessage8.IsSuccessStatusCode)
            {
                int v8 = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.avgRentPriceForMonthly = values8.AvgPriceForMonthly.ToString("0.00");
                ViewBag.avgRentPriceForMonthlyRandom = v8;
            }
            #endregion

            #region İstatistik9
            var responseMessage9 = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarCountByTransmissionIsAuto\r\n");

            if (responseMessage9.IsSuccessStatusCode)
            {
                int v9 = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountByTransmissionIsAuto = values9.CarCountByTransmissionIsAuto;
                ViewBag.carCountByTransmissionIsAutoRandom = v9;
            }
            #endregion

            #region İstatistik10
            var responseMessage10 = await client.GetAsync("https://localhost:7154/api/Statistics/GetBrandNameByMaxCar");

            if (responseMessage10.IsSuccessStatusCode)
            {
                int v10 = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.brandNameByMaxCar = values10.BrandNameByMaxCar;
                ViewBag.brandNameByMaxCarRandom = v10;
            }
            #endregion

            #region İstatistik11
            var responseMessage11 = await client.GetAsync("https://localhost:7154/api/Statistics/GetBlogTitleByMaxBlogComment");

            if (responseMessage11.IsSuccessStatusCode)
            {
                int v11 = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.blogTitleByMaxBlogComment = values11.BlogTitleByMaxBlogComment;
                ViewBag.blogTitleByMaxBlogCommentRandom = v11;
            }
            #endregion

            #region İstatistik12
            var responseMessage12 = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarCountByKmSmallerThan1000");

            if (responseMessage12.IsSuccessStatusCode)
            {
                int v12 = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carCountByKmSmallerThan1000 = values12.CarCountByKmSmallerThan1000;
                ViewBag.carCountByKmSmallerThan1000Random = v12;
            }
            #endregion

            #region İstatistik13
            var responseMessage13 = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarCountByGasolineOrDiesel");

            if (responseMessage13.IsSuccessStatusCode)
            {
                int v13 = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.carCountByGasolineOrDiesel = values13.CarCountByGasolineOrDiesel;
                ViewBag.carCountByGasolineOrDieselRandom = v13;
            }
            #endregion

            #region İstatistik14
            var responseMessage14 = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarCountByElectric");

            if (responseMessage14.IsSuccessStatusCode)
            {
                int v14 = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.carCountByElectric = values14.CarCountByElectric;
                ViewBag.carCountByElectricRandom = v14;
            }
            #endregion

            #region İstatistik15
            var responseMessage15 = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");

            if (responseMessage15.IsSuccessStatusCode)
            {
                int v15 = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values15.CarBrandAndModelByRentPriceDailyMax;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = v15;
            }
            #endregion

            #region İstatistik16
            var responseMessage16 = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");

            if (responseMessage16.IsSuccessStatusCode)
            {
                int v16 = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values16.CarBrandAndModelByRentPriceDailyMin;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = v16;
            }
            #endregion


            return View();
        }
    }
}
