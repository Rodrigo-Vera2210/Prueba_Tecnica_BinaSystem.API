using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.DTO
{
    public class DetalleDTO
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
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal IVA { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }
        public long IdFactura { get; set; }
        public long IdProducto { get; set; }
        [JsonIgnore]
        public virtual FacturaDTO Factura { get; set; } = null!;
        [JsonIgnore]
        public virtual ProductoDTO Producto { get; set; } = null!;
    }
}
