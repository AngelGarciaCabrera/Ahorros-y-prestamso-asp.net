using Microsoft.AspNetCore.Mvc;
using SistemaDeAhorroYPrestamos.Models;

namespace SistemaDeAhorroYPrestamos.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly ILogger<PrestamosController> _logger;

        private readonly AhorrosPrestamosContext _BaseDatos;

        public PrestamosController(ILogger<PrestamosController> logger, AhorrosPrestamosContext baseDatos)
        {
            _logger = logger;
            _BaseDatos = baseDatos;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SolicitudPrestamo(Prestamo prestamo, string botonPresionado)
        {
            // SI el boton solicitar fue presionado, vuelve con los datos pero captura el interes basado en los datos
            // Sino valida todos los datos del formulario y luego procesa los datos en la base de datos
            return View();
        }
        public IActionResult SolicitudPrestamo()
        {
            // SI el boton solicitar fue presionado, vuelve con los datos pero captura el interes basado en los datos
            // Sino valida todos los datos del formulario y luego procesa los datos en la base de datos
            return View();
        }
    }
}
