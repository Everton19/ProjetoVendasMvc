using Microsoft.AspNetCore.Mvc;

namespace ProjetoAspVendas.Controllers
{
    public class RegistrosVendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuscaSimples()
        {
            return View();
        }

        public IActionResult BuscaEmGrupo()
        {
            return View();
        }
    }
}