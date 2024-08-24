using Prueba_Tecnica_BinaSystem.DTO;
using Prueba_Tecnica_BinaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> AuthenticateUser(string email, string password);
        public string GenerateToken(UsuarioDTO usuario);
        Task<UsuarioDTO> ConsultaPorEmail(string email);
    }
}
