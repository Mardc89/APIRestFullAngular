using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DTO
{
    public class ReporteDTO
    {
        public string? codigo { get; set; }
        public string? FechaRegistro { get; set; }
        public string?  TotalPedido { get; set; }
        public string? Producto { get; set; }
        public int? cantidad{ get; set; }
        public string? Precio { get; set; }
        public string? Total { get; set; }

    }
}
