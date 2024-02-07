using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence
{
    public class PedidoPersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public PedidoPersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Pedido[]> GetAllPedidosAsync()
        {
            IQueryable<Pedido> query = _context.Pedidos
                            .Include(p => p.Cliente)
                            .Include(c => c.Caminhoes);


            query = query
                .OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Pedido?> GetPedidoByIdAsync(int id)
        {
            IQueryable<Pedido> query = _context.Pedidos
                            .Include(p => p.Cliente)
                            .Include(p => p.Caminhoes);

            query = query
                .OrderBy(p => p.Id)
                .Where(p => p.Id == id);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<Pedido?> GetPedidoByDateAsync(DateTime date)
        {
            IQueryable<Pedido> query = _context.Pedidos
                            .Include(p => p.Cliente);

            query = query
                .OrderBy(p => p.DataAbertura)
                .Where(p => p.DataAbertura == date);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pedido[]> GetPedidoByDateRangeAsync(DateTime minDate, DateTime maxDate)
        {
            IQueryable<Pedido> query = _context.Pedidos
                            .Include(p => p.Cliente);

            query = query
                .OrderBy(p => p.DataAbertura)
                .Where(p => p.DataAbertura >= minDate && p.DataAbertura <= maxDate);

            return await query.ToArrayAsync();
        }
    }
}