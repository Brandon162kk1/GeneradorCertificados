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
namespace Software2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;

    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Listar(string searchString)
    {
        var lista = _context.DataVecinos.ToList();
        var query1 = lista;

        if(searchString != null){

            //GeneratePdfReport(itemsPDF.ToList());//
            //_context.Add(formato);//
            
            query1 = query1.Where(p => p.Dni.Contains(searchString)).ToList();
            ViewData["Message"] = "Hola"+" "+searchString+" se encontraron certificados";

        }else{
            return View("Index");
        }

        var resultado = query1.ToList();

        return View(resultado);
    }

    public IActionResult VistaPago()
        {
            return View();
            //return View("RegistrarPagoSubmit");
        }

        public IActionResult Pagar()
        {
            return View("PagoConfirmado");
        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
