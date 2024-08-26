using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.View.Models
{
    public class Cliente
    {
        [Key]
        public long IdCliente { get; set; }
        [Required]
        [MinLength(10),MaxLength(13)]
        public string Identificacion { get; set; } = null!;
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public string Direccion { get; set; } = null!;
        [Required]
        [MinLength(10)]
        public string Telefono { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Correo { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
