using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiendaJuegos.Models;

namespace TiendaJuegos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TiendaJuegos.Models.Productos> Productos { get; set; } = default!;
        public DbSet<TiendaJuegos.Models.Usuarios> Usuarios { get; set; } = default!;
        public DbSet<TiendaJuegos.Models.Pedidos> Pedidos { get; set; } = default!;
        public DbSet<TiendaJuegos.Models.DetallesPedido> DetallesPedido { get; set; } = default!;
        public DbSet<TiendaJuegos.Models.CarritoCompras> CarritoCompras { get; set; } = default!;


    }
}
