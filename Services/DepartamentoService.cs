using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoAspVendas.Models;

namespace ProjetoAspVendas.Services
{
    public class DepartamentoService
    {
        private readonly ProjetoAspVendasContext _context;

        public DepartamentoService(ProjetoAspVendasContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}