﻿using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            #region İstatistik1
        var responseMessage = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.CarCount;
            }
            #endregion

            #region İstatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:7154/api/Statistics/GetLocationCount");

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
            }
            #endregion

            #region İstatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:7154/api/Statistics/GetBrandCount");

            if (responseMessage3.IsSuccessStatusCode)
            {
         
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.brandCount = values3.BrandCount;
      
            }
            #endregion

            #region İstatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:7154/api/Statistics/GetCarCountByElectric");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.carCountByElectric = values4.CarCountByElectric;
            }
            #endregion
            return View();
        }
    }
}
