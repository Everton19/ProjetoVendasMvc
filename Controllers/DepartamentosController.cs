using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspVendas.Models;

namespace ProjetoAspVendas.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> lista = new List<Departamento>();
            lista.Add(new Departamento { Id = 1, Nome = "Eletrônicos"});
            lista.Add(new Departamento { Id = 2, Nome = "Computadores"});

            return View(lista);
        }
    }
}