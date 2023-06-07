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
            url_pagina = $"{url_pagina}/Home/Listar";


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
    public IActionResult DescargarPDF(int id)
    {  

    var cabecera = $@"
     
      <!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"" crossorigin=""anonymous"">
    <link rel=""stylesheet"" href=""~/css/pdf.css"">
    <title>Certificado Virtual</title>
</head>
<body>
<div class=""row"">
<div class=""col-lg-4 mx-auto"">
<p>Se le otorga el presente certificado a:</p><br>
<h1><strong>Nombre del Usuario<strong></h1><br>
<p class=""text-left"">Por haber participado en el CONGRESO INTERNACIONAL DE INGENIERÍA, CIENCIAS
AERONÁUTICAS Y ARQUIFORO - XXV EDICIÓN: TRANSFORMACIÓN DIGITAL PARA UN
MUNDO SOSTENIBLE: RETOS POST COVID-19.
Realizado los días 26 y 27 de noviembre de 2020 de manera virtual. Facultad de
Ingeniería y Arquitectura de la Universidad de San Martín de Porres, Lima - Perú.</p>
</div>
<div class=""col-lg-4 mx-auto"">
<p>Se le otorga el presente certificado a:</p><br>
<h1><strong>Nombre del Usuario<strong></h1><br>
<p class=""text-left"">Por haber participado en el CONGRESO INTERNACIONAL DE INGENIERÍA, CIENCIAS
AERONÁUTICAS Y ARQUIFORO - XXV EDICIÓN: TRANSFORMACIÓN DIGITAL PARA UN
MUNDO SOSTENIBLE: RETOS POST COVID-19.
Realizado los días 26 y 27 de noviembre de 2020 de manera virtual. Facultad de
Ingeniería y Arquitectura de la Universidad de San Martín de Porres, Lima - Perú.</p>
</div>
<div class=""col-lg-4 mx-auto"">
<p>Se le otorga el presente certificado a:</p><br>
<h1><strong>Nombre del Usuario<strong></h1><br>
<p class=""text-left"">Por haber participado en el CONGRESO INTERNACIONAL DE INGENIERÍA, CIENCIAS
AERONÁUTICAS Y ARQUIFORO - XXV EDICIÓN: TRANSFORMACIÓN DIGITAL PARA UN
MUNDO SOSTENIBLE: RETOS POST COVID-19.
Realizado los días 26 y 27 de noviembre de 2020 de manera virtual. Facultad de
Ingeniería y Arquitectura de la Universidad de San Martín de Porres, Lima - Perú.</p>
</div>
</div>

</body>
     "; 
     

     var footer = $@"
     
<footer>
        <p>El monto a pagar fue: S.500</p>
    

    
      </footer>
   </html>
     
     ";

     cabecera += footer;

GlobalSettings globalSettings = new GlobalSettings();
globalSettings.ColorMode = ColorMode.Color;
globalSettings.Orientation = Orientation.Landscape;
globalSettings.PaperSize = PaperKind.A4;
 globalSettings.Margins = new MarginSettings { Top = 25, Bottom = 25 };
 ObjectSettings objectSettings = new ObjectSettings();
 objectSettings.PagesCount = true;
 objectSettings.HtmlContent = cabecera;
 WebSettings webSettings = new WebSettings();
 webSettings.DefaultEncoding = "utf-8";
 HeaderSettings headerSettings = new HeaderSettings();
 headerSettings.FontSize = 18;
 headerSettings.FontName = "Ariel";
 headerSettings.Center = "Municipalidad de la Molina";
 headerSettings.Line = true;
 FooterSettings footerSettings = new FooterSettings();
 footerSettings.FontSize = 18;
 footerSettings.FontName = "Ariel";
 footerSettings.Center = "No olvide descargar su certificado";
 footerSettings.Line = true;
 objectSettings.HeaderSettings = headerSettings;
 objectSettings.FooterSettings = footerSettings;
 objectSettings.WebSettings = webSettings;
        HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings },
        };
        var archivoPDF = _converter.Convert(htmlToPdfDocument);
        string nombrePDF = "certificado_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

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
