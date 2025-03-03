using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPedidos.DAL.DBContext;
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
        }
    }
}
