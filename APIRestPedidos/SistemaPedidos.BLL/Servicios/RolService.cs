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
    public class RolService:IRolService
    {
        private readonly IGenericRepositorio<Rol> _rolRepositorio;
        private readonly IMapper _mapper;

        public RolService(IGenericRepositorio<Rol> rolRepositorio, IMapper mapper)
        {
            _rolRepositorio=rolRepositorio;
            _mapper=mapper;
        }

        public async Task<List<RolDTO>> Lista()
        {
            try
            {
                var listaRoles = await _rolRepositorio.Consultar();
                return _mapper.Map<List<RolDTO>>(listaRoles);
            }
            catch
            {
                throw;
            }
        }
    }
}
