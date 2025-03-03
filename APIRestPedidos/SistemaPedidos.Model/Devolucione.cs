using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Devolucione
{
    public int IdDevolucion { get; set; }

    public string CodigoPedido { get; set; } = null!;

    public string CodigoDevolucion { get; set; } = null!;

    public decimal MontoDePedido { get; set; }

    public decimal Descuento { get; set; }

    public decimal MontoApagar { get; set; }

    public DateTime FechaDevolucion { get; set; }

    public virtual ICollection<DetalleDevolucion> DetalleDevolucions { get; } = new List<DetalleDevolucion>();
}
