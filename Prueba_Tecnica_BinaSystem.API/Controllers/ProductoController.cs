using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DTO;

namespace Prueba_Tecnica_BinaSystem.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearProducto(ProductoDTO producto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productoService.Crear(producto);

                if(result != null) return Ok(result);

                return BadRequest(result);
            }
            return BadRequest();
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> Lista([FromQuery] string? searchTerm)
        {
            try
            {
                var result = await _productoService.Lista(searchTerm);
                
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
                var result = await _productoService.Obtener(id);
                
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
