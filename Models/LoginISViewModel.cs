using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    public class LoginISViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string? NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string? Contraseña { get; set; }
    }
}
