using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence
{
    public class FaturamentoPersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public FaturamentoPersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Faturamento?> GetFaturaByIdAsync(int id)
        {
            IQueryable<Faturamento> query = _context.Faturamento
                                        .Include(f => f.Concessionaria)
                                        .Include(f => f.Montadora)
                                        .Include(f => f.Pedidos);

            query = query
                .OrderBy(f => f.Id)
                .Where(f => f.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Faturamento[]> GetFaturaByConcessionariaIdAsync(int idConcessionaria)
        {
            IQueryable<Faturamento> query = _context.Faturamento
                                        .Include(f => f.Montadora)
                                        .Include(f => f.Concessionaria)
                                        .Include(f => f.Pedidos);

            query = query
                .OrderBy(f => f.DataFatura)
                .Where(f => f.ConcessionariaId == idConcessionaria);

            return await query.ToArrayAsync();
        }
        public async Task<Faturamento?> GetFaturaByConcIdYearMonthAsync(int idConcessionaria, int ano, int mes)
        {
            IQueryable<Faturamento> query = _context.Faturamento
                                        .Include(f => f.Pedidos);

            query = query
                .OrderBy(f => f.DataFatura)
                .Where(f => f.ConcessionariaId == idConcessionaria)
                .Where(f => f.DataFatura.Year == ano)
                .Where(f => f.DataFatura.Month == mes);

            return await query.FirstOrDefaultAsync();
        }
    }
}