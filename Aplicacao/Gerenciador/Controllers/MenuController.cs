using Dominio.Enumeradores;
using Dominio.Helpers;
using Dominio.Interfaces;
using Dominio.ViewModels;
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
    public class MenuController : BaseController
    {
        public readonly IServicoMenu _servicoMenu;
        public MenuController(IServicoMenu servicoMenu)
        {
            _servicoMenu = servicoMenu;
        }

        [HttpGet]
        [Route("/Menu/BoasVindas")]
        public async Task<IActionResult> BoasVindas()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                MostraMensagem(ex.Message, ETipoMensagem.Erro);
                return View();
            }
        }
    }
}