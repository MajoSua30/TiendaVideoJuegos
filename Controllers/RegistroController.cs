using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TiendaJuegos.Models;
using TiendaJuegos.Data;
using Microsoft.EntityFrameworkCore;
namespace TiendaJuegos.Controllers
{
    public class RegistroController : Controller
    {
        //Controlador de los Usuarios
        private readonly ApplicationDbContext _context;
        public RegistroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Usuarios/RegisterUsuarios
        public IActionResult Register()
        {
            return View();
        }
        // POST: Usuarios/RegisterUsuarios
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuarios
                {
                    NombreUsuario = model.NombreUsuario,
                    Contraseña = HashPassword(model.Contraseña),
                    UltimaConexion = DateTime.Now,
                    EstadoUsuario = model.EstadoUsuario
                };
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

   

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // GET: Usuarios
        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }
        // GET: Usuarios/CreateUsuarios
        public IActionResult CreateUsuario()
        {
            return View();
        }
       
    }

    




}
