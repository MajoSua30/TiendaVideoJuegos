using System.ComponentModel.DataAnnotations;

namespace TiendaJuegos.Models
{
    public class Pedidos
    {
        [Key]
        public int PedidoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}
