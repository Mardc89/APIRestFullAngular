using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        public string Dni { get; set; } = null!;

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public int IdRol { get; set; }
        public string? RolDescripcion { get; set; }
        public int? Estado { get; set; }



    }
}
