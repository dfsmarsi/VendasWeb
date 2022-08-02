using System.Collections.Generic;
using System.Linq;
using VendasWeb.Models;
using VendasWeb.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace VendasWeb.Services
{
    public class VendedorService
    {
        private readonly VendasWebContext _context;

        public VendedorService(VendasWebContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> ProcurarTodosAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InserirVendedorAsync(Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> ProcurarPorIDAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task ExcluirVendedorAsync(int id)
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task AtualizarVendedorAsync(Vendedor vendedor)
        {
            bool possuiRegistro = await _context.Vendedor.AnyAsync(x => x.Id == vendedor.Id);
            if (!possuiRegistro)
                throw new NotFoundException("Id não encontrado");
            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
