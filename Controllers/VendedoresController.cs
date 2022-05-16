using Microsoft.AspNetCore.Mvc;

namespace ProjetoAspVendas.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}