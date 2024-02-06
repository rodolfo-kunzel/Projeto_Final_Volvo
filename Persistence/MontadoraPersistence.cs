using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence
{
    public class MontadoraPersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public MontadoraPersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Montadora[]> GetAllMontadorasAsync()
        {
            IQueryable<Montadora> query = _context.Montadoras
                            .Include(m => m.Caminhoes)
                            .Include(m => m.Endereco)
                            .Include(m => m.Faturamento);

            query = query
                .OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Montadora?> GetMontadoraByIdAsync(int id)
        {
            IQueryable<Montadora> query = _context.Montadoras
                            .Include(m => m.Caminhoes)
                            .Include(m => m.Endereco)
                            .Include(m => m.Faturamento);

            query = query
                .OrderBy(m => m.Id)
                .Where(m => m.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Montadora?> GetMontadoraByCNPJAsync(string cnpj)
        {
            IQueryable<Montadora> query = _context.Montadoras
                            .Include(m => m.Caminhoes)
                            .Include(m => m.Endereco)
                            .Include(m => m.Faturamento);

            query = query
                .OrderBy(m => m.CNPJ)
                .Where(m => m.CNPJ == cnpj);

            return await query.FirstOrDefaultAsync();
        }
    }
}