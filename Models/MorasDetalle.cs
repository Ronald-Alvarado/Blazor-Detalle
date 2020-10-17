using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor_Detalle.Models{

    public class MorasDetalle{

        [Key] public int MoraDetalleId { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner el Id de la Mora")] public int MoraId { get; set;}
        [Required(ErrorMessage = "Es obligatorio poner el Id del Prestamo")] public int PrestamoId { get; set;}
        public float Valor { get; set;}
    }

}