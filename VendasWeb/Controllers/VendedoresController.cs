using Microsoft.AspNetCore.Mvc;
using VendasWeb.Models;
using VendasWeb.Models.ViewModels;
using VendasWeb.Services;

namespace VendasWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var listaVendedores = _vendedorService.ProcurarTodos();
            return View(listaVendedores);
        }

        public IActionResult CadastrarVendedor()
        {
            var departamentos = _departamentoService.ListarDepartamentos();
            var viewModel = new VendedorFormViewModel { ListDepartamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarVendedor(Vendedor vendedor)
        {
            _vendedorService.InserirVendedor(vendedor);
            return RedirectToAction(nameof(Index));
        }


    }
}
