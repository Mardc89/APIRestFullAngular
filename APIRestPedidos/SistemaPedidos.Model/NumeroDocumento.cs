using System;
using System.Collections.Generic;

namespace SistemaPedidos.Model;

public partial class NumeroDocumento
{
    public int IdNumeroDocumento { get; set; }

    public int UltimoNumero { get; set; }

    public int CantidadDeDigitos { get; set; }

    public string Gestion { get; set; } = null!;

    public DateTime FechaActualizacion { get; set; }
}
