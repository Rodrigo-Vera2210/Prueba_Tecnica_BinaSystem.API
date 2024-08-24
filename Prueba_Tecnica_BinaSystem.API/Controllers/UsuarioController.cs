using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DTO;

namespace Prueba_Tecnica_BinaSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IConfiguration config, IUsuarioService usuarioService, IMapper mapper)
        {
            _config = config;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuario)
        {
            IActionResult response = Unauthorized();

            var user = await _usuarioService.AuthenticateUser(usuario.Email, usuario.Password);

            if (user != null)
            {
                var token = _usuarioService.GenerateToken(user);
                response = Ok(new { token = token });
            }

            return response;
        }
    }
}
