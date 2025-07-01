﻿using Coding_Task_Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Coding_Task_Api.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context) { _context = context; }
        public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
    }
}
