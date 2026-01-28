using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using SignalRWebUI.Dtos.BookingDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7171/api/Booking", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorContent = await response.Content.ReadAsStringAsync();

            var validationErrors = JsonConvert.DeserializeObject<ApiValidationErrorResponse>(errorContent);

            foreach (var error in validationErrors.Errors)
            {
                foreach (var message in error.Value)
                {
                    ModelState.AddModelError(error.Key, message);
                }
            }

            return View(createBookingDto);
        }
        public class ApiValidationErrorResponse
        {
            public Dictionary<string, string[]> Errors { get; set; }
        }

    }
}
