using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Prueba_Tecnica_BinaSystem.BLL.Servicios;
using Prueba_Tecnica_BinaSystem.BLL.Servicios.Contrato;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios;
using Prueba_Tecnica_BinaSystem.DAL.Repositorios.Contrato;
using Prueba_Tecnica_BinaSystem.Model;
using Prueba_Tecnica_BinaSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Prueba_Tecnica_BinaSystem_Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

            services.AddIdentity<Usuario, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<Prueba_Tecnica_BinaSystem_Context>().AddDefaultTokenProviders();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFacturaRepository, FacturaRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));
            
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IProductoService, ProductoService>();
        }

       
    }
}
