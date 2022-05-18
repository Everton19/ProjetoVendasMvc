using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjetoAspVendas.Models;
using ProjetoAspVendas.Models.ViewModels;
using ProjetoAspVendas.Services;
using ProjetoAspVendas.Services.Exceptions;

namespace ProjetoAspVendas.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedoresService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedoresService vendedoresService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedoresService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var lista = _vendedorService.FindAll();
            return View(lista);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.FindBybId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.FindBybId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorService.FindBybId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            try
            {
                _vendedorService.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }

        }
    }
}