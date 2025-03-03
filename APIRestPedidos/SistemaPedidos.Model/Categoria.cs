using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string TipoDeCategoria { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
