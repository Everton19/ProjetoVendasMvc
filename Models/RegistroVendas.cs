using ProjetoAspVendas.Models.Enums;
using System;

namespace ProjetoAspVendas.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Resultado { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVendas(int id, DateTime data, double resultado, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Resultado = resultado;
            Status = status;
            Vendedor = vendedor;
        }
        
        public RegistroVendas()
        {
        }
    }
}