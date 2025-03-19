using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPedidos.BLL.Servicios.Contrato;

namespace SistemaPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolServicio;

        public RolController(IRolService rolServicio)
        {
            _rolServicio=rolServicio;
        }
    }
}
