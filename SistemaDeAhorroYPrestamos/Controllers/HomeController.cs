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
        public IActionResult AboutUS()
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
                HttpContext.Session.SetString(IKeysData.CEDULA, cliente.Cedula);
                return View("SegundoHome");
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

            HttpContext.Session.SetString(IKeysData.CEDULA, cliente.Cedula);

            return RedirectToAction("SegundoHome");
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult SolicitudDePrestamo()
        {
            var cedulaLogueda = HttpContext.Session.GetString(IKeysData.CEDULA);
            if (cedulaLogueda == null)
            {
                return RedirectToAction("Index");
            }

            var codigo = new Random().Next(1, 1000);

            var prestamo = new Prestamo() { Codigo = codigo, ClienteCedula = cedulaLogueda };
            return View(prestamo);
        }

        [HttpPost]
        public IActionResult SolicitudDePrestamo([FromForm] Prestamo prestamo, string botonPresionado,CuotaPrestamo cuotaPrestamo)
        {
            var dias = (prestamo.FechaEnd - prestamo.FechaBeg).TotalDays;
            var interes = dias / 365 * 0.1D * (double)prestamo.Monto;
            prestamo.Interes = (decimal)Math.Round(interes, 2) / 100;

            var fechaPago = prestamo.FechaEnd.AddDays(1);
            var duracionMeses = (int)Math.Ceiling(dias / 30.0);
            var numCuotas = duracionMeses + 1;
            var montoMensual = (prestamo.Monto + prestamo.Interes) / numCuotas;
            
            //alamcenar en cuotasPrestamo
            prestamo.Codigo = cuotaPrestamo.PrestamoCodigo;
            cuotaPrestamo.Monto = montoMensual;
            cuotaPrestamo.FechaPlanificacion = fechaPago;
            cuotaPrestamo.FechaRealizado = prestamo.FechaBeg;
            
            switch (botonPresionado)
            {
                case "CalcularInteres":
                    
                    break;
                case "Enviar":
                    var PrestamosLogeados =
                        _BaseDatos.Prestamos.SingleOrDefault(C =>
                            C.Codigo == prestamo.Codigo && C.ClienteCedula == prestamo.ClienteCedula);
                    if (PrestamosLogeados == null)
                    {
                        // Guardar el préstamo en la base de datos
                        _BaseDatos.Prestamos.Add(prestamo);
                        _BaseDatos.SaveChanges();
                        ModelState.AddModelError("", "Prestamo Agregado");
                        return RedirectToAction("TablaPrestamos");
                        
                        
                    }
                    if (PrestamosLogeados.Codigo == prestamo.Codigo)
                    {
                        ModelState.AddModelError("", "Prestamo existente");

                        return View("SegundoHome");
                    }
                    return RedirectToAction("SegundoHome");
                
                case "eliminar":
                    return RedirectToAction("SegundoHome",prestamo);
            }
           


            return View(prestamo);
        }


        [HttpGet]
        public IActionResult SegundoHome()
        {
            // Si no lo contiene
            var cedulaLogueada = HttpContext.Session.GetString(IKeysData.CEDULA);

            if (cedulaLogueada == null)
            {
                return RedirectToAction("login");
            }

            var cliente = _BaseDatos.Clientes.FirstOrDefault(c => c.Cedula == cedulaLogueada);

            return View(cliente);
        }

        public IActionResult SolicitudDeInversion()
        {
            return View();
        }

        public IActionResult TablaPrestamos( Prestamo prestamo, CuotaPrestamo cuotaPrestamo)
        {
            cuotaPrestamo.Monto = prestamo.Monto;
            cuotaPrestamo.PrestamoCodigo = prestamo.Codigo;
          
           
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            var requestCookie = Request.Cookies[IKeysData.ICookie.COOKIE_USER_KEY];
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}