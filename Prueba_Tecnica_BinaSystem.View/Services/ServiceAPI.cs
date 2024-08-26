
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using NuGet.Protocol;
using Prueba_Tecnica_BinaSystem.View.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json; 

namespace Prueba_Tecnica_BinaSystem.View.Services
{
    public class ServiceAPI : IServiceAPI
    {
        private readonly string _urlBase;
        public ServiceAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _urlBase = builder.GetSection("ApiSettings:urlBase").Value;
        }

        public async Task<string> Login(Usuario usuario)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_urlBase);

            using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"api/usuario", jsonContent);

            if(response.StatusCode == System.Net.HttpStatusCode.OK){
                var dato = await response.Content.ReadAsStringAsync();
                var dato2 = JsonConvert.DeserializeObject<dynamic>(dato);
                var token = dato2.token;

                return (token);
            }
            return null;
        }

        public async Task<string> CrearFactura(Factura factura, string access)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_urlBase);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(factura), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"api/factura/crear", jsonContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return ("Factura Creada");
            }
            return null;
        }
        
        public async Task<List<Producto>> ObtenerProductos(string access)
        {
            var cliente = new HttpClient();
            List<Producto> resultado = null;
            cliente.BaseAddress = new Uri(_urlBase);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            var response = await cliente.GetAsync($"api/producto/lista");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<Producto>>(json_response);
            }

            return resultado;


        }
        
        public async Task<List<ReporteFactura>> ObtenerFacturas(string access)
        {
            var cliente = new HttpClient();
            List<ReporteFactura> resultado = null;
            cliente.BaseAddress = new Uri(_urlBase);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            var response = await cliente.GetAsync($"api/factura/lista");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<ReporteFactura>>(json_response);
            }

            return resultado;


        }
        
        public async Task<List<Cliente>> ObtenerClientes(string access, string term)
        {
            var cliente = new HttpClient();
            List<Cliente> resultado = null;
            cliente.BaseAddress = new Uri(_urlBase);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            HttpResponseMessage response;
            if (term != null){
                response = await cliente.GetAsync($"api/cliente/lista?searchTerm={term}");
            }
            else
            {
                response = await cliente.GetAsync($"api/cliente/lista");
            } 

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<List<Cliente>>(json_response);
            }

            return resultado;


        }
        
        public async Task<Cliente> ObtenerCliente(string access, string id)
        {
            var cliente = new HttpClient();
            Cliente resultado = null;
            cliente.BaseAddress = new Uri(_urlBase);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            HttpResponseMessage response;
            
            response = await cliente.GetAsync($"api/cliente/detalle/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<Cliente>(json_response);
            }

            return resultado;


        }

        public async Task<Producto> ObtenerProducto(string access, string id)
        {
            var cliente = new HttpClient();
            Producto resultado = null;
            cliente.BaseAddress = new Uri(_urlBase);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            HttpResponseMessage response;
            
            response = await cliente.GetAsync($"api/producto/detalle/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();

                resultado = JsonConvert.DeserializeObject<Producto>(json_response);
            }

            return resultado;


        }

        public async Task<string> CrearProducto(Producto producto, string access)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_urlBase);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(producto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"api/producto/crear", jsonContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return ("Producto Creado");
            }
            return null;
        }

        public async Task<string> CrearCliente(Cliente cliente, string access)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_urlBase);
            clienteHttp.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);

            using StringContent jsonContent = new(System.Text.Json.JsonSerializer.Serialize(cliente), Encoding.UTF8, "application/json");

            var response = await clienteHttp.PostAsync($"api/cliente/crear", jsonContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return ("Cliente Creado");
            }
            return null;
        }
    }
}
