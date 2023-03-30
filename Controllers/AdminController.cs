using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Software2.Data;

namespace Software2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context){
            _context = context;
        }
        public IActionResult Panel(){
            return View();
        }
    }
}