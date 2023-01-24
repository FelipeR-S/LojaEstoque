﻿using Microsoft.EntityFrameworkCore;

namespace LojaEstoque.Data
{
    public interface IDataService
    {
        Task InitDB();
    }
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;

        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitDB()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
