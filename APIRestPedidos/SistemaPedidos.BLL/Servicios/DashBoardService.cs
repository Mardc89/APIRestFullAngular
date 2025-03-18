using AutoMapper;
using SistemaPedidos.BLL.Servicios.Contrato;
using SistemaPedidos.DAL.Repositorios.Contrato;
using SistemaPedidos.DTO;
using SistemaPedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.BLL.Servicios
{
    public class DashBoardService:IDashBoardService
    {
        private readonly IPedidoRepositorio _PedidoRepositorio;
        private readonly IGenericRepositorio<Producto> _productoRepositorio;
        private readonly IMapper _mapper;

        public DashBoardService(IPedidoRepositorio pedidoRepositorio, IGenericRepositorio<Producto> productoRepositorio, IMapper mapper)
        {
            _PedidoRepositorio = pedidoRepositorio;
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        public Task<DashBoardDTO> Resumen()
        {
            throw new NotImplementedException();
        }

        private IQueryable<Pedido> retornarPedidos(IQueryable<Pedido> tablaPedidos,int restarCantidadDias)
        {
            DateTime? UltimaFecha = tablaPedidos.OrderByDescending(m => m.FechaPedido).Select(n => n.FechaPedido).First();
            UltimaFecha = UltimaFecha.Value.AddDays(restarCantidadDias);

            return tablaPedidos.Where(d => d.FechaPedido.Value.Date >= UltimaFecha.Value.Date);

        }

        private async Task<int> TotalPedidosUltimaSemana()
        {
            int total = 0;
            IQueryable<Pedido> _pedidoQuery = await _PedidoRepositorio.Consultar();

            if (_pedidoQuery.Count()>0){

                var tablapedido = retornarPedidos(_pedidoQuery, -7);
                total = tablapedido.Count();
            }

            return total;

        }
    }
}
