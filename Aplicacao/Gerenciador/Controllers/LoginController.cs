using Dominio.Enumeradores;
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
    public class LoginController : BaseController
    {
        private readonly IServicoUsuario _servicoUsuario;

        public LoginController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpGet]
        [Route("/Login")]
        public async Task<IActionResult> Login()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            try
            {
                var outPadrao = await _servicoUsuario.AuthenticarAsync(login);

                MostraMensagem(outPadrao.Mensagem, outPadrao.Sucesso ? ETipoMensagem.Sucesso : ETipoMensagem.Erro);

                if (outPadrao.Sucesso)
                {
                    return RedirectToAction("Index", "Inicio");
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                MostraMensagem("Erro ao tentar entrar no sistema", ETipoMensagem.Erro);

                return View("Index");
            }
        }

        [HttpGet]
        [Route("/Login/Cadastrar")]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [Route("/Login/Cadastrar")]
        public async Task<IActionResult> CadastrarAsync(UsuarioViewModel usuario)
        {
            try
            {
                var outPadrao = await _servicoUsuario.CadastrarAsync(usuario);

                MostraMensagem(outPadrao.Mensagem, outPadrao.Sucesso ? ETipoMensagem.Sucesso : ETipoMensagem.Erro);

                if (outPadrao.Sucesso)
                {
                    return RedirectToAction("Login");
                }

                return View();
            }
            catch (Exception ex)
            {
                MostraMensagem("Erro ao cadastrar no sistema", ETipoMensagem.Erro);

                return View();
            }
        }
    }
}