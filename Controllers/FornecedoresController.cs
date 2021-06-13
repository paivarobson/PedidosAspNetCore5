using Microsoft.AspNetCore.Mvc;
using PedidosAspNetCore5.Models;
using System.Linq;

namespace PedidosAspNetCore5.Controllers
{

    public class FornecedoresController : Controller
    {
        public IActionResult Index()
        {
            return base.View(Models.Fornecedor.Listagem);
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && Models.Fornecedor.Listagem.Any(u => u.IdFornecedor == id))
            {
                var fornecedor = Models.Fornecedor.Listagem.Single(u => u.IdFornecedor == id);
                return base.View(fornecedor);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Fornecedor fornecedor)
        {
            Models.Fornecedor.Salvar(fornecedor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id.HasValue && Models.Fornecedor.Listagem.Any(u => u.IdFornecedor == id))
            {
                var fornecedor = Models.Fornecedor.Listagem.Single(u => u.IdFornecedor == id);
                return base.View(fornecedor);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(Fornecedor fornecedor)
        {
            Models.Fornecedor.Salvar(fornecedor);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && Models.Fornecedor.Listagem.Any(u => u.IdFornecedor == id))
            {
                var fornecedor = Models.Fornecedor.Listagem.Single(u => u.IdFornecedor == id);
                return base.View(fornecedor);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(Fornecedor fornecedor)
        {
            Models.Fornecedor.Excluir(fornecedor.IdFornecedor);
            return RedirectToAction("Index");
        }
    }
}