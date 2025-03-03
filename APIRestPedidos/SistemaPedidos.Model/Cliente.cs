using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string TipoCliente { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int IdDistrito { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public bool Estado { get; set; }

    public string? UrlFoto { get; set; }

    public string? NombreFoto { get; set; }

    public virtual Distrito IdDistritoNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
