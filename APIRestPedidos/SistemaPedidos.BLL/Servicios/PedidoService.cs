using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPedidos.BLL.Servicios.Contrato;
using SistemaPedidos.DAL.Repositorios;
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
    public class PedidoService:IPedidoService
    {
        private readonly IPedidoRepositorio _PedidoRepositorio;
        private readonly IGenericRepositorio<DetallePedido> _detallePedidoRepositorio;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepositorio pedidoRepositorio, IGenericRepositorio<DetallePedido> detallePedidoRepositorio, IMapper mapper)
        {
            _PedidoRepositorio = pedidoRepositorio;
            _detallePedidoRepositorio = detallePedidoRepositorio;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> Registrar(PedidoDTO modelo)
        {
            try                                           
            {
                var pedidoGenerado = await _PedidoRepositorio.Registrar(_mapper.Map<Pedido>(modelo));
                if (pedidoGenerado.IdPedido == 0)
                    throw new Exception("No se pudo Crear");

                return _mapper.Map<PedidoDTO>(pedidoGenerado);
            }
            catch
            { 
                throw;
            }
        }

        public async Task<List<PedidoDTO>> Historial(string BuscarPor, string codigo, string fechaInicio, string fechafin)
        {
            IQueryable<Pedido> query = await _PedidoRepositorio.Consultar();
            var ListaResultado = new List<Pedido>();
            try
            {
                if (BuscarPor=="fecha") 
                {
                    DateTime FechaInicio = DateTime.ParseExact(fechaInicio,"dd/MM/yyyy",new CultureInfo("es-PE"));
                    DateTime FechaFin = DateTime.ParseExact(fechafin, "dd/MM/yyyy", new CultureInfo("es-PE"));

                    ListaResultado = await query.Where(u =>
                        u.FechaPedido.Value.Date >= FechaFin.Date &&
                        u.FechaPedido.Value.Date <= FechaFin.Date
                        ).Include(d => d.DetallePedidos)
                        .ThenInclude(p => p.IdProductoNavigation)
                        .ToListAsync();
                }
                else{
                    ListaResultado = await query.Where(u =>u.Codigo==codigo
                    ).Include(d => d.DetallePedidos)
                    .ThenInclude(p => p.IdProductoNavigation)
                    .ToListAsync();

                }

            }
            catch
            {

                throw;
            }

            return _mapper.Map<List<PedidoDTO>>(ListaResultado);
        }

        public async Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechafin)
        {
            IQueryable<DetallePedido> query = await _detallePedidoRepositorio.Consultar();
            var ListaResultado = new List<DetallePedido>();
            try
            {

                    DateTime FechaInicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
                    DateTime FechaFin = DateTime.ParseExact(fechafin, "dd/MM/yyyy", new CultureInfo("es-PE"));

                    ListaResultado = await query
                        .Include(p => p.IdProductoNavigation)
                        .Include(u=>u.IdPedidoNavigation)
                        .Where(s=>
                        s.IdPedidoNavigation.FechaPedido.Value.Date>=FechaInicio.Date && 
                        s.IdProductoNavigation.FechaRegistro.Value.Date<=FechaFin.Date     
                        )
                        .ToListAsync();
             }
            catch
            {

                throw;
            }

            return _mapper.Map<List<ReporteDTO>>(ListaResultado);
        }
    }
}
