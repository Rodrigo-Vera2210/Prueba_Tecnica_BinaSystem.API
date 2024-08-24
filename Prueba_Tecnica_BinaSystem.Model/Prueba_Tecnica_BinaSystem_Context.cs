using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Tecnica_BinaSystem.Model
{
    public class Prueba_Tecnica_BinaSystem_Context : IdentityDbContext
    {
        public Prueba_Tecnica_BinaSystem_Context(DbContextOptions<Prueba_Tecnica_BinaSystem_Context> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Cliente> Clientes {  get; set; } 
        public DbSet<Factura> Facturas {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Factura>()
                .HasMany(c => c.Detalles)
                .WithOne(a => a.Factura)
                .HasForeignKey(a => a.IdFactura);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Facturas)
                .WithOne(a => a.Cliente)
                .HasForeignKey(a => a.IdCliente);

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Correo)
                .IsUnique();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Telefono)
                .IsUnique();

            modelBuilder.Entity<Producto>()
                .HasMany(c => c.Detalles)
                .WithOne(a => a.Producto)
                .HasForeignKey(a => a.IdProducto);

            modelBuilder.Entity<Producto>()
                .HasIndex(c => c.Codigo)
                .IsUnique();

        }
    }
}
