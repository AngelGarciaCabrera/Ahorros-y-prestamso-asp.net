using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaDeAhorroYPrestamos.Helpers;
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
            var clienteNuevo = this._BaseDatos.Clientes
                .FirstOrDefault(c => c.Nombre == cliente.Nombre || c.Cedula == cliente.Cedula);

            if (clienteNuevo == null)
            {
                _BaseDatos.Add(cliente);
                _BaseDatos.SaveChanges();
                Console.WriteLine("se agrego");

                //Guarda al usuario en la sesion
                TempData[IKeysData.CEDULA] = cliente.Cedula;
                return View("login");
            }
            else
            {
                ModelState.AddModelError("", "Ya el usuario existe.");
                return View("login", cliente);
            }
        }

        public IActionResult Register()
        {
            return View("login");
        }


        [HttpPost]
        public IActionResult login(Cliente cliente)
        {
            var UsuarioLogiados =
                _BaseDatos.Clientes.SingleOrDefault(C =>
                    C.Cedula == cliente.Cedula && C.Contrasena == cliente.Contrasena);
            if (UsuarioLogiados == null)
            {
                ModelState.AddModelError("", "Usuario no encontrado");
                return View("login", cliente);
            }

            if (UsuarioLogiados.Contrasena != cliente.Contrasena)
            {
                ModelState.AddModelError("", "La contraseña no es valida");

                return View("login");
            }

            TempData[IKeysData.CEDULA] = UsuarioLogiados.Cedula;

            return RedirectToAction("SegundoHome", "Home", new { cedula = cliente.Cedula });
        }

        public IActionResult login()
        {
            return View();
        }

        ///Home/SegundoHome
        public IActionResult AboutUS()
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

        public IActionResult SolicitudDePrestamo()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SolicitudDePrestamo(Prestamo prestamo, string botonPresionado)
        {
            switch (botonPresionado)
            {
                case "CalcularInteres":
                    var dias = (prestamo.FechaEnd - prestamo.FechaBeg).TotalDays;
                    var interes = dias / 365 * 0.1 * (double)prestamo.Monto;
                    prestamo.Interes = (decimal)Math.Round(interes, 2);
                    return View(prestamo);

                case "Enviar": // Código para enviar el formulario
                    break;
                case "eliminar": // Código para limpiar el formulario
                    break;
            }

            return View(prestamo);
        }


        public IActionResult SegundoHome()
        {
            // Si no lo contiene
            if (!TempData.ContainsKey(IKeysData.CEDULA))
            {
                return RedirectToAction("login");
            }

            var cedula = TempData[IKeysData.CEDULA];
            var cliente = _BaseDatos.Clientes.FirstOrDefault(c => c.Cedula == cedula);

            return View(cliente);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}