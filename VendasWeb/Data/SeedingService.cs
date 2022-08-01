using System;
using System.Linq;
using VendasWeb.Models;
using VendasWeb.Models.Enums;

namespace VendasWeb.Data
{
    public class SeedingService
    {
        private VendasWebContext _context;

        public SeedingService(VendasWebContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departamento.Any() ||
                _context.Vendedor.Any() ||
                _context.Venda.Any())
            {
                return;
            }

            Departamento departamentoQA = new Departamento(1, "QA");
            Departamento departamentoDev = new Departamento(2, "Dev");
            Departamento departamentoSup = new Departamento(3, "Suporte");

            Vendedor vendedorJoaoPenca = new Vendedor(1, "Joao Penca", "joaopenca@gmail.com", new DateTime(1998,4,16), 1000.00, departamentoQA);
            Vendedor vendedorBob = new Vendedor(2, "Bob o Construtor", "bobconstrutor@gmail.com", new DateTime(1998, 5, 11), 1000.00, departamentoDev);
            Vendedor vendedorBraia = new Vendedor(3, "Braia", "braia@gmail.com", new DateTime(1998, 10, 20), 1000.00, departamentoSup);

            Venda venda1 = new Venda(1, new DateTime(2022, 07, 29), 10.00, VendaStatus.Faturado, vendedorJoaoPenca);
            Venda venda2 = new Venda(2, new DateTime(2022, 07, 28), 10.00, VendaStatus.Faturado, vendedorBob);
            Venda venda3 = new Venda(3, new DateTime(2022, 07, 29), 10.00, VendaStatus.Faturado, vendedorBraia);
            Venda venda4 = new Venda(4, new DateTime(2022, 06, 29), 10.00, VendaStatus.Faturado, vendedorJoaoPenca);
            Venda venda5 = new Venda(5, new DateTime(2022, 06, 29), 10.00, VendaStatus.Faturado, vendedorBob);
            Venda venda6 = new Venda(6, new DateTime(2022, 06, 29), 10.00, VendaStatus.Faturado, vendedorBraia);

            _context.Departamento.AddRange(departamentoDev, departamentoQA, departamentoSup);

            _context.Vendedor.AddRange(vendedorBob, vendedorBraia, vendedorJoaoPenca);

            _context.Venda.AddRange(venda1, venda2, venda3, venda4, venda5, venda6);

            _context.SaveChanges();
        }                           
    }                               
}                                   
                                    