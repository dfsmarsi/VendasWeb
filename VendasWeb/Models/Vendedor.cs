using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataAniversario { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataAniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataAniversario = dataAniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVenda(Venda venda)
        {
            Vendas.Add(venda);
        }

        public void RemoverVenda(Venda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendas.Where(v => v.DataVenda >= inicio && v.DataVenda <= fim).Sum(v => v.Valor);
        }
    }
}
