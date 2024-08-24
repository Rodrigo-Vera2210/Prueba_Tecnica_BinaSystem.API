using Prueba_Tecnica_BinaSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Lista();
        Task<ProductoDTO> Crear(ProductoDTO producto);
    }
}
