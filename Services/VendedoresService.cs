using System.Collections.Generic;
using System.Linq;
using ProjetoAspVendas.Models;

namespace ProjetoAspVendas.Services
{
    public class VendedoresService
    {
        private readonly ProjetoAspVendasContext _context;

        public VendedoresService(ProjetoAspVendasContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindBybId(int id)
        {
            return _context.Vendedor.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
    }
}