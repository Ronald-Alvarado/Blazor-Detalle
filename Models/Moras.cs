using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor_Detalle{

    public class Moras{
        [Key] public int MorasId { get; set; }
        public DateTime Fecha { get; set;}
        public float Total { get; set;}
    }
}