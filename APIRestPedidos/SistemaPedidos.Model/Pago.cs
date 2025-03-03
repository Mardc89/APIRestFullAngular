using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdPedido { get; set; }

    public decimal MontoDePedido { get; set; }

    public decimal Descuento { get; set; }

    public decimal MontoTotalDePago { get; set; }

    public decimal MontoDeuda { get; set; }

    public DateTime FechaDePago { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetallePago> DetallePagos { get; } = new List<DetallePago>();

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
