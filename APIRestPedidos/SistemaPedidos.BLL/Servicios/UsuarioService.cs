using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class UsuarioService: IUsuarioService
    {
        private readonly IGenericRepositorio<Usuario> _usuarioRepositorio;
        private readonly IMapper _mapper;


        public UsuarioService(IGenericRepositorio<Usuario> usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> Lista()
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar();
                var listaUsuarios = queryUsuario.Include(rol => rol.IdRolNavigation).ToList();

                return _mapper.Map<List<UsuarioDTO>>(listaUsuarios);
            }
            catch 
            {
                throw;
            }
        }

        public async Task<SesionDTO> ValidarCredenciales(string correo, string clave)
        {
            try
            {
                var queryUsuario = await _usuarioRepositorio.Consultar(u => u.Correo == correo && u.Clave == clave);

                if (queryUsuario.FirstOrDefault() == null)
                    throw new TaskCanceledException("El Usuario no Existe");

                Usuario usuario = queryUsuario.Include(rol => rol.IdRolNavigation).First();

                return _mapper.Map<SesionDTO>(usuario);


            }
            catch 
            {
                throw;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
                var usuarioCreado=await _usuarioRepositorio.Crear(_mapper.Map<Usuario>(modelo));
                if (usuarioCreado.IdUsuario == 0)
                    throw new TaskCanceledException("No se pudo crear");
                var query = await _usuarioRepositorio.Consultar(u => u.IdUsuario == usuarioCreado.IdUsuario);

                usuarioCreado = query.Include(rol => rol.IdRolNavigation).First();
                return _mapper.Map<UsuarioDTO>(usuarioCreado);

            }
            catch
            {

                throw;
            }
        }

        public Task<bool> Editar(UsuarioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
