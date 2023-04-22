using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                var entityEntry = _BaseDatos.Add(cliente);

                if (entityEntry.State == EntityState.Added)
                {
                    CuentaBanco cuentaBanco = new CuentaBanco();
                    cuentaBanco.ClienteCedula = cliente.Cedula;
                    cuentaBanco.Numero = new Random().NextInt64(1_000_000_000, 10_000_000_000).ToString();
                    cuentaBanco.Banco = "BANKCC";
                    cuentaBanco.Tipo = "COMUN";

                    _BaseDatos.CuentaBancos.Add(cuentaBanco);
                    cliente.IdCuentaBanco = cuentaBanco.Numero;
                    _BaseDatos.SaveChanges();
                    Console.WriteLine("se agrego");


                    //Guarda al usuario en la sesion
                    HttpContext.Session.SetString(IKeysData.CEDULA, cliente.Cedula);
                    return View("SegundoHome");
                }

                //Guarda al usuario en la sesion
                HttpContext.Session.SetString(IKeysData.CEDULA, cliente.Cedula);
                return RedirectToAction("SegundoHome");
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
        public IActionResult SolicitudDePrestamo([FromForm] Prestamo prestamo, string botonPresionado)
        {
            var dias = (prestamo.FechaEnd - prestamo.FechaBeg).TotalDays;
            var interes = dias / 365 * 0.1D * (double)prestamo.Monto;
            prestamo.Interes = (decimal)Math.Round(interes, 2) / 100;

            var fechaPago = prestamo.FechaEnd.AddDays(1);
            var duracionMeses = (int)Math.Ceiling(dias / 30.0);
            var numCuotas = duracionMeses + 1;
            var montoMensual = (prestamo.Monto + prestamo.Interes) / numCuotas;

            //alamcenar en cuotasPrestamo
            CuotaPrestamo cuotaPrestamo = new CuotaPrestamo();
            cuotaPrestamo.PrestamoCodigo = prestamo.Codigo;
            cuotaPrestamo.FechaRealizado = prestamo.FechaBeg;
            cuotaPrestamo.Monto = montoMensual;
            cuotaPrestamo.FechaPlanificacion = fechaPago;
            cuotaPrestamo.ClienteCedula = prestamo.ClienteCedula;
           
            
            

            switch (botonPresionado)
            {
                case "CalcularInteres":

                    break;
                case "Enviar":

                    // Guardar el préstamo en la base de datos
                    var entityEntry = _BaseDatos.Prestamos.Add(prestamo);

                    if (entityEntry.State == EntityState.Added)
                    {
                        //añadir su cuota a la base de datos
                        cuotaPrestamo.PrestamoCodigoNavigation = entityEntry.Entity;
                        _BaseDatos.CuotaPrestamos.Add(cuotaPrestamo); // Guardar el préstamo en la base de datos

                        _BaseDatos.SaveChanges();
                    }

                    return RedirectToAction("SegundoHome");


                case "eliminar":
                    return RedirectToAction("TablaPrestamos", prestamo);
            }


            return View(prestamo);
        }
        [HttpPost]

        public IActionResult SolicitudDeInversion([FromForm] Inversiones inversiones, string botonPresionado)
        {
            var dias = (inversiones.FechaEnd - inversiones.FechaBeg).TotalDays;
            var interes = dias / 365 * 0.1D * (double)inversiones.Monto;
            inversiones.Interes = (decimal)Math.Round(interes, 2) / 100;

            var fechaPago = inversiones.FechaEnd.AddDays(1);
            var duracionMeses = (int)Math.Ceiling(dias / 30.0);
            var numCuotas = duracionMeses + 1;
            var montoMensual = (inversiones.Monto + inversiones.Interes) / numCuotas;

            //alamcenar en cuotasinversiones
            CuotaInversion cuotainversiones = new CuotaInversion();
            cuotainversiones.CodigoInversion = inversiones.Codigo;
            cuotainversiones.FechaRealizada = inversiones.FechaBeg;
            cuotainversiones.FechaPlanificada = fechaPago;
            cuotainversiones.CuentaBancoNumero = inversiones.CuentaBancoNumero;

            switch (botonPresionado)
            {
                case "CalcularInteres":
                   
                 

                    break;
                case "Enviar":

                    // Guardar el préstamo en la base de datos
                    var entityEntry = _BaseDatos.Inversiones.Add(inversiones);

                    if (entityEntry.State == EntityState.Added)
                    {
                        //añadir su cuota a la base de datos
                        cuotainversiones.CodigoInversionNavigation = entityEntry.Entity;
                        _BaseDatos.CuotaInversiones.Add(cuotainversiones); // Guardar el préstamo en la base de datos

                        _BaseDatos.SaveChanges();
                    }

                    return RedirectToAction("SegundoHome");


                case "eliminar":
                    return RedirectToAction("TablaPrestamos", cuotainversiones);
            }


            return View(inversiones);
            
          
        }
        public IActionResult SolicitudDeInversion()
        {
            var cedulaLogueda = HttpContext.Session.GetString(IKeysData.CEDULA);
            if (cedulaLogueda == null)
            {
                return RedirectToAction("Index");
            }

            var codigo = new Random().Next(1, 1000);

            var inversion = new Inversiones() { Codigo = codigo, ClienteCedula = cedulaLogueda };
            return View(inversion);
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


        [HttpPost]
        public IActionResult PagosPrestamos(int cuota)
        {

            var cuotaM = _BaseDatos.CuotaPrestamos.FirstOrDefault(c => c.PrestamoCodigo == cuota);
            
            return View(cuotaM);
        }
        public IActionResult PagosPrestamos()
        {
            
            
            return View();
        }
        public IActionResult BorrarCuotaPrestamo(int codigo)
        {
            var cuotaM = _BaseDatos.CuotaPrestamos.FirstOrDefault(c => c.PrestamoCodigo == codigo);

            _BaseDatos.CuotaPrestamos.Remove(cuotaM);
            _BaseDatos.SaveChanges();
            
            return RedirectToAction("SegundoHome");
        }
        public IActionResult Contacto()
        {
            
            
            return View();
        }

        public IActionResult TablaPrestamos()
        {
            try
            {
                var cedulaLogueada = HttpContext.Session.GetString(IKeysData.CEDULA);
            
                

                var listaCuotas = _BaseDatos.CuotaPrestamos.Where(c => 
                    c.ClienteCedula == cedulaLogueada).ToList();
                return View(listaCuotas);

            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
           
            
            
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