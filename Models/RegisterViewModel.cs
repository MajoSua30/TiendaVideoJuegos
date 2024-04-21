using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    // Modelo de Vista Registro
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string? NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string? Contraseña { get; set; }

        [Required(ErrorMessage = "La estado es requerido")]
        public char EstadoUsuario { get; set; }
    }
}
