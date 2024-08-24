using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;

        public FacturaService(IFacturaRepository facturaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
        }

        public async Task<ReporteFacturaDTO> Crear(FacturaDTO factura)
        {
            try
            {
                var facturaGenerada = await _facturaRepository.Registrar(_mapper.Map<Factura>(factura));

                if (facturaGenerada == null) throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<ReporteFacturaDTO>(facturaGenerada);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ReporteFacturaDTO>> Lista()
        {
            try
            {
                var result = await _facturaRepository.Consultar();

                List<Factura> resultados = await result.Include(detalle => detalle.Detalles)
                    .ThenInclude(p => p.Producto).ToListAsync();

                return _mapper.Map<List<ReporteFacturaDTO>>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReporteFacturaDTO> Obtener(long id)
        {
            try
            {
                var facturaEncontrado = await _facturaRepository.Consultar(c => c.IdFactura == id);

                if (facturaEncontrado == null) throw new TaskCanceledException("Factura no encontrada");

                Factura factura = await facturaEncontrado.Include(detalle => detalle.Detalles)
                    .ThenInclude(p => p.Producto).FirstAsync();

                return _mapper.Map<ReporteFacturaDTO>(factura);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
