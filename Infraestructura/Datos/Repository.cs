using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IReadOnlyList<T>> GetAllsAsync()
        {
           return await _db.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
           return await _db.Set<T>().FindAsync(id);
        }        
        public async Task<IReadOnlyList<T>> GetAllsSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<T> GetSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<T>  ApplySpecification(ISpecification<T> specification)
        {
            return EvaluatorSpecifications<T>.GetQuery(_db.Set<T>().AsQueryable(),specification);
        }
    }
}