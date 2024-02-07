using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence
{
    public class ModeloCaminhaoPersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public ModeloCaminhaoPersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<ModeloCaminhao[]> GetAllModeloCaminhoesAsync()
        {
            IQueryable<ModeloCaminhao> query = _context.ModeloCaminhoes;

            query = query
                .OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }
        public async Task<ModeloCaminhao?> GetModeloCaminhaoByIdAsync(int id)
        {
            IQueryable<ModeloCaminhao> query = _context.ModeloCaminhoes;

            query = query
                .OrderBy(m => m.Id)
                .Where(m => m.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}