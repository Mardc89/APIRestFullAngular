using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public int IdCategoria { get; set; }
        public string DescripcionCategoria { get; set; } = null!;

        public string? Precio { get; set; }

        public int? Estado { get; set; }

        public int Stock { get; set; }
    }
}
