using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Distrito
{
    public int IdDistrito { get; set; }

    public string NombreDistrito { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();
}
