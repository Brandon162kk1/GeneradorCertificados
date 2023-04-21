using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Software2.Data;
using Microsoft.EntityFrameworkCore;
using Software2.Models;
using Microsoft.AspNetCore.Identity;

namespace Software2.Controllers
{
    public class EventosController : Controller
    {
        private readonly ILogger<EventosController> _logger;
        private readonly ApplicationDbContext _context;

        public EventosController(ILogger<EventosController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.DataEventos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}