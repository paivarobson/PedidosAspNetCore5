using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedidosAspNetCore5.Models;
using System;
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
        public IActionResult Cadastrar()
        {
            ViewBag.Fornecedores =
                db.Fornecedores.ToList().Select(f => new SelectListItem()
                { Text = f.FornecedorId + " - " + f.RazaoSocial, Value = Convert.ToString(f.FornecedorId) }).ToList();

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
            ViewBag.Fornecedores =
                db.Fornecedores.ToList().Select(f => new SelectListItem()
                { Text = f.FornecedorId + " - " + f.RazaoSocial, Value = Convert.ToString(f.FornecedorId) }).ToList();

            if (id.HasValue && db.Pedidos.ToList().AsQueryable().Any(p => p.PedidoId == id))
            {
                var pedido = db.Pedidos.ToList().AsQueryable().Single(p => p.PedidoId == id);

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
            if (id.HasValue && db.Pedidos.ToList().AsQueryable().Any(p => p.PedidoId == id))
            {
                var pedido = db.Pedidos.ToList().AsQueryable().Single(p => p.PedidoId == id);
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