using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor_Detalle
{
    public class Persona
    {
        [Key] public int PersonaId { get; set; }

        [Required(ErrorMessage = "Debe poner un Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe poner un Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe poner una Cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe poner una Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe poner una Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public float Balance { get; set; }
    }
}