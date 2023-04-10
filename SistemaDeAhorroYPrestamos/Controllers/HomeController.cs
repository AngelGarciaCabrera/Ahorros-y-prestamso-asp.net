using Microsoft.AspNetCore.Mvc;

using SistemaDeAhorroYPrestamos.Models;
using System.Diagnostics;


namespace SistemaDeAhorroYPrestamos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            
            return View("login");
        }


        [HttpPost]
        public IActionResult login(Cliente cliente)
        {
            if (ModelState.ContainsKey("Cedula") && ModelState["Cedula"].Errors.Count != 0 ||
                ModelState.ContainsKey("Contrasena") && ModelState["Contrasena"].Errors.Count != 0)
            {
                return View(cliente);
            }

            return RedirectToAction("SegundoHome");
        }

        public IActionResult login()
        {
                return View();
           
        }

        public IActionResult SolicitudDePrestamo()
        {
            return View();
        }
        public IActionResult AboutUS()
        {
            return View();
        }

      
        public IActionResult SegundoHome(Cliente cliente)
        {
            return View();
        } 
        public IActionResult SolicitudDeInversion()
        {
            return View();
        }

        public IActionResult TablaPrestamos()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}