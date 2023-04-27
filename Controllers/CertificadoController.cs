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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}