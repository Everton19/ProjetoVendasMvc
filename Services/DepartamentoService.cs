using System.Collections.Generic;
using System.Linq;
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

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}