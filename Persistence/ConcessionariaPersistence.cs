using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence
{
    public class ConcessionariaPersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public ConcessionariaPersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Concessionaria[]> GetAllConcessionariasAsync()
        {
            IQueryable<Concessionaria> query = _context.Concessionarias
                            .Include(c => c.Caminhoes)
                            .Include(c => c.Endereco);

            query = query
                .OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Concessionaria?> GetConcessionariaByIdAsync(int id)
        {
            IQueryable<Concessionaria> query = _context.Concessionarias
                            .Include(c => c.Caminhoes)
                            .Include(c => c.Endereco);

            query = query
                .OrderBy(c => c.Id)
                .Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Concessionaria?> GetConcessionariaByCNPJAsync(string cnpj)
        {
            IQueryable<Concessionaria> query = _context.Concessionarias
                            .Include(c => c.Caminhoes)
                            .Include(c => c.Endereco);

            query = query
                .OrderBy(c => c.CNPJ)
                .Where(c => c.CNPJ == cnpj);

            return await query.FirstOrDefaultAsync();
        }
    }
}