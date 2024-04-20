using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaJuegos.Data;
using TiendaJuegos.Models;

namespace TiendaJuegos.Controllers
{
    public class CarritoComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarritoCompras
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarritoCompras.ToListAsync());
        }

        // GET: CarritoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoCompras = await _context.CarritoCompras
                .FirstOrDefaultAsync(m => m.UsuarioID == id);
            if (carritoCompras == null)
            {
                return NotFound();
            }

            return View(carritoCompras);
        }

        // GET: CarritoCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarritoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioID,ProductoID,Cantidad")] CarritoCompras carritoCompras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carritoCompras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carritoCompras);
        }

        // GET: CarritoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoCompras = await _context.CarritoCompras.FindAsync(id);
            if (carritoCompras == null)
            {
                return NotFound();
            }
            return View(carritoCompras);
        }

        // POST: CarritoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioID,ProductoID,Cantidad")] CarritoCompras carritoCompras)
        {
            if (id != carritoCompras.UsuarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carritoCompras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoComprasExists(carritoCompras.UsuarioID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carritoCompras);
        }

        // GET: CarritoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoCompras = await _context.CarritoCompras
                .FirstOrDefaultAsync(m => m.UsuarioID == id);
            if (carritoCompras == null)
            {
                return NotFound();
            }

            return View(carritoCompras);
        }

        // POST: CarritoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carritoCompras = await _context.CarritoCompras.FindAsync(id);
            if (carritoCompras != null)
            {
                _context.CarritoCompras.Remove(carritoCompras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoComprasExists(int id)
        {
            return _context.CarritoCompras.Any(e => e.UsuarioID == id);
        }
    }
}
