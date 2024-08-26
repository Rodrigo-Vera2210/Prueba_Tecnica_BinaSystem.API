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
    public class ReporteDetalle
    {
        [Key]
        public long IdDetalle {  get; set; }
        [Column(TypeName = "decimal(10, 0)")]
        public decimal Cantidad { get; set; } = 1;
        public string UnidadMedida { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal IVA { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }
        public virtual Producto Producto { get; set; } = null!;
    }
}
