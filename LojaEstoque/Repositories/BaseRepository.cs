using LojaEstoque.Data;
using LojaEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaEstoque.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
    }
}
