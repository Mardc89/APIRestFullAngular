using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class DetalleDevolucion
{
    public int IdDetalleDevolucion { get; set; }

    public int IdDevolucion { get; set; }

    public string Categoria { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int CantidadPedido { get; set; }

    public decimal Total { get; set; }

    public int CantidadDevolucion { get; set; }

    public virtual Devolucione IdDevolucionNavigation { get; set; } = null!;
}
