using SistemaPedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DAL.Repositorios.Contrato
{
    public  interface IPedidoRepositorio:IGenericRepositorio<Pedido>
    {
        Task<Pedido> Registrar(Pedido modelo);
    }
}
