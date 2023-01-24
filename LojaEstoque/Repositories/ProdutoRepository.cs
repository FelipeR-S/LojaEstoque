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
        Task<string> UpdateProduto(int id, string nome);
        Task<string> DeleteProduto(int id);
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

        public async Task<Produto?> GetProduto(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> UpdateProduto(int id, string nome)
        {
            var produto = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
            if (produto is null) return $"Não foi possível alterar O produto de ID nº {id}!";

            produto.Nome = nome;
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

            foreach (var produto in produtos) await _dbSet.AddAsync(produto);

            await _context.SaveChangesAsync();
        }

        private static async Task<List<Produto>?> GetProdutosJson()
        {
            var json = await File.ReadAllTextAsync("produtos.json");
            return JsonConvert.DeserializeObject<List<Produto>>(json);
        }
    }
}
