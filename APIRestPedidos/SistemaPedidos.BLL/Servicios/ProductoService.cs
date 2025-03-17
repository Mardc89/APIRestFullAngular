using AutoMapper;
using SistemaPedidos.BLL.Servicios.Contrato;
using SistemaPedidos.DAL.Repositorios.Contrato;
using SistemaPedidos.DTO;
using SistemaPedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedidos.BLL.Servicios
{
    public class ProductoService:IProductoService
    {
        private readonly IGenericRepositorio<Producto> _productoRepositorio;
        private IMapper _mapper;

        public ProductoService(IGenericRepositorio<Producto> productoRepositorio, IMapper mapper)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
                
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
                
            try                                  
            {
                var productoCreado = await _productoRepositorio.Crear(_mapper.Map<Producto>(modelo));

                if (productoCreado.IdProducto == 0)
                    throw new TaskCanceledException("No se pudo Crear");

                return _mapper.Map<ProductoDTO>(productoCreado);
            }
            catch 
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var productoModelo=_mapper.Map<Producto>(modelo);
                var productoEncontrado = await _productoRepositorio.Obtener(u => u.IdProducto == productoModelo.IdProducto);
            
                if(productoEncontrado==null)
                    throw new TaskCanceledException("El producto no existe");

                productoEncontrado.Descripcion = productoModelo.Descripcion;
                productoEncontrado.IdCategoria = productoModelo.IdCategoria;
                productoEncontrado.Stock = productoModelo.Stock;
                productoEncontrado.Precio = productoModelo.Precio;
                productoEncontrado.Estado = productoModelo.Estado;

                bool respuesta=await _productoRepositorio.Editar(productoEncontrado);

                if(!respuesta)
                    throw new TaskCanceledException("No se pudo Editar");

                return respuesta;
            }


            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            var productoEncontrado = await _productoRepositorio.Obtener(u => u.IdProducto ==id);

            if(productoEncontrado==null)
                throw new TaskCanceledException("El Prodcuto No existe");

            bool respuesta=await _productoRepositorio.Eliminar(productoEncontrado);

            if (!respuesta)
                throw new TaskCanceledException("No se pudo Eliminar");

            return respuesta;

        }

        public Task<List<ProductoDTO>> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
