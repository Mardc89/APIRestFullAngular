﻿using SistemaPedidos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.BLL.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> Lista();
        Task<SesionDTO> ValidarCredenciales(string correo,string clave);
        Task<UsuarioDTO> Crear(UsuarioDTO modelo);
        Task<bool>Editar(UsuarioDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
