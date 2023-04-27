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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}