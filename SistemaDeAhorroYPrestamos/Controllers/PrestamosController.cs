﻿using Microsoft.AspNetCore.Mvc;
using SistemaDeAhorroYPrestamos.Helpers.Validators;
using SistemaDeAhorroYPrestamos.Models;

namespace SistemaDeAhorroYPrestamos.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly ILogger<PrestamosController> _logger;

        private readonly AhorrosPrestamosContext _BaseDatos;
        // Validador de prestamos
        private PrestamosValidator validator;

        public PrestamosController(ILogger<PrestamosController> logger, AhorrosPrestamosContext baseDatos)
        {
            _logger = logger;
            _BaseDatos = baseDatos;
            validator = new PrestamosValidator();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SolicitudPrestamo(Prestamo prestamo, string botonPresionado)
        {

            if (botonPresionado == "Enviar")
            {
                // El botón "Enviar" fue presionado
                // realizar las acciones correspondientes aquí

                if (validator.validateErrors(ModelState))
                {
                    return View(prestamo);
                }

               
                return RedirectToAction("TablaPrestamos", "Home");
            }
            if (botonPresionado == "CalcularInteres")
            {
                // El botón "Enviar" fue presionado
                // realizar las acciones correspondientes aquí
                return RedirectToAction("Exito");
            }

            else if (botonPresionado == "eliminar") 
            {
                // El botón "Cancelar" fue presionado
                // realizar las acciones correspondientes aquí
                return RedirectToAction("Inicio");
            }
            else
            {
                // No se presionó ningún botón válido
                // realizar las acciones correspondientes aquí
                return View();
            }
            // SI el boton solicitar fue presionado, vuelve con los datos pero captura el interes basado en los datos
            // Sino valida todos los datos del formulario y luego procesa los datos en la base de datos
           
        }
        public IActionResult SolicitudPrestamo()
        {
            // SI el boton solicitar fue presionado, vuelve con los datos pero captura el interes basado en los datos
            // Sino valida todos los datos del formulario y luego procesa los datos en la base de datos
            return View();
        }
    }
}