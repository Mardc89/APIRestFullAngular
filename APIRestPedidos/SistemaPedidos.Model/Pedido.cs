using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public string Codigo { get; set; } = null!;

    public decimal MontoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaPedido { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; } = new List<DetallePedido>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; } = new List<Pago>();
}
