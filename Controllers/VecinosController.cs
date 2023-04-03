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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}