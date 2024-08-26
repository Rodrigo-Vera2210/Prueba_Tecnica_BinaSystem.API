using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using Prueba_Tecnica_BinaSystem.View.Models;
using Prueba_Tecnica_BinaSystem.View.Services;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace Prueba_Tecnica_BinaSystem.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceAPI _serviceAPI;
        private string accessCode;
        

        public HomeController(ILogger<HomeController> logger, IServiceAPI serviceAPI)
        {
            _logger = logger;
            _serviceAPI = serviceAPI;
        }

        public async Task<IActionResult> Index()
        {
            Factura factura;
            if (HttpContext.Session.GetString("factura") != null){
                factura = JsonConvert.DeserializeObject<Factura>(HttpContext.Session.GetString("factura"));
            }
            else
            {
                factura = new Factura();
            }
            var result = HttpContext.Session.GetString("access");
            if (result == null)
            {
                return this.RedirectToAction("Login","Usuario");
            }

            var clientes = await _serviceAPI.ObtenerClientes(result, null);
            var productos = await _serviceAPI.ObtenerProductos(result);

            factura.Productos = new SelectList(productos, "IdProducto", "Descripcion");
            factura.Clientes = new SelectList(clientes, "IdCliente", "Nombre");

            HttpContext.Session.SetString("factura", System.Text.Json.JsonSerializer.Serialize(factura));
            
            return View(factura);
        }

        public async Task<ActionResult> ConsultaListaCliente(string term)
        {
            var factura = JsonConvert.DeserializeObject<Factura>(HttpContext.Session.GetString("factura"));
            var result = HttpContext.Session.GetString("access");
            if (result == null)
            {
                return this.RedirectToAction("Login", "Usuario");
            }

            var clientes = await _serviceAPI.ObtenerClientes(result, term);
            var productos = await _serviceAPI.ObtenerProductos(result);

            factura.Clientes = new SelectList(clientes, "IdCliente", "Nombre");
            factura.Productos = new SelectList(productos, "IdProducto", "Descripcion");


            HttpContext.Session.SetString("factura", System.Text.Json.JsonSerializer.Serialize(factura));

            return View("Index",factura);
        }

        public async Task<ActionResult> ObtenerClientePorId(string id)
        {
            var factura = JsonConvert.DeserializeObject<Factura>(HttpContext.Session.GetString("factura"));
            var result = HttpContext.Session.GetString("access");
            if (result == null)
            {
                return this.RedirectToAction("Login", "Usuario");
            }

            var cliente = await _serviceAPI.ObtenerCliente(result, id);

            factura.Cliente = cliente;

            HttpContext.Session.SetString("factura", System.Text.Json.JsonSerializer.Serialize(factura));

            return View("Index", factura);
        }

        public async Task<JsonResult> ObtenerProductoPorId(string id)
        {
            var result = HttpContext.Session.GetString("access");
            if (result == null)
            {
                this.RedirectToAction("Login", "Usuario");
            }

            var producto = await _serviceAPI.ObtenerProducto(result, id);

            
            return Json(producto);
        }


        public IActionResult CrearProducto()
        {
            return View();
        }

        public async Task<IActionResult> ViewListaFacturas()
        {
            var result = HttpContext.Session.GetString("access");
            if (result == null)
            {
                return this.RedirectToAction("Login", "Usuario");
            }
            await _serviceAPI.ObtenerProductos(result);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
