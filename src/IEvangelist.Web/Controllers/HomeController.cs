using Microsoft.AspNetCore.Mvc;

namespace IEvangelistWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}