using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoAspVendas.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Requer {0}")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O padrão de nome deve estar entre 3 e 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Requer {0}")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Coloque um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Requer {0}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double SalarioBase { get; set; }

        [Required(ErrorMessage = "Requer {0}")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SalarioBase = salarioBase;
            DataNascimento = dataNascimento;
            Departamento = departamento;
        }

        public void AdicionarVendas(RegistroVendas rv)
        {
            Vendas.Add(rv);
        }

        public void RemoverVendas(RegistroVendas rv)
        {
            Vendas.Remove(rv);
        }

        public double VendasTotais(DateTime inicial, DateTime final)
        {
            return Vendas.Where(vr => vr.Data >= inicial && vr.Data <= final).Sum(vr => vr.Resultado);
        }
    }
}