using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor_Detalle{

    public class MorasDetalle{

        [Key] public int MoraDetalleId { get; set; }
        public int MoraId { get; set;}
        public int PrestamoId { get; set;}
        public float Valor { get; set;}
    }

}