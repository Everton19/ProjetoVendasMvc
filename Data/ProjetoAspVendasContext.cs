using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAspVendas.Models
{
    public class ProjetoAspVendasContext : DbContext
    {
        public ProjetoAspVendasContext (DbContextOptions<ProjetoAspVendasContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoAspVendas.Models.Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistroVendas> RegistroVendas { get; set; }
    }
}