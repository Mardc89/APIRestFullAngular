using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Token
{
    public int IdToken { get; set; }

    public string Perfil { get; set; } = null!;

    public int IdPerfil { get; set; }

    public string Token1 { get; set; } = null!;

    public DateTime Expiracion { get; set; }

    public DateTime Creacion { get; set; }
}
