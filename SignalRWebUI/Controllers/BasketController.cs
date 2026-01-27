using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.BasketDtos;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responeMessage = await client.GetAsync("https://localhost:7171/api/Basket/GetBasketByMenuTableNumber/1");
            if (responeMessage.IsSuccessStatusCode)
            {
                var jsonData = await responeMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketWithProductAndTable>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7171/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }

    }
}
