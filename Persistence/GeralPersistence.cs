using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.ContextDB;

namespace Persistence
{
    public class GeralPersistence
    {
        public readonly ProjetoFinalDBContext _context;
        public GeralPersistence(ProjetoFinalDBContext _context)
        {
            this._context = _context;
        }
    }
}