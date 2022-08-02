using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.Services
{
    public class PesquisaDeVendasService
    {
        private readonly VendasWebContext _context;

        public PesquisaDeVendasService(VendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> PesquisaPorDatasAsync(DateTime? dataInicio, DateTime? dataFinal)
        {
            var resultado = from obj in _context.Venda select obj;
            if (dataInicio.HasValue)
                resultado = resultado.Where(x => x.DataVenda >= dataInicio.Value);
            if (dataFinal.HasValue)
                resultado = resultado.Where(x => x.DataVenda <= dataFinal.Value);

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.DataVenda)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, Venda>>> PesquisaPorDataAgrupadasAsync(DateTime? dataInicio, DateTime? dataFinal)
        {
            var resultado = from obj in _context.Venda select obj;
            if (dataInicio.HasValue)
                resultado = resultado.Where(x => x.DataVenda >= dataInicio.Value);
            if (dataFinal.HasValue)
                resultado = resultado.Where(x => x.DataVenda <= dataFinal.Value);

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.DataVenda)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
