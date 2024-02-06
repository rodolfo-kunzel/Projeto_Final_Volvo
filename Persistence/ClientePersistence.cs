using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ContextDB;

namespace Persistence
{
    public class ClientePersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public ClientePersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Cliente[]> GetAllClientesAsync()
        {
            IQueryable<Cliente> query = _context.Clientes
                            .Include(c => c.Pedidos)
                            .Include(c => c.Endereco);

            query = query
                .OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            IQueryable<Cliente> query = _context.Clientes
                            .Include(c => c.Pedidos)
                            .Include(c => c.Endereco);

            query = query
                .OrderBy(c => c.Id)
                .Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente?> GetClienteByNumeroDocumentoAsync(string numeroDocumento)
        {
            IQueryable<Cliente> query = _context.Clientes
                            .Include(c => c.Pedidos)
                            .Include(c => c.Endereco);

            query = query
                .OrderBy(c => c.NumeroDocumento)
                .Where(c => c.NumeroDocumento == numeroDocumento);

            return await query.FirstOrDefaultAsync();
        }
    }
}