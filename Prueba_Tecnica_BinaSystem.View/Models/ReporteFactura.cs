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
    public class ReporteFactura
    {
        public long IdFactura { get; set; }
        public string Establecimiento { get; set; } = null!;        
        public string PuntoEmision { get; set; } = null!;
        public string NumeroFactura { get; set; } = null!;
        public DateOnly Fecha { get; set; }
        public long IdCliente {  get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalIVA { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }
        public ICollection<ReporteDetalle> Detalles { get; set; } = null!; 

    }
}
