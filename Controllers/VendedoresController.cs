using Microsoft.AspNetCore.Mvc;
using ProjetoAspVendas.Models;
using ProjetoAspVendas.Services;

namespace ProjetoAspVendas.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedoresService _vendedoresService;

        public VendedoresController(VendedoresService vendedoresService)
        {
            _vendedoresService = vendedoresService;
        }

        public IActionResult Index()
        {
            var lista = _vendedoresService.FindAll();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedoresService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}