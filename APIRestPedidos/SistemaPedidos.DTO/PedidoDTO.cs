using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DTO
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }

        public string? Codigo { get; set; }

        public string? MontoTotal { get; set; }

        public string? FechaPedido { get; set; }

        public virtual ICollection<DetallePedidoDTO> DetallePedidos { get; } = new List<DetallePedidoDTO>();
    }
}
