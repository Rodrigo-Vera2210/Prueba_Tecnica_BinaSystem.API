using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DTO;

namespace Prueba_Tecnica_BinaSystem.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> CrearCliente(ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                var result = await _clienteService.Crear(cliente);

                if (result != null) return Ok(result);

                return BadRequest(result);
            }
            return BadRequest();
        }

        [HttpGet("Lista")]
        public async Task<IActionResult> Lista([FromQuery] string? searchTerm)
        {
            try
            {
                var result = await _clienteService.Lista(searchTerm);
                return Ok(result);
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
                var result = await _clienteService.Obtener(id);
                
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
