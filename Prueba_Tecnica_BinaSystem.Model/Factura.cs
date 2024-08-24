using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.Model
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
        [Required]
        public DateOnly Fecha { get; set; }
        public long IdCliente {  get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public decimal TotalIVA { get; set; }
        [Required]
        public decimal Total { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public ICollection<Detalle> Detalles { get; set; } = null!; 

    }
}
