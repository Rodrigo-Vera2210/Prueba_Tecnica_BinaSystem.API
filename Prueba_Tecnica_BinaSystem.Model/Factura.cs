﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.Model
{
    public class Factura
    {
        [Key]
        public long IdFactura { get; set; }
        [Required]
        [Length(3, 3, ErrorMessage = "El codigo debe tener 3 digitos")]
        public string Establecimiento { get; set; } = null!;
        [Required]
        [Length(3, 3, ErrorMessage = "El codigo debe tener 3 digitos")]
        public string PuntoEmision { get; set; } = null!;
        [Required]
        [Length(8, 8, ErrorMessage = "El codigo debe tener 8 digitos")]
        public string NumeroFactura { get; set; } = null!;
        [Range(typeof(DateOnly), "1/2/1955", "31/8/2024",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateOnly Fecha { get; set; }
        public long IdCliente {  get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalIVA { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public ICollection<Detalle> Detalles { get; set; } = null!; 

    }
}
