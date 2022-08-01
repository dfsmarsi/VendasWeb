using System.Collections.Generic;
using System.Linq;
using VendasWeb.Models;

namespace VendasWeb.Services
{
    public class VendedorService
    {
        private readonly VendasWebContext _context;

        public VendedorService(VendasWebContext context)
        {
            _context = context;
        }

        public List<Vendedor> ProcurarTodos()
        {
            return _context.Vendedor.ToList();
        }

        public void InserirVendedor(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }
    }
}
