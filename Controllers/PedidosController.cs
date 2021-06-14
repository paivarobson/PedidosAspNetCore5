using Microsoft.AspNetCore.Mvc;
using PedidosAspNetCore5.Models;
using System.Linq;

namespace PedidosAspNetCore5.Controllers
{

    public class PedidosController : Controller
    {
        private readonly DataDbContext db;

        public PedidosController(DataDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return base.View(db.Pedidos.ToList().AsQueryable());
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && db.Pedidos.ToList().AsQueryable().Any(u => u.PedidoId == id))
            {
                var pedido = db.Pedidos.ToList().AsQueryable().Single(u => u.PedidoId == id);
                return base.View(pedido);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Pedido pedido)
        {
            db.Pedidos.Add(pedido);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id.HasValue && db.Pedidos.ToList().AsQueryable().Any(u => u.PedidoId == id))
            {
                var pedido = db.Pedidos.ToList().AsQueryable().Single(u => u.PedidoId == id);

                return base.View(pedido);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(Pedido pedido)
        {
            db.Pedidos.Update(pedido);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && db.Pedidos.ToList().AsQueryable().Any(u => u.PedidoId == id))
            {
                var pedido = db.Pedidos.ToList().AsQueryable().Single(u => u.PedidoId == id);
                return base.View(pedido);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(Pedido pedido)
        {
            db.Pedidos.Remove(pedido);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}