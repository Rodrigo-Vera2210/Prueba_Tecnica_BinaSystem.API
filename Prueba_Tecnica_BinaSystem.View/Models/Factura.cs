using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.View.Models
{
    public class Factura
    {
        [Key]
        public long IdFactura { get; set; }
        [Required]
        public string Establecimiento { get; set; } = null!;
        [Required]
        public string PuntoEmision { get; set; } = null!;
        [Required]
        public string NumeroFactura { get; set; } = null!;
        public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public long IdCliente {  get; set; }
        public ICollection<Detalle> Detalles { get; set; } = null!;
        public SelectList Clientes { get; set; }
        public SelectList Productos { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
