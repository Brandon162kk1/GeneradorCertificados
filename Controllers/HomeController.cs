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
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
namespace Software2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IConverter _converter;
    public HomeController(ILogger<HomeController> logger,ApplicationDbContext context,IConverter converter)
    {
        _logger = logger;
        _context = context;
        _converter = converter;

    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VistaParaPDF()
    {
        return View();
    }

    public IActionResult MostrarPDFenPagina()
    {
        string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Home/VistaParaPDF";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings() { 
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = { 
                    new ObjectSettings(){ 
                        Page = url_pagina
                    }
                }

            };

            var  archivoPDF = _converter.Convert(pdf);


            return File(archivoPDF, "application/pdf");
    }

    public IActionResult DescargarPDF()
    {
        string pagina_actual = HttpContext.Request.Path;
            string url_pagina = HttpContext.Request.GetEncodedUrl();
            url_pagina = url_pagina.Replace(pagina_actual, "");
            url_pagina = $"{url_pagina}/Home/VistaParaPDF";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pagina
                    }
                }

            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "reporte_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
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

    public IActionResult DownLoadPedidos(int id){
        
           var certificado = _context.DataVecinos.Find(id);
           byte[] archivo = certificado.archivo;
           
           if(archivo == null){
               return NotFound();
           }
           
           return File(archivo, "application/octet-stream", "Certificado.pdf");  
          
        }

}
