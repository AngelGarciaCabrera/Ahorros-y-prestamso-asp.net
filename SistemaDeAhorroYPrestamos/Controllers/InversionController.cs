using Microsoft.AspNetCore.Mvc;
using SistemaDeAhorroYPrestamos.Helpers;
using SistemaDeAhorroYPrestamos.Models;

namespace SistemaDeAhorroYPrestamos.Controllers
{
    

    public class InversionController : Controller
    {
        private readonly ILogger<InversionController> _logger;

        private readonly AhorrosPrestamosContext _BaseDatos;

        public InversionController(ILogger<InversionController> logger, AhorrosPrestamosContext baseDatos)
        {
            _logger = logger;
            _BaseDatos = baseDatos;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult SolicitudInversion()
        {
            var cedulaLogueda = HttpContext.Session.GetString(IKeysData.CEDULA);
            if (cedulaLogueda == null)
            {
                return RedirectToAction("Index");
            }

            var codigo = new Random().Next(1, 1000);

            var inversion = new Prestamo() { Codigo = codigo, ClienteCedula = cedulaLogueda };
            return View(inversion);
            
        }

        [HttpPost]

        public IActionResult SolicitudInversion(Inversiones inversiones, string botonPresionado)
        {
            var dias = (inversiones.FechaEnd - inversiones.FechaBeg).TotalDays;
            var interes = dias / 365 * 0.1D * (double)inversiones.Monto;
            inversiones.Interes = (decimal)Math.Round(interes, 2) / 100;

            switch (botonPresionado)
            {
                case "CalcularInteres":

                    break;
                case "Enviar":
                    // Guardar el préstamo en la base de datos
                    _BaseDatos.Inversiones.Add(inversiones);
                    _BaseDatos.SaveChanges();
                    return RedirectToAction("SegundoHome");


                case "eliminar":
                    return RedirectToAction("TablaPrestamos", inversiones);
            }



            return View(inversiones);
        }
    }
}
