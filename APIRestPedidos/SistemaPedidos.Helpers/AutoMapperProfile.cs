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
                #endregion Usuario

                #region Categoria
                CreateMap<Categoria, CategoriaDTO>().ReverseMap();
                #endregion Categoria

                #region Producto
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
                    opt => opt.MapFrom(origen => origen.Estado == 1 ?true : false)
                    );

                #endregion Producto


             CreateMap<Pedido, PedidoDTO>()
             .ForMember(destino =>
                        destino.MontoTotal,
                        opt => opt.MapFrom(origen => Convert.ToString(origen.MontoTotal.Value, new CultureInfo("es-PE")))
                      )
                    .ForMember(destino =>
                    destino.FechaPedido,
                    opt => opt.MapFrom(origen => origen.FechaPedido.Value.ToString("dd/MM/yyyyy"))
                    );

            CreateMap<PedidoDTO, Pedido>()
                    .ForMember(destino =>
                    destino.MontoTotal,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.MontoTotal, new CultureInfo("es-PE")))
                    );


            #region DetallePedido
            CreateMap<DetallePedido, DetallePedidoDTO>()
                .ForMember(destino =>
                destino.DescripcionProducto,
                opt => opt.MapFrom(origen => origen.IdProductoNavigation.Descripcion)
                )
                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                )
              .ForMember(destino =>
            destino.Precio,
            opt => opt.MapFrom(origen => Convert.ToDecimal(origen.IdProductoNavigation.Precio, new CultureInfo("es-PE")))
            );

            CreateMap<DetallePedidoDTO, DetallePedido>()
                //.ForMember(destino =>
                //destino.IdProductoNavigation.Precio,
                //opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Precio, new CultureInfo("es-PE")))
                //)
                .ForMember(destino =>
                destino.Total,
                opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Total, new CultureInfo("es-PE")))
                );
            #endregion DetallePedido

            CreateMap<DetallePedido, ReporteDTO>()
        .ForMember(destino =>
        destino.FechaRegistro,
        opt => opt.MapFrom(origen => origen.IdPedidoNavigation.FechaPedido.Value.ToString("dd/MM/yyyy"))
        )
        .ForMember(destino =>
        destino.codigo,
        opt => opt.MapFrom(origen => origen.IdPedidoNavigation.Codigo)
        )

        .ForMember(destino =>
        destino.TotalPedido,
        opt => opt.MapFrom(origen => Convert.ToString(origen.IdPedidoNavigation.MontoTotal.Value, new CultureInfo("es-PE")))
        )
        .ForMember(destino =>
        destino.Producto,
        opt => opt.MapFrom(origen => origen.IdProductoNavigation.Descripcion)
        )
        .ForMember(destino =>
        destino.Precio,
        opt => opt.MapFrom(origen => Convert.ToString(origen.IdProductoNavigation.Precio, new CultureInfo("es-PE")))
        )
        .ForMember(destino =>
        destino.Total,
        opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
        );
        }
        }   
}
