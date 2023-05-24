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

namespace Software2.Controllers
{
    public class CertificadoController : Controller
    {
        private readonly ILogger<CertificadoController> _logger;
        private readonly ApplicationDbContext _context;

        public CertificadoController(ILogger<CertificadoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logos()
        {
            return View(_context.DataLogos);
        }
        public IActionResult DisenarCerti()
        {
            return View();
        }
        public IActionResult Firmas()
        {
            return View(_context.DataFirmas);
        }
        public IActionResult CrearLogo()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> CrearLogo([Bind("Id,NombreInsti,ImageName")] Logos logos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Logos));
            }
            return View(logos);
        }
        public IActionResult CrearFirma()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> CrearFirma([Bind("Id,NombreFirma,ImageNameFir")] Firmas firmas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firmas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Firmas));
            }
            return View(firmas);
        }

        public async Task<IActionResult> DeleteLogo(int? id)
        {
            if (id == null || _context.DataLogos == null)
            {
                return NotFound();
            }

            var logos = await _context.DataLogos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logos == null)
            {
                return NotFound();
            }

            return View(logos);
        }

        public async Task<IActionResult> DeleteFirma(int? id)
        {
            if (id == null || _context.DataFirmas == null)
            {
                return NotFound();
            }

            var firmas = await _context.DataFirmas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (firmas == null)
            {
                return NotFound();
            }

            return View(firmas);
        }

        [HttpPost, ActionName("DeleteLogo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataLogos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataLogos'  is null.");
            }
            var logos = await _context.DataLogos.FindAsync(id);
            if (logos != null)
            {
                _context.DataLogos.Remove(logos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditFirma(int? id)
        {
            if (id == null || _context.DataFirmas == null)
            {
                return NotFound();
            }

            var firmas = await _context.DataFirmas.FindAsync(id);
            if (firmas == null)
            {
                return NotFound();
            }
            return View(firmas);
        }

        public async Task<IActionResult> EditLogo(int? id)
        {
            if (id == null || _context.DataLogos == null)
            {
                return NotFound();
            }

            var logos = await _context.DataLogos.FindAsync(id);
            if (logos == null)
            {
                return NotFound();
            }
            return View(logos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFirma(int id, [Bind("Id,NombreFirma,ImageNameFir")] Firmas firmas)
        {
            if (id != firmas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firmas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirmasExists(firmas.Id))
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
            return View(firmas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLogo(int id, [Bind("Id,NombreInsti,ImageName")] Logos logos)
        {
            if (id != logos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogosExists(logos.Id))
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
            return View(logos);
        }

        private bool FirmasExists(int id)
        {
          return (_context.DataFirmas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool LogosExists(int id)
        {
          return (_context.DataLogos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}