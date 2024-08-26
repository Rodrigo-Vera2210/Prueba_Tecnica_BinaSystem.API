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
    public class Detalle
    {
        [Key]
        public long IdDetalle {  get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 0)")]
        public decimal Cantidad { get; set; } = 1;
        [Required]
        public string UnidadMedida { get; set; } = null!;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
        public long IdProducto { get; set; }
    }
}
