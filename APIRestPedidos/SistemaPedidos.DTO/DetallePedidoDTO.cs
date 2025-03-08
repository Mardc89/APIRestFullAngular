using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DTO
{
    public class DetallePedidoDTO
    {        
        public int? IdProducto { get; set; }

        public string? DescripcionProductos { get; set; }

        public int? Cantidad { get; set; }
        public string? Precio { get; set; }

        public string? Total { get; set; }
    }
}
