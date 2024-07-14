using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{

    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7154/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
//    public class _AboutUsComponentPartial : ViewComponent
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var client = _httpClientFactory.CreateClient();
//            var responseMessage = await client.GetAsync("https://localhost:7154/api/Abouts");
//            if (responseMessage.IsSuccessStatusCode)
//            {
//                var jsonData=await responseMessage.Content.ReadAsStringAsync();
//                var values=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
//                //burda maplememiz lazım list icinde ki mesela Id yi nameyi titleyi falan görüp alabilsin.
//                //eşleştirme gibi düşün Dto olusturucaz onun için.
//                return View(values);
//            }
//            return View();
//        }
//    }
//}
