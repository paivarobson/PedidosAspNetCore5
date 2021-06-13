using Microsoft.AspNetCore.Mvc;

namespace PedidosAspNetCore5.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return base.View(Models.Produto.Listagem);
        }
    }
}