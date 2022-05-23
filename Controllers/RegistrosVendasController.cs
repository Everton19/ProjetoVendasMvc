using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspVendas.Services;

namespace ProjetoAspVendas.Controllers
{
    public class RegistrosVendasController : Controller
    {

        private readonly RegistroVendasService _registroVendasService;

        public RegistrosVendasController(RegistroVendasService registroVendasService)
        {
            _registroVendasService = registroVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? dataMin, DateTime? dataMax)
        {
            if (!dataMin.HasValue)
            {
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMax.HasValue)
            {
                dataMax = DateTime.Now;
            }
            ViewData["dataMin"] = dataMin.Value.ToString("dd/MM/yyyy");
            ViewData["dataMax"] = dataMax.Value.ToString("dd/MM/yyyy");
            var resultado = await _registroVendasService.EncontrarUmaDataAsync(dataMin, dataMax);
            return View(resultado);
        }

        public async Task<IActionResult> BuscaEmGrupo(DateTime? dataMin, DateTime? dataMax)
        {
            if (!dataMin.HasValue)
            {
                dataMin = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataMax.HasValue)
            {
                dataMax = DateTime.Now;
            }
            ViewData["dataMin"] = dataMin.Value.ToString("dd/MM/yyyy");
            ViewData["dataMax"] = dataMax.Value.ToString("dd/MM/yyyy");
            var resultado = await _registroVendasService.EncontrarUmaDataEmGrupoAsync(dataMin, dataMax);
            return View(resultado);
        }
    }
}