using Microsoft.AspNetCore.Mvc;
using PedidosAspNetCore5.Models;
using System.Linq;

namespace PedidosAspNetCore5.Controllers
{

    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return base.View(Models.Pedido.Listagem);
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && Models.Pedido.Listagem.Any(u => u.IdPedido == id))
            {
                var pedido = Models.Pedido.Listagem.Single(u => u.IdPedido == id);
                return base.View(pedido);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            Models.Pedido.Salvar(pedido);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id.HasValue && Models.Pedido.Listagem.Any(u => u.IdPedido == id))
            {
                var pedido = Models.Pedido.Listagem.Single(u => u.IdPedido == id);
                return base.View(pedido);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(Pedido pedido)
        {
            Models.Pedido.Salvar(pedido);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && Models.Pedido.Listagem.Any(u => u.IdPedido == id))
            {
                var pedido = Models.Pedido.Listagem.Single(u => u.IdPedido == id);
                return base.View(pedido);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(Pedido pedido)
        {
            Models.Pedido.Excluir(pedido.IdPedido);
            return RedirectToAction("Index");
        }
    }
}