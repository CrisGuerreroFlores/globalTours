using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllsAsync();
        Task<T> GetSpecification(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetAllsSpecification(ISpecification<T> specification);
    }
}