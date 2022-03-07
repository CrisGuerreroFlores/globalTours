using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    public class EvaluatorSpecifications<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if(specification.Filter != null)
            {
                query = query.Where(specification.Filter);
            }

            query = specification.Includes.Aggregate(query,(current, include) => current.Include(include));

            return query;
        }
    }
}