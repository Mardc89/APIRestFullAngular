using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.API.Utilidad;
using SistemaPedidos.BLL.Servicios;
using SistemaPedidos.BLL.Servicios.Contrato;
using SistemaPedidos.DTO;

namespace SistemaPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Guardar([FromBody] PedidoDTO pedido)
        {
            var rsp = new Response<PedidoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _pedidoService.Registrar(pedido);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);

        }


        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor,string?numeroPedido,string?fechaInicio,string?fechafin)
        {
            var rsp = new Response<List<PedidoDTO>>();
            numeroPedido = numeroPedido is null ? "" : numeroPedido;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechafin = fechafin is null ? "" : fechafin;

            try
            {
                rsp.status = true;
                rsp.value = await _pedidoService.Historial(buscarPor,numeroPedido,fechaInicio,fechafin);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);

        }


        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechafin)
        {
            var rsp = new Response<List<ReporteDTO>>();
            try
            {
                rsp.status = true;
                rsp.value = await _pedidoService.Reporte(fechaInicio, fechafin);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }

            return Ok(rsp);

        }



    }
}
