using System.Diagnostics;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeAhorroYPrestamos.Helpers.Validators;
using SistemaDeAhorroYPrestamos.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using SistemaDeAhorroYPrestamos.Helpers;

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

        public IActionResult SolicitudDePrestamo()
        {
            // var prestamo = JsonConvert.DeserializeObject<Prestamo>(TempData["Prestamo"].ToString());
            // return View(prestamo);
            return View();
        }

        [HttpPost]
        public IActionResult SolicitudDePrestamo(Prestamo prestamo, string botonPresionado)
        {
            if (botonPresionado == "CalcularInteres")
            {
                var dias = (prestamo.FechaEnd - prestamo.FechaBeg).TotalDays;
                var interes = dias / 365 * (double)0.1m * (double)prestamo.Monto;
                prestamo.Interes = (decimal)Math.Round(interes, 2);
                TempData["Interes"] = prestamo.Interes; // Guardar el valor de interés en TempData
                return View(prestamo);
            }

            if (botonPresionado == "Enviar")
            {
                // Código para enviar el formulario
            }

            if (botonPresionado == "eliminar")
            {
                // Código para limpiar el formulario
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}