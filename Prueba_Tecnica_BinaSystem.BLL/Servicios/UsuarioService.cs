using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato;
using Prueba_Tecnica_BinaSystem.DTO;
using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.BLL.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private IConfiguration _config;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepository, IMapper mapper, UserManager<Usuario> userManager, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _userManager = userManager;
            _config = configuration;
        }

        public async Task<UsuarioDTO> AuthenticateUser(string email, string password)
        {
            var usuario = await _userManager.FindByNameAsync(email);

            if (usuario == null) throw new TaskCanceledException("No se encontro al usuario");

            var result = await _userManager.CheckPasswordAsync(usuario, password);

            if (!result) throw new TaskCanceledException("Password no es el correcto");

            return _mapper.Map<UsuarioDTO>(usuario);
            
        }

        public string GenerateToken(UsuarioDTO usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);

            var claims = new[]{
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<UsuarioDTO> ConsultaPorEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
