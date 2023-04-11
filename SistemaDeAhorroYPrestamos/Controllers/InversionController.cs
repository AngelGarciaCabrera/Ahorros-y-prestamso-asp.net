using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]

        public IActionResult SolicitudInversion(Inversione inversione, string botonevaluar)
        {

            if (botonevaluar == "Enviar")
            {
                // El botón "Enviar" fue presionado
                // realizar las acciones correspondientes aquí

                if (ModelState.ContainsKey("Monto") && ModelState["Monto"].Errors.Count != 0 ||
                ModelState.ContainsKey("FechaBeg") && ModelState["FechaBeg"].Errors.Count != 0 ||
                ModelState.ContainsKey("FechaEnd") && ModelState["FechaEnd"].Errors.Count != 0 ||
                 ModelState.ContainsKey("ClienteCedula") && ModelState["ClienteCedula"].Errors.Count != 0 ||
                 ModelState.ContainsKey("CuentaBancoNumero") && ModelState["CuentaBancoNumero"].Errors.Count != 0 )
                {
                    return View(inversione);
                }


                return RedirectToAction("login", "Home");
            }
            if (botonevaluar == "Limpiar")
            {
                return RedirectToAction("Exito");
            }

            else 
            {
                
                return RedirectToAction("Inicio");
            }
          
            

            
        }
    }
}
