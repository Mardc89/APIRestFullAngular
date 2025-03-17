using SistemaPedidos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.BLL.Servicios.Contrato
{
    public interface IPedidoService
    {
        Task<PedidoDTO>Registrar(PedidoDTO modelo);
        Task<List<PedidoDTO>> Historial(string BuscarPor, string codigo, string fechaInicio, string fin);
        Task<List<ReporteDTO>> Reporte(string fechaInicio, string fin);
    }
}
