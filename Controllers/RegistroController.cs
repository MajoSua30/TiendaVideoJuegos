using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TiendaJuegos.Data;
using TiendaJuegos.Models;

namespace TiendaJuegos.Controllers
{
    public class RegistroController : Controller
    {
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
                // Verificar si ya existe un usuario con el mismo correo electrónico
                if (_context.Usuarios.Any(u => u.NombreUsuario == model.NombreUsuario))
                {
                    ModelState.AddModelError(nameof(model.NombreUsuario), "El correo electrónico ya está en uso");
                    return View(model);
                }

                var usuario = new Usuarios
                {
                    NombreUsuario = model.NombreUsuario, // Utiliza el correo electrónico como nombre de usuario
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

        // GET: Registro/LoginIS
        public IActionResult LoginIS()
        {
            return View();
        }

        // POST: Registro/LoginIS
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginIS(LoginISViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hash the password to match with the stored hash in the database
                string hashedPassword = HashPassword(model.Contraseña);

                // Check if the user with provided credentials exists in the database
                var user = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario && u.Contraseña == hashedPassword);

                if (user != null)
                {
                    // Update last login time
                    user.UltimaConexion = DateTime.Now;
                    _context.SaveChanges();

                    // Redirect to Home or any other desired page upon successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Add a model error for invalid credentials
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                }
            }
            // If ModelState is not valid, return the view with the model (including validation errors)
            return View(model);
        }

        // Utility method to hash the password
        private string HashPassword(string? password)
        {
            // Verifica si la contraseña es nula o vacía
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "La contraseña no puede ser nula o vacía");
            }

            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
