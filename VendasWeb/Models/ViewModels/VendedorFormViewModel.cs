using System.Collections.Generic;

namespace VendasWeb.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> ListDepartamentos { get; set; }
    }
}
