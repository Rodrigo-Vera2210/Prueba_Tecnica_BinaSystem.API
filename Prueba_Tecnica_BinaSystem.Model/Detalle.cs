using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.Model
{
    public class Detalle
    {
        [Key]
        public long IdDetalle {  get; set; }
        [Required]
        public decimal Cantidad { get; set; } = 1;
        [Required]
        public string UnidadMedida { get; set; } = null!;
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public decimal IVA { get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        public long IdFactura { get; set; }
        public long IdProducto { get; set; }
        public virtual Factura Factura { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
}
