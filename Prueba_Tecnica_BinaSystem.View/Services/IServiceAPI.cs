﻿using Prueba_Tecnica_BinaSystem.View.Models;

namespace Prueba_Tecnica_BinaSystem.View.Services
{
    public interface IServiceAPI
    {
        Task<string> Login(Usuario usuario);
        Task<List<Producto>> ObtenerProductos(string access);
        Task<List<Cliente>> ObtenerClientes(string access, string term);
        Task<Cliente> ObtenerCliente(string access, string id);
        Task<Producto> ObtenerProducto(string access, string id);
    }
}
