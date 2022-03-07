using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LugarDto
    {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public double GastoAproximado { get; set; }
            public string ImagenURL { get; set; }
            public string Pais { get; set; }
            public string Categoria { get; set; }
    
    }
}