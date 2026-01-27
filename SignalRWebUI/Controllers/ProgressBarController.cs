using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    [Authorize]
    public class ProgressBarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
