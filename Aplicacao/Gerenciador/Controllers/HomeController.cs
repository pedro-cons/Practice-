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
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        [HttpGet]
        [Route("/Home")]
        [Route("/Home/Index")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}