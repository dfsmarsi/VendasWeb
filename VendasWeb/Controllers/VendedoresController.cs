using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Services;

namespace VendasWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            var listaVendedores = _vendedorService.ProcurarTodos();
            return View(listaVendedores);
        }

        public IActionResult CadastrarVendedor()
        {
            return View();
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
