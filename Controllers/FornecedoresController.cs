using Microsoft.AspNetCore.Mvc;
using PedidosAspNetCore5.Models;
using System.Linq;

namespace PedidosAspNetCore5.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly DataDbContext db;

        public FornecedoresController(DataDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return base.View(db.Fornecedores.ToList().AsQueryable());
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && db.Fornecedores.ToList().AsQueryable().Any(u => u.FornecedorId == id))
            {
                var fornecedor = db.Fornecedores.ToList().AsQueryable().Single(u => u.FornecedorId == id);
                return base.View(fornecedor);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Fornecedor fornecedor)
        {
            db.Fornecedores.Add(fornecedor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id.HasValue && db.Fornecedores.ToList().AsQueryable().Any(u => u.FornecedorId == id))
            {
                var fornecedor = db.Fornecedores.ToList().AsQueryable().Single(u => u.FornecedorId == id);

                return base.View(fornecedor);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(Fornecedor fornecedor)
        {
            db.Fornecedores.Update(fornecedor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && db.Fornecedores.ToList().AsQueryable().Any(u => u.FornecedorId == id))
            {
                var fornecedor = db.Fornecedores.ToList().AsQueryable().Single(u => u.FornecedorId == id);
                return base.View(fornecedor);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(Fornecedor fornecedor)
        {
            db.Fornecedores.Remove(fornecedor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}