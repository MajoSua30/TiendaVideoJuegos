using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    // Modelo de Vista Registro
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene el formato correcto")]
        public string? NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string? Contraseña { get; set; }

        [Required(ErrorMessage = "La estado es requerido")]
        public char EstadoUsuario { get; set; }
    }
}
