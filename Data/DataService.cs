using LojaEstoque.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LojaEstoque.Data
{
    public interface IDataService
    {
        Task InitDB();
    }
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(ApplicationDbContext context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;
        }

        public async Task InitDB()
        {
            await _context.Database.MigrateAsync();
            await _produtoRepository.InsereProdutosDB();
        }
    }
}
