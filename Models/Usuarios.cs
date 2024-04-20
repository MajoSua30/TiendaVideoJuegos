using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }
        public DateTime UltimaConexion { get; set; }
        public char EstadoUsuario { get; set; }
    }
}
