using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
