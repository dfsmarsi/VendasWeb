using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Models.ViewModels;
using VendasWeb.Services;
using VendasWeb.Services.Exceptions;

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

        public async Task<IActionResult> Index()
        {
            var listaVendedores = await _vendedorService.ProcurarTodosAsync();
            return View(listaVendedores);
        }

        public async Task<IActionResult> CadastrarVendedor()
        {
            var departamentos = await _departamentoService.ListarDepartamentosAsync();
            var viewModel = new VendedorFormViewModel { ListDepartamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarVendedor(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var listDepartamentos = await _departamentoService.ListarDepartamentosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, ListDepartamentos = listDepartamentos };
                return View(viewModel);
            }
            await _vendedorService.InserirVendedorAsync(vendedor);
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message ="Id não fornecido!" });
            var obj = await _vendedorService.ProcurarPorIDAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não existente!" });
            
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _vendedorService.ExcluirVendedorAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message }); ;
            }
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido!" });
            var obj = await _vendedorService.ProcurarPorIDAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não existente!" });

            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido!" });
            var obj = await _vendedorService.ProcurarPorIDAsync(id.Value);
            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id não existente!" });

            List<Departamento> listDepartamentos = await _departamentoService.ListarDepartamentosAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, ListDepartamentos = listDepartamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var listDepartamentos = await _departamentoService.ListarDepartamentosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, ListDepartamentos = listDepartamentos };
                return View(viewModel);
            }
            if (id != vendedor.Id)
                return RedirectToAction(nameof(Error), new { message = "Id não correspondente!" });
            try
            {
                await _vendedorService.AtualizarVendedorAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
