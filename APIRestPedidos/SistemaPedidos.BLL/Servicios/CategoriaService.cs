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
    public class CategoriaService:ICategoriaService
    {
        private readonly IGenericRepositorio<Categoria> _categoriaRepositorio;
        private readonly IMapper _mapper;

        public CategoriaService(IGenericRepositorio<Categoria> categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio =categoriaRepositorio;
            _mapper=mapper;
        }

        public async Task<List<CategoriaDTO>> Lista()
        {
            try
            {
                var listaCategorias =await  _categoriaRepositorio.Consultar();
                return _mapper.Map<List<CategoriaDTO>>(listaCategorias.ToList());
            }
            catch 
            {

                throw;
            }
        }
    }
}
