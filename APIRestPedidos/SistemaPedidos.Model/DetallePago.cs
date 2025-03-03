using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class DetallePago
{
    public int IdDetallePago { get; set; }

    public int IdPago { get; set; }

    public decimal MontoApagar { get; set; }

    public decimal PagoDelCliente { get; set; }

    public decimal DeudaDelCliente { get; set; }

    public decimal CambioDelCliente { get; set; }

    public DateTime FechaDetallePago { get; set; }

    public virtual Pago IdPagoNavigation { get; set; } = null!;
}
