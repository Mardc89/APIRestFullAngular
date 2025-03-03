using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Dni { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int IdRol { get; set; }

    public DateTime FechaRegistro { get; set; }

    public bool Estado { get; set; }

    public string? UrlFoto { get; set; }

    public string? NombreFoto { get; set; }

    public virtual Role IdRolNavigation { get; set; } = null!;
}
