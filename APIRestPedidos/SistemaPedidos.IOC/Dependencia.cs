using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPedidos.DAL.DBContext;
using SistemaPedidos.DAL.Repositorios;
using SistemaPedidos.DAL.Repositorios.Contrato;
using SistemaPedidos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services,IConfiguration configuration){
            services.AddDbContext<DbspaneContext>(options =>{
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepositorio<>),typeof(GenericRepository<>));

            services.AddScoped<IPedidoRepositorio,PedidoRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
