using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> listDepartamentos = new List<Departamento>();
            listDepartamentos.Add(new Departamento { Id = 1, Nome = "Eletronicos" });
            listDepartamentos.Add(new Departamento { Id = 2, Nome = "Moda" });
            return View(listDepartamentos);
        }
    }
}
