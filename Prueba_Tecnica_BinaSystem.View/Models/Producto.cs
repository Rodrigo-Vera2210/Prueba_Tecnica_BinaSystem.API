using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.View.Models
{
    public class Producto
    {
        [Key]
        public long IdProducto { get; set; }
        [Required]
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }
        [Required]
        public string Categoria { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Detalle> Detalles { get; set;} = new List<Detalle>();
    }
}
