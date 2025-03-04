using Microsoft.EntityFrameworkCore;
using SistemaPedidos.DAL.DBContext;
using SistemaPedidos.DAL.Repositorios.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.DAL.Repositorios
{
    public class GenericRepository<TModel>:IGenericRepositorio<TModel> where TModel : class
    {
        private readonly DbspaneContext _dbspaneContext;

        public GenericRepository(DbspaneContext dbspaneContext)
        {
            _dbspaneContext = dbspaneContext;
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel modelo=await _dbspaneContext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch
            {

                throw;
            }
        }

        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                _dbspaneContext.Set<TModel>().Add(modelo);
                await _dbspaneContext.SaveChangesAsync();
                return modelo;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> Editar(TModel modelo)
        {
            try
            {
                _dbspaneContext.Set<TModel>().Update(modelo);
                await _dbspaneContext.SaveChangesAsync();
                return true;

            }
            catch
            {

                throw;
            }
        }
        public async Task<bool> Eliminar(TModel modelo)
        {
            try
            {
                _dbspaneContext.Set<TModel>().Remove(modelo);
                await _dbspaneContext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }
        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModel> queryModelo = filtro == null ? _dbspaneContext.Set<TModel>() : _dbspaneContext.Set<TModel>().Where(filtro);
                return queryModelo;
            }
            catch
            {

                throw;
            }
        }






    }
}
