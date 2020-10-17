using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_Detalle.Models{

    public class Moras{
        [Key] public int MoraId { get; set; }
        [Required(ErrorMessage = "Debe poner una Fecha")] public DateTime Fecha { get; set;}
        public float Total { get; set;}

        [ForeignKey("MoraId")] 
        public virtual List<MorasDetalle> MoraDetalle { get; set;} = new List<MorasDetalle>();
    }
}