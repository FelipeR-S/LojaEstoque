using LojaEstoque.Data;
using LojaEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LojaEstoque.Repositories
{
    public interface IProdutoRepository
    {
        /// <summary>
        /// Busca e retorna todos os produtos do banco de dados
        /// </summary>
        /// <returns><see cref="List{T}"/> de <see cref="Produto"/></returns>
        Task<List<Produto>> GetAllProdutos();

        /// <summary>
        /// Busca um unico produto no banco de dados
        /// </summary>
        /// <param name="id"><see cref="int"/> id do produto</param>
        /// <returns><see cref="Produto"/> ou null caso não seja encontrado</returns>
        Task<Produto?> GetProduto(int id);

        /// <summary>
        /// Atualiza dados de produto existente
        /// </summary>
        /// <param name="id"><see cref="int"/> id do produto</param>
        /// <param name="nome"><see cref="string"/> nome do produto</param>
        /// <param name="valor"><see cref="decimal"/> valor do produto</param>
        /// <returns><see cref="string"/> mensagem de confirmação</returns>
        Task<string> UpdateProduto(int id, string nome, decimal valor);

        /// <summary>
        /// Deleta produto do banco de dados
        /// </summary>
        /// <param name="id"><see cref="int"/> id do produto</param>
        /// <returns><see cref="string"/> mensagem de confirmação</returns>
        Task<string> DeleteProduto(int id);

        /// <summary>
        /// Inicializa banco de dados com produtos adquiridos de arquivo Json
        /// </summary>
        /// <returns></returns>
        Task InsereProdutosDB();

        /// <summary>
        /// Cadastra novo produto no banco de dados
        /// </summary>
        /// <param name="produto"><see cref="Produto"/> novo produto</param>
        /// <returns><see cref="string"/> mensagem de confirmação</returns>
        Task<string> CadastraProduto(Produto produto);
    }
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<string> CadastraProduto(Produto produto)
        {
            if (produto is not null)
            {
                var produtoDB = await _dbSet.FirstOrDefaultAsync(p => p.Nome == produto.Nome);
                //retorna caso produto já existir
                if (produtoDB is not null) return "Não foi possível cadastrar produto!\nProduto já consta na base de dados.";
                await _dbSet.AddAsync(produto);
                await _context.SaveChangesAsync();
                return "Produto Cadastrado";
            }
            return "Ocorreu um erro ao cadastrar o produto!\nFavor tente novamente!";
        }

        public async Task<Produto?> GetProduto(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> UpdateProduto(int id, string nome, decimal valor)
        {
            //cancela caso produto não for encontrado
            var produto = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
            if (produto is null) return $"Não foi possível encontrar o produto de ID nº {id}!";

            produto.Nome = nome;
            produto.Valor = valor;
            await _context.SaveChangesAsync();
            return $"O produto de ID nº {id} foi atualizado!";
        }

        public async Task<string> DeleteProduto(int id)
        {
            //cancela caso produto não for encontrado
            var produto = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
            if (produto is null) return $"Produto de ID nº {id} não encontrado";

            _dbSet.Remove(produto);
            await _context.SaveChangesAsync();
            return $"Produto de ID nº {id} removido!";
        }

        public async Task InsereProdutosDB()
        {
            //cancela caso json não retornar produtos
            var produtos = await GetProdutosJson();
            if (produtos is null) return;

            //Cadastra lista de produtos
            foreach (var produto in produtos) 
            {
                if (!await _dbSet.AnyAsync(p => p.Nome == produto.Nome)) 
                    await _dbSet.AddAsync(new Produto(produto.Nome, produto.Valor));
            } 

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Lê arquivo Json para gerar lista de produtos
        /// </summary>
        /// <returns><see cref="List{T}"/> de <see cref="ProdutoJson"/></returns>
        private static async Task<List<ProdutoJson>?> GetProdutosJson()
        {
            var json = await File.ReadAllTextAsync("produtos.json");
            var produtos = JsonConvert.DeserializeObject<List<ProdutoJson>>(json);
            return produtos;
        }
    }

    /// <summary>
    /// Classe para adquirir produtos de arquivo Json
    /// </summary>
    public class ProdutoJson
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
