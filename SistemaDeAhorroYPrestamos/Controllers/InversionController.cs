using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

            var cliente = _BaseDatos.Clientes.FirstOrDefault(c => c.Cedula == cedulaLogueda);
            if (cliente == null)
            {
                return RedirectToAction("Index");
            }

            var inversion = new Inversiones() { Codigo = codigo, ClienteCedula = cedulaLogueda, CuentaBancoNumero = cliente.IdCuentaBanco    };
            return View(inversion);

        }

        [HttpPost]

        public IActionResult SolicitudInversion(Inversiones inversiones, string botonPresionado)
        {
            switch (botonPresionado)
            {
                case "CalcularInteres":
                    var dias = (inversiones.FechaEnd - inversiones.FechaBeg).TotalDays;
                    var interes = dias / 365 * 0.1D * (double)inversiones.Monto;
                    inversiones.Interes = (decimal)Math.Round(interes, 2) / 100;
                    break;

                case "Enviar":
                    // Guardar la inversion en la base de datos
                    _BaseDatos.Inversiones.Add(inversiones);
                    _BaseDatos.SaveChanges();

                    return View("SegundoHome");

                case "eliminar":
                    return RedirectToAction("TablaInversion", inversiones);
            }

            return View(inversiones);
        }

        public IActionResult TablaInversion()
        {
            return View();
        }
    }
}
