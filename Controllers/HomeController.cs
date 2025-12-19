using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// Acceso a todos los modelos
using Proyecto.Models;

namespace Proyecto.Controllers
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

        // Funcion que incrementa en uno
        public IActionResult SumarUno()
        {
            // Llamamos al modelo y luego al atributo. Como Apellido y nombre
            num.numero++;

            // Regresa a Index al pulsar el boton
            return Redirect("Index");
        }

        public IActionResult Privacy()
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
