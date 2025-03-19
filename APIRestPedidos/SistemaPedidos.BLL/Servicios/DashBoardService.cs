using AutoMapper;
using SistemaPedidos.BLL.Servicios.Contrato;
using SistemaPedidos.DAL.Repositorios.Contrato;
using SistemaPedidos.DTO;
using SistemaPedidos.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private async Task<string> TotalIngresosUltimaSemana()
        {
            decimal resultado = 0;
            IQueryable<Pedido> _pedidoQuery = await _PedidoRepositorio.Consultar();

            if (_pedidoQuery.Count() > 0)
            {

                var tablapedido = retornarPedidos(_pedidoQuery, -7);
                resultado = tablapedido.Select(x => x.MontoTotal).Sum(x=>x.Value);
            }
            return Convert.ToString(resultado, new CultureInfo("es-PE"));


        }

        private async Task<int> TotalProductos()
        {

            IQueryable<Producto> productoQuery = await _productoRepositorio.Consultar();

            int total = productoQuery.Count();
            return total;
        }

        private async Task<Dictionary<string,int>> PedidosUltimaSemana(){

            Dictionary<string,int> resultado= new Dictionary<string,int>();
            IQueryable<Pedido> _pedidoQuery = await _PedidoRepositorio.Consultar();

            if (_pedidoQuery.Count()>0) {

                var tablaPedido = retornarPedidos(_pedidoQuery,-7);

                resultado = tablaPedido
                    .GroupBy(s => s.FechaPedido.Value.Date).OrderBy(x => x.Key)
                    .Select(n => new { fecha = n.Key.ToString("dd/MM/yyyyy"), total = n.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
            }

            return resultado;

        }

        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO dashboardDTO = new DashBoardDTO();

            try
            {  
                dashboardDTO.TotalPedidos = await TotalPedidosUltimaSemana();
                dashboardDTO.TotalIngresos = await TotalIngresosUltimaSemana();
                dashboardDTO.TotalProductos = await TotalProductos();

                List<PedidoSemanaDTO> listaPedidoSemana= new List<PedidoSemanaDTO>();

                foreach (KeyValuePair<string,int> item in await PedidosUltimaSemana()){

                    listaPedidoSemana.Add(new PedidoSemanaDTO()
                    {
                        Fecha = item.Key,
                        Total = item.Value,


                    });
                }

                dashboardDTO.PedidoUltimaSemana = listaPedidoSemana;
            }
            catch
            {

                throw;
            }

            return dashboardDTO;
        }
    }
}
