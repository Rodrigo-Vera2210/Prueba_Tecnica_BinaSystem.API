using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.Model
{
    public class Cliente
    {
        [Key]
        public long IdCliente { get; set; }
        [Required]
        public string Identificacion { get; set; } = null!;
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public string Direccion { get; set; } = null!;
        [Required]
        public string Telefono { get; set; } = null!;
        [Required]
        public string Correo { get; set; } = null!;
        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
