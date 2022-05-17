using Microsoft.AspNetCore.Mvc;
using ProjetoAspVendas.Models;
using ProjetoAspVendas.Models.ViewModels;
using ProjetoAspVendas.Services;

namespace ProjetoAspVendas.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedoresService _vendedoresService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedoresService vendedoresService, DepartamentoService departamentoService)
        {
            _vendedoresService = vendedoresService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var lista = _vendedoresService.FindAll();
            return View(lista);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos};
            return View(viewModel);
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