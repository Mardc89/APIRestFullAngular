using SistemaPedidos.DAL.DBContext;
using SistemaPedidos.DAL.Repositorios.Contrato;
using SistemaPedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DAL.Repositorios
{
    public class PedidoRepository:GenericRepository<Pedido>,IPedidoRepositorio
    {
        private readonly DbspaneContext _dbspaneContext;
        public PedidoRepository(DbspaneContext dbspaneContext):base(dbspaneContext)
        {
            _dbspaneContext = dbspaneContext;
        }

        public Task<Pedido> Registrar(Pedido modelo)
        {
            throw new NotImplementedException();
        }
    }
}
