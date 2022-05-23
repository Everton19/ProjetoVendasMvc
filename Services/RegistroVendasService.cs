using System;
using System.Collections.Generic;
using ProjetoAspVendas.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjetoAspVendas.Services
{
    public class RegistroVendasService
    {
        private readonly ProjetoAspVendasContext _context;

        public RegistroVendasService(ProjetoAspVendasContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> EncontrarUmaDataAsync(DateTime? dataMin, DateTime? dataMax)
        {
            var resultado = from obj in _context.RegistroVendas select obj;
            if (dataMin.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataMin.Value);
            }

            if (dataMax.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataMax.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, RegistroVendas>>> EncontrarUmaDataEmGrupoAsync(DateTime? dataMin, DateTime? dataMax)
        {
            var resultado = from obj in _context.RegistroVendas select obj;
            if (dataMin.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataMin.Value);
            }

            if (dataMax.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataMax.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}