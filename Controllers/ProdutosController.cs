using Microsoft.AspNetCore.Mvc;
using PedidosAspNetCore5.Models;
using System.Linq;

namespace PedidosAspNetCore5.Controllers
{

    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return base.View(Models.Produto.Listagem);
        }

        [HttpGet]
        public IActionResult Cadastrar(int? id)
        {
            if (id.HasValue && Models.Produto.Listagem.Any(u => u.IdProduto == id))
            {
                var produto = Models.Produto.Listagem.Single(u => u.IdProduto == id);
                return base.View(produto);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            Models.Produto.Salvar(produto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Alterar(int? id)
        {
            if (id.HasValue && Models.Produto.Listagem.Any(u => u.IdProduto == id))
            {
                var produto = Models.Produto.Listagem.Single(u => u.IdProduto == id);
                return base.View(produto);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            Models.Produto.Salvar(produto);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id.HasValue && Models.Produto.Listagem.Any(u => u.IdProduto == id))
            {
                var produto = Models.Produto.Listagem.Single(u => u.IdProduto == id);
                return base.View(produto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Excluir(Produto produto)
        {
            Models.Produto.Excluir(produto.IdProduto);
            return RedirectToAction("Index");
        }
    }
}