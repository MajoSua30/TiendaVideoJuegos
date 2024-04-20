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
    public class DetallesPedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesPedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallesPedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetallesPedido.ToListAsync());
        }

        // GET: DetallesPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesPedidos = await _context.DetallesPedido
                .FirstOrDefaultAsync(m => m.DetalleID == id);
            if (detallesPedidos == null)
            {
                return NotFound();
            }

            return View(detallesPedidos);
        }

        // GET: DetallesPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetallesPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalleID,PedidoID,ProductoID,Cantidad,PrecioUnitario")] DetallesPedido detallesPedidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesPedidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detallesPedidos);
        }

        // GET: DetallesPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesPedidos = await _context.DetallesPedido.FindAsync(id);
            if (detallesPedidos == null)
            {
                return NotFound();
            }
            return View(detallesPedidos);
        }

        // POST: DetallesPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalleID,PedidoID,ProductoID,Cantidad,PrecioUnitario")] DetallesPedido detallesPedidos)
        {
            if (id != detallesPedidos.DetalleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesPedidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesPedidosExists(detallesPedidos.DetalleID))
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
            return View(detallesPedidos);
        }

        // GET: DetallesPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesPedidos = await _context.DetallesPedido
                .FirstOrDefaultAsync(m => m.DetalleID == id);
            if (detallesPedidos == null)
            {
                return NotFound();
            }

            return View(detallesPedidos);
        }

        // POST: DetallesPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallesPedidos = await _context.DetallesPedido.FindAsync(id);
            if (detallesPedidos != null)
            {
                _context.DetallesPedido.Remove(detallesPedidos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesPedidosExists(int id)
        {
            return _context.DetallesPedido.Any(e => e.DetalleID == id);
        }
    }
}
