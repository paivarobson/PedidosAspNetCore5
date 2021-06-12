using Microsoft.AspNetCore.Mvc;

namespace PedidosAspNetCore5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}