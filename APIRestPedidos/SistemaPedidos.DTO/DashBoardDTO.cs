using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DTO
{
    public class DashBoardDTO
    {
        public int ToatPedidos { get; set; }

        public int TotalIngresos { get; set; }

        public List<PedidoSemanaDTO> PedidoUltimaSemanaDTO { get; set; }
    
    }
}
