using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdCategoria { get; set; }

    public decimal Precio { get; set; }

    public string? UrlImagen { get; set; }

    public string? NombreImagen { get; set; }

    public bool Estado { get; set; }

    public int Stock { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; } = new List<DetallePedido>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
}
