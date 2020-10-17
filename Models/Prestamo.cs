using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_Detalle.Models
{
    public class Prestamo
    {
        [Key] public int PrestamoId { get; set; }
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Debe poner una Fecha de Creación")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe de poner un Concepto")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "Debe poner un Monto")]
        public float Monto { get; set; }        
        public float Balance { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual List<MorasDetalle> MoraDetalle { get; set;} = new List<MorasDetalle>();
    }
}