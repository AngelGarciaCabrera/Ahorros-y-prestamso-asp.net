using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeAhorroYPrestamos.Helpers.Validators;
using SistemaDeAhorroYPrestamos.Models;

namespace SistemaDeAhorroYPrestamos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AhorrosPrestamosContext _BaseDatos;
        private readonly ClienteValidator _validator;

        public HomeController(ILogger<HomeController> logger, AhorrosPrestamosContext baseDatos)
        {
            _logger = logger;
            _BaseDatos = baseDatos;
            _validator = new ClienteValidator();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Cliente cliente)
        {
            if (_validator.validateRegisterErrors(ModelState))
            {
                return View("login", cliente);
            }

            // Agregar a DB
            var clienteNuevo = this._BaseDatos.Add(cliente);
            var T = _BaseDatos.Clientes.Where(d => d.CuentaBanco.Numero == "12")
                .ToList();


            if (clienteNuevo.State == EntityState.Added)
            {
                return View("login", cliente);
            }

            return View("login");
        }

        public IActionResult Register()
        {
            return View("login");
        }


        [HttpPost]
        public IActionResult login(Cliente cliente)
        {
            if (_validator.validateErrors(ModelState))
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

        public IActionResult SolicitudPrestamo()
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