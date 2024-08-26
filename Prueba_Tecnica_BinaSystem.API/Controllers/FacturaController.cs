using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_BinaSystem.BLL.Servicios;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DTO;

namespace Prueba_Tecnica_BinaSystem.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearFactura(FacturaDTO factura)
        {
            if (ModelState.IsValid)
            {
                if(factura.Fecha < DateOnly.FromDateTime(DateTime.Now))
                {
                    var result = await _facturaService.Crear(factura);

                    if (result != null) return Ok(result);
                    
                    return BadRequest(result);
                }

            }
            return BadRequest();
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var result = await _facturaService.Lista();

                if (result != null) return Ok(result);

                return BadRequest(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("Detalle/{id:long}")]
        public async Task<IActionResult> Obtener(long id)
        {
            try
            {
                var result = await _facturaService.Obtener(id);

                if (result != null) return Ok(result);

                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
