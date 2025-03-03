using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class Mensaje
{
    public int IdMensaje { get; set; }

    public string Remitente { get; set; } = null!;

    public int IdRemitente { get; set; }

    public string Asunto { get; set; } = null!;

    public string? Cuerpo { get; set; }

    public int? IdRespuestaMensaje { get; set; }

    public DateTime FechaDeMensaje { get; set; }

    public virtual DestinatarioMensaje? DestinatarioMensaje { get; set; }
}
