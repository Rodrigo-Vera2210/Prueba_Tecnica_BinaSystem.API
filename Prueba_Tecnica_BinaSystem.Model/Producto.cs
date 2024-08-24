using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.Model
{
    public class Producto
    {
        public long IdProducto { get; set; }
        public string Codigo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Categoria { get; set; } = null!;
        public ICollection<Detalle> Detalles { get; set;} = new List<Detalle>();
    }
}
