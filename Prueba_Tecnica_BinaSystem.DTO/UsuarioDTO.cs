﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_BinaSystem.DTO
{
    public class UsuarioDTO
    {
        public string? Nombres { get; set; } 
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

    }
}
