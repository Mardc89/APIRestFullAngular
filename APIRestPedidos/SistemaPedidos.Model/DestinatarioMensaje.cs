using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class DestinatarioMensaje
{
    public int IdMensaje { get; set; }

    public string Destinatario { get; set; } = null!;

    public int IdDestinatario { get; set; }

    public virtual Mensaje IdMensajeNavigation { get; set; } = null!;
}
