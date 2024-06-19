using Gerenciador.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador.Controllers
{
    public class InicioController : BaseController
    {
        public InicioController()
        {
        }

        [HttpGet]
        [Route("/Inicio")]
        [Route("/Inicio/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}