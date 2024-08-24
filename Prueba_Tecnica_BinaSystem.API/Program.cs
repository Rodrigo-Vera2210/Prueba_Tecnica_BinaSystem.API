using Microsoft.AspNetCore.Identity;
using Prueba_Tecnica_BinaSystem.IOC;
using Prueba_Tecnica_BinaSystem.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InyectarDependencia(builder.Configuration);

//builder.Services.AddCors(options =>
//{
//    options
//})

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var usuarioManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();

    string email = "admin@admin.com";
    string password = "ADmin#2210";


    if (await usuarioManager.FindByEmailAsync(email) == null)
    {
        var user = new Usuario()
        {
            Nombres = "Admin Admin",
            UserName = email,
            Email = email,
            EmailConfirmed = true,
        };

        await usuarioManager.CreateAsync(user, password);

        await usuarioManager.AddToRoleAsync(user, "Administrador");
    }

}

app.Run();
