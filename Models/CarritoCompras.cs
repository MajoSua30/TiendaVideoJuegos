using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    public class CarritoCompras
    {
        [Key]
        public int UsuarioID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
    }
}
