using Microsoft.EntityFrameworkCore;
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

        public async Task<Pedido> Registrar(Pedido modelo)
        {
            Pedido pedidoGenerado = new Pedido();

            using (var transaction = _dbspaneContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetallePedido dv in modelo.DetallePedidos)
                    {
                        Producto producto_encontrado = _dbspaneContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                        _dbspaneContext.Productos.Update(producto_encontrado);

                    }
                    await _dbspaneContext.SaveChangesAsync();

                    NumeroDocumento correlativo = _dbspaneContext.NumeroDocumentos.Where(n => n.Gestion == "Pedido").First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaActualizacion = DateTime.Now;

                    _dbspaneContext.NumeroDocumentos.Update(correlativo);
                    await _dbspaneContext.SaveChangesAsync();

                    string ceros = string.Concat(Enumerable.Repeat("0", correlativo.CantidadDeDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - correlativo.CantidadDeDigitos, correlativo.CantidadDeDigitos);

                    modelo.Codigo = numeroVenta;

                    await _dbspaneContext.Pedidos.AddAsync(modelo);
                    await _dbspaneContext.SaveChangesAsync();

                    pedidoGenerado = modelo;
                    transaction.Commit();


                }
                catch 
                {
                    transaction.Rollback();
                    throw;

                }


            }

            return pedidoGenerado;
        }
    }
}
