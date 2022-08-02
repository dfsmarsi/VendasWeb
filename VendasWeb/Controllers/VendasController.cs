using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Services;

namespace VendasWeb.Controllers
{
    public class VendasController : Controller
    {
        private readonly PesquisaDeVendasService _pesquisaDeVendasService;

        public VendasController(PesquisaDeVendasService pesquisaDeVendasService)
        {
            _pesquisaDeVendasService = pesquisaDeVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PesquisaSimples(DateTime? dataInicio, DateTime? dataFinal)
        {
            if (!dataInicio.HasValue)
                dataInicio = new DateTime(DateTime.Now.Year, 1, 1);
            if (!dataFinal.HasValue)
                dataFinal = DateTime.Now;
            ViewData["dataInicio"] = dataInicio.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");
            var resultado = await _pesquisaDeVendasService.PesquisaPorDatasAsync(dataInicio, dataFinal); 
            return View(resultado);
        }

        public async Task<IActionResult> PesquisaAgrupada(DateTime? dataInicio, DateTime? dataFinal)
        {
            if (!dataInicio.HasValue)
                dataInicio = new DateTime(DateTime.Now.Year, 1, 1);
            if (!dataFinal.HasValue)
                dataFinal = DateTime.Now;
            ViewData["dataInicio"] = dataInicio.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");
            var resultado = await _pesquisaDeVendasService.PesquisaPorDataAgrupadasAsync(dataInicio, dataFinal);
            return View(resultado);
        }
    }
}
