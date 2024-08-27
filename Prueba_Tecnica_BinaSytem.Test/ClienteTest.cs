using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prueba_Tecnica_BinaSystem.API.Controllers;
using Prueba_Tecnica_BinaSystem.BLL.Servicios;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato;
using Prueba_Tecnica_BinaSystem.Model;
using Prueba_Tecnica_BinaSystem.Utility;

namespace Prueba_Tecnica_BinaSytem.Test
{
    public class ClienteTest
    {
        Prueba_Tecnica_BinaSystem_Context _dbContext;
        ProductoController _controller;
        IProductoService _service;
        IGenericRepository<Producto> _productoRepository;
        UsuarioController _usuarioController;
        IUsuarioService _usuarioService;
        IGenericRepository<Usuario> _usuarioRepository;
        UserManager<Usuario> _userManager;
        IConfiguration _config;
        IMapper _mapper;

        public ClienteTest()
        {
            var options = new DbContextOptionsBuilder<Prueba_Tecnica_BinaSystem_Context>()
                .UseSqlServer("Server=(local); DataBase=BINASYSTEM; Trusted_Connection=True; TrustServerCertificate=True;").Options;
            _dbContext = new Prueba_Tecnica_BinaSystem_Context(options);
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
            _productoRepository = new GenericRepository<Producto>(_dbContext);
            _service = new ProductoService(_productoRepository, _mapper);
            _controller = new ProductoController(_service);


            _usuarioRepository = new GenericRepository<Usuario>(_dbContext);
            _usuarioService = new UsuarioService(_usuarioRepository, _mapper, _userManager, _config);
            _usuarioController = new UsuarioController(_service);
        }
        [Fact]
        public void ConsultaClientesSinTerminos()
        {

        }
    }
}