using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato;
using Prueba_Tecnica_BinaSystem.DTO;
using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.BLL.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> Crear(ProductoDTO producto)
        {
            try
            {
                var productoCreado = await _productoRepository.Crear(_mapper.Map<Producto>(producto));
                if (productoCreado.IdProducto == 0) throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<ProductoDTO>(productoCreado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProductoDTO>> Lista(string searchTerm)
        {
            try
            {
                var listaProductos = await _productoRepository.Consultar();

                if(!searchTerm.IsNullOrEmpty())
                {
                    listaProductos = listaProductos.Where(
                        p => p.Codigo.Contains(searchTerm) ||
                             p.Descripcion.Contains(searchTerm));
                }


                return _mapper.Map<List<ProductoDTO>>(listaProductos.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductoDTO> Obtener(long id)
        {
            try
            {
                var productoEncontrado = await _productoRepository.Obtener(c => c.IdProducto == id);

                if (productoEncontrado == null) throw new TaskCanceledException("Producto no encontrado");

                return _mapper.Map<ProductoDTO>(productoEncontrado);
            }
            catch (Exception)
            {
                throw; 
            }
        }
    }
}
