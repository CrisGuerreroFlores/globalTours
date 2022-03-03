using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repository
{
    public class LugarRepository : ILugarRepository
    {
        private readonly ApplicationDbContext _db;
        public LugarRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public async Task<Lugar> GetLugarAsync(int id)
        {
            return await _db.Lugar
                                  .Include(p => p.Pais)
                                  .Include(c => c.Categoria)
                                  .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
        {
            return await _db.Lugar
                                  .Include(p => p.Pais)
                                  .Include(c => c.Categoria)
                                  .ToListAsync();
        }
    }
}