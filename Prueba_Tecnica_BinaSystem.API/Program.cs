using Microsoft.AspNetCore.Identity;
using Prueba_Tecnica_BinaSystem.IOC;
using Prueba_Tecnica_BinaSystem.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InyectarDependencia(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins("https://localhost:7178","http://localhost:5133", "*");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

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

    }

}

app.Run();
