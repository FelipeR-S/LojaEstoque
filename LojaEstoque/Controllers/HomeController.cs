using LojaEstoque.Models;
using LojaEstoque.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaEstoque.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Página inicial
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            TempData["mensagem"] = HttpContext.Session.GetString("mensagem"); //Consome mensagem através de sessão
            HttpContext.Session.SetString("mensagem", ""); //apage mensagem
            return View(await _produtoRepository.GetAllProdutos());
        }

        /// <summary>
        /// Exibe view de Cadastro
        /// </summary>
        /// <param name="id"><see cref="int"/> id de produto editar produto ja cadastrado</param>
        /// <returns></returns>
        public async Task<IActionResult> Cadastro(int id)
        {
            var produto = new Produto();
            var produtoDB = await _produtoRepository.GetProduto(id);

            if (produtoDB is not null) produto = produtoDB;

            return View(produto);
        }

        /// <summary>
        /// Insere novo produto ou atualiza produto já existente
        /// </summary>
        /// <param name="produto"><see cref="Produto"/></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertUpdate(Produto produto)
        {
            var mensagem = "";
            var produtoDb = await _produtoRepository.GetProduto(produto.Id);
            //Cadastra produto caso ele não exista
            if (produtoDb is null)
            {
                mensagem = await _produtoRepository.CadastraProduto(produto);
                HttpContext.Session.SetString("mensagem", mensagem); //Envia mensagem através de sessão
                return RedirectToAction("Index");
            }
            //Atualiza produto caso ele exista
            mensagem = await _produtoRepository.UpdateProduto(produto.Id, produto.Nome, produto.Valor);
            HttpContext.Session.SetString("mensagem", mensagem); //Envia mensagem através de sessão
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deleta produto do banco de dados
        /// </summary>
        /// <param name="id"><see cref="int"/> id do produto</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var mensagem = await _produtoRepository.DeleteProduto(id);
            HttpContext.Session.SetString("mensagem", mensagem); //Envia mensagem através de sessão
            return RedirectToAction("Index");
        }

        //Exibe erros
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}