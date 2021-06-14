using Microsoft.AspNetCore.Mvc;
using PedidosAspNetCore5.Models;
using System.Collections.Generic;
using System.Linq;

namespace PedidosAspNetCore5.Controllers
{

    public class ProdutosController : Controller
    {

        private readonly DataDbContext db;

        public ProdutosController(DataDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return base.View(db.Produtos.ToList().AsQueryable());
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && db.Produtos.ToList().AsQueryable().Any(u => u.ProdutoId == id))
            {
                var produto = db.Produtos.ToList().AsQueryable().Single(u => u.ProdutoId == id);
                return base.View(produto);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id.HasValue && db.Produtos.ToList().AsQueryable().Any(u => u.ProdutoId == id))
            {
                var produto = db.Produtos.ToList().AsQueryable().Single(u => u.ProdutoId == id);

                return base.View(produto);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            db.Produtos.Update(produto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && db.Produtos.ToList().AsQueryable().Any(u => u.ProdutoId == id))
            {
                var produto = db.Produtos.ToList().AsQueryable().Single(u => u.ProdutoId == id);
                return base.View(produto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(Produto produto)
        {
            db.Produtos.Remove(produto);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}