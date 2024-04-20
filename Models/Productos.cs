using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }
        public string? NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int DisponibilidadInventario { get; set; }
        public string? VideoURL { get; set; }
        public char EstadoProducto { get; set; }
    }
}
