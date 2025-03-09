using AutoMapper;
using SistemaPedidos.DTO;
using SistemaPedidos.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.NombreRol)
                )
                .ForMember(destino =>
                destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0)

                );
            CreateMap<Usuario, SesionDTO>()
                .ForMember(destino =>
                destino.RolDescripcion,
                opt => opt.MapFrom(origen => origen.IdRolNavigation.NombreRol)
                );
            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado == 1 ? true : false)

                );
            #region Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion Categoria



            #region Categoria
            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino=>
                destino.DescripcionCategoria,
                opt=>opt.MapFrom(origen=>origen.IdCategoriaNavigation.TipoDeCategoria)
                )
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value,new CultureInfo("es-PE")))

                )
                .ForMember(destino =>
                destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado == true ? 1 : 0)

                );

            CreateMap<ProductoDTO, Producto>()
                .ForMember(destino =>
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.Precio,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                destino.Estado,
                opt => opt.MapFrom(origen => origen.Estado ==true ? 1 : 0)
                );

            #endregion Categoria

        }
    }   
}
