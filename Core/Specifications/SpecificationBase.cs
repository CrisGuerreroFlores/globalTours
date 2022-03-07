using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class SpecificationBase<T> : ISpecification<T>
    {
        public SpecificationBase(Expression<Func<T, bool>> filter)
        {
            Filter = filter;
        }
        public SpecificationBase()
        {
            
        }

        public Expression<Func<T, bool>> Filter { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}