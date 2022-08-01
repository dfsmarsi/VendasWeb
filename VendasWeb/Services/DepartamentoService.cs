using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.Services
{ 
    public class DepartamentoService
    {
        private readonly VendasWebContext _context;

        public DepartamentoService(VendasWebContext context)
        {
            _context = context;
        }

        public List<Departamento> ListarDepartamentos()
        {
            return _context.Departamento.OrderBy(dep => dep.Nome).ToList();
    }
    }   
}
