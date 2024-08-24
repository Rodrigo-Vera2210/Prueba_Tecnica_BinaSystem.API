using AutoMapper;
using Prueba_Tecnica_BinaSystem.DTO;
using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region Usuario
            CreateMap<Usuario,UsuarioDTO>().ReverseMap();
            #endregion

            #region Cliente
            CreateMap<Cliente,ClienteDTO>().ReverseMap();
            #endregion
            
            #region Factura
            CreateMap<Factura,FacturaDTO>().ReverseMap();
            #endregion
            
            #region Producto
            CreateMap<Producto,ProductoDTO>().ReverseMap();
            #endregion
            
            #region Detalle
            CreateMap<Detalle,DetalleDTO>().ReverseMap();
            #endregion
        }
    }
}
