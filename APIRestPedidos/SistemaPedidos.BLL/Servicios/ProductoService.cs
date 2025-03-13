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

        public Task<bool> Editar(ProductoDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductoDTO>> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
