using LojaEstoque.Data;
using LojaEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LojaEstoque.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetAllProdutos();
        Task<Produto?> GetProduto(int id);
        Task<string> UpdateProduto(int id, string nome, decimal valor);
        Task<string> DeleteProduto(int id);
        Task InsereProdutosDB();
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
            var produto = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
            if (produto is null) return $"Não foi possível encontrar o produto de ID nº {id}!";

            produto.Nome = nome;
            produto.Valor = valor;
            await _context.SaveChangesAsync();
            return $"O produto de ID nº {id} foi atualizado!";
        }

        public async Task<string> DeleteProduto(int id)
        {
            var produto = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
            if (produto is null) return $"Produto de ID nº {id} não encontrado";

            _dbSet.Remove(produto);
            await _context.SaveChangesAsync();
            return $"Produto de ID nº {id} removido!";
        }

        public async Task InsereProdutosDB()
        {
            var produtos = await GetProdutosJson();
            if (produtos is null) return;

            foreach (var produto in produtos) 
            {
                if (!await _dbSet.AnyAsync(p => p.Nome == produto.Nome)) 
                    await _dbSet.AddAsync(new Produto(produto.Nome, produto.Valor));
            } 

            await _context.SaveChangesAsync();
        }

        private static async Task<List<ProdutoJson>?> GetProdutosJson()
        {
            var json = await File.ReadAllTextAsync("produtos.json");
            var produtos = JsonConvert.DeserializeObject<List<ProdutoJson>>(json);
            return produtos;
        }
    }

    public class ProdutoJson
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
