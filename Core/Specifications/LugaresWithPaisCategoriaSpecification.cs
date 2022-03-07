using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Specifications
{
    public class LugaresWithPaisCategoriaSpecification : SpecificationBase<Lugar>
    {
        public LugaresWithPaisCategoriaSpecification()
        {
            AddInclude(x => x.Pais);
            AddInclude(x => x.Categoria);
        }

        public LugaresWithPaisCategoriaSpecification(int id) : base(x => x.Id==id)
        {
            AddInclude(x => x.Pais);
            AddInclude(x => x.Categoria);
        }
    }
}