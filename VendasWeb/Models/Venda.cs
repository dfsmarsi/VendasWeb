using System;
using VendasWeb.Models.Enums;

namespace VendasWeb.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public double Valor { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public Venda()
        {
        }

        public Venda(int id, DateTime dataVenda, double valor, VendaStatus status, Vendedor vendedor)
        {
            Id = id;
            DataVenda = dataVenda;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
