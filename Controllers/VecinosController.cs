using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Software2.Data;
using Software2.Models;
using DinkToPdf;
namespace Software2.Controllers
{

    public class VecinosController : Controller
    {
        private readonly ILogger<VecinosController> _logger;
        private readonly ApplicationDbContext _context;

        public VecinosController(ILogger<VecinosController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            var vecinos = from o in _context.DataVecinos select o;
            if(!String.IsNullOrEmpty(searchString)){
                vecinos = vecinos.Where(s => s.Dni.Contains(searchString));
            }
            return View(await vecinos.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Dni,Celular,Correo,Evento")] Vecinos vecino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vecino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vecino);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataVecinos == null)
            {
                return NotFound();
            }

            var vecinos = await _context.DataVecinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vecinos == null)
            {
                return NotFound();
            }

            return View(vecinos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataVecinos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataVecinos'  is null.");
            }
            var vecinos = await _context.DataVecinos.FindAsync(id);
            if (vecinos != null)
            {
                _context.DataVecinos.Remove(vecinos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataVecinos == null)
            {
                return NotFound();
            }

            var vecinos = await _context.DataVecinos.FindAsync(id);
            if (vecinos == null)
            {
                return NotFound();
            }
            return View(vecinos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Correo,Celular,Dni,Evento")] Vecinos vecinos)
        {
            if (id != vecinos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vecinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VecinosExists(vecinos.Id))
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
            return View(vecinos);
        }

        private bool VecinosExists(int id)
        {
          return (_context.DataVecinos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}