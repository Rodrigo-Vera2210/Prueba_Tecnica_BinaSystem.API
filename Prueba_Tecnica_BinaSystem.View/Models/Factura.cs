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
        [Length(3, 3, ErrorMessage = "El establecimiento debe tener 3 digitos")]
        public string Establecimiento { get; set; } = null!;
        [Required]
        [Length(3, 3, ErrorMessage = "El punto de emision debe tener 3 digitos")]
        public string PuntoEmision { get; set; } = null!;
        [Required]
        [Length(8, 8, ErrorMessage = "El numero de factura debe tener 8 digitos")]
        public string NumeroFactura { get; set; } = null!;
        [Range(typeof(DateOnly), "1/2/1955", "31/8/2024",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateOnly Fecha { get; set; }
        public long IdCliente {  get; set; }
        public ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();
        public SelectList Clientes { get; set; }
        public SelectList Productos { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
