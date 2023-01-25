using LojaEstoque.Models;
using LojaEstoque.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaEstoque.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(ILogger<HomeController> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            TempData["mensagem"] = HttpContext.Session.GetString("mensagem");
            HttpContext.Session.SetString("mensagem", "");
            return View(await _produtoRepository.GetAllProdutos());
        }

        public async Task<IActionResult> Cadastro(int id)
        {
            var produto = new Produto();
            var produtoDB = await _produtoRepository.GetProduto(id);

            if (produtoDB is not null) produto = produtoDB;

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertUpdate(Produto produto)
        {   
            var mensagem = "";
            var produtoDb = await _produtoRepository.GetProduto(produto.Id);
                if(produtoDb is null)
            {
                mensagem = await _produtoRepository.CadastraProduto(produto);
                HttpContext.Session.SetString("mensagem", mensagem);
                return RedirectToAction("Index");
            }
            mensagem = await _produtoRepository.UpdateProduto(produto.Id, produto.Nome, produto.Valor);
            HttpContext.Session.SetString("mensagem", mensagem);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}