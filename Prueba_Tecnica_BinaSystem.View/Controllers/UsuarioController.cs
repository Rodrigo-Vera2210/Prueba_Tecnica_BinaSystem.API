using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Prueba_Tecnica_BinaSystem.View.Models;
using Prueba_Tecnica_BinaSystem.View.Services;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Prueba_Tecnica_BinaSystem.View.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IServiceAPI _serviceAPI;

        public UsuarioController(IServiceAPI serviceAPI)
        {
            _serviceAPI = serviceAPI;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var token = await _serviceAPI.Login(usuario);
            if(token != null){
                HttpContext.Session.SetString( "access" , token);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
