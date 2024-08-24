using AutoMapper;
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
    public class FacturaService : IFacturaService
    {
        private readonly IGenericRepository<Factura> _facturaRepository;
        private readonly IMapper _mapper;

        public FacturaService(IGenericRepository<Factura> facturaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
        }

        public Task<FacturaDTO> Crear(FacturaDTO factura)
        {
            throw new NotImplementedException();
        }

        public Task<List<FacturaDTO>> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
