using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        public IActionResult CustomerTableList()
        {
            return View();
        }
    }
}
