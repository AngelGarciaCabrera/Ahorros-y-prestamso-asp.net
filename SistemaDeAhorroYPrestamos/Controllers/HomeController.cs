﻿using Microsoft.AspNetCore.Mvc;
using SistemaDeAhorroYPrestamos.Controllers.Models.entities;
using SistemaDeAhorroYPrestamos.Models;
using System.Diagnostics;

namespace SistemaDeAhorroYPrestamos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy(Prestamos prestamo)
        {

            
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult SolicitudDePrestamo()
        {
            return View();
        }
        public IActionResult AboutUS()
        {
            return View();
        }


        public IActionResult SegundoHome()
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

        public IActionResult TablaInversion()
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