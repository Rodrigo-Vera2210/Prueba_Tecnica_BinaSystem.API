using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.DTO
{
    public class ProductoDTO
    {
        [Key]
        public long IdProducto { get; set; }
        [Required]
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }
        [Required]
        public string Categoria { get; set; } = null!;
        [JsonIgnore]
        public ICollection<DetalleDTO> Detalles { get; set;} = new List<DetalleDTO>();
    }
}
