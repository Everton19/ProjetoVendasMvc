using ProjetoAspVendas.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAspVendas.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
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