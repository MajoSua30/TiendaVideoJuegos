using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    public class DetallesPedido
    {
        [Key]
        public int DetalleID { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
