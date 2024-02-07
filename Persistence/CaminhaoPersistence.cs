using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence
{
    public class CaminhaoPersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public CaminhaoPersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Caminhao[]> GetAllCaminhoesAsync()
        {
            IQueryable<Caminhao> query = _context.Caminhoes
                            .Include(c => c.Modelo)
                            .Include(c => c.Montadora)
                            .Include(c => c.Concessionaria);

            query = query
                .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Caminhao?> GetCaminhaoByIdAsync(int id, bool includeModelo = true, bool includeMontadora = true, bool includeConcessionaria = true)
        {
            IQueryable<Caminhao> query = _context.Caminhoes;

            if(includeModelo) query.Include(c => c.Modelo);
            if(includeMontadora) query.Include(c => c.Montadora);
            if(includeConcessionaria) query.Include(c => c.Concessionaria);

            query = query
                .OrderBy(c => c.Id)
                .Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Caminhao?> GetCaminhaoByNumeroChassiAsync(string numeroChassi)
        {
            IQueryable<Caminhao> query = _context.Caminhoes
                            .Include(c => c.Modelo)
                            .Include(c => c.Montadora)
                            .Include(c => c.Concessionaria);

            query = query
                .OrderBy(c => c.NumeroChassi)
                .Where(c => c.NumeroChassi == numeroChassi);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Caminhao?> GetCaminhaoByModeloAsync(ModeloCaminhao modelo)
        {
            IQueryable<Caminhao> query = _context.Caminhoes
                            .Include(c => c.Modelo)
                            .Include(c => c.Montadora)
                            .Include(c => c.Concessionaria);

            query = query
                .OrderBy(c => c.ModeloId)
                .Where(c => c.ModeloId == modelo.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Caminhao[]> GetCaminhaoByRangePriceAsync(double minValue, double maxValue)
        {
            IQueryable<Caminhao> query = _context.Caminhoes
                            .Include(c => c.Modelo)
                            .Include(c => c.Montadora)
                            .Include(c => c.Concessionaria);

            query = query
                .OrderBy(c => c.Valor)
                .Where(c => c.Valor >= minValue && c.Valor <= maxValue);

            return await query.ToArrayAsync();
        }
    }
}