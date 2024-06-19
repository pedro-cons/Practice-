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
    public class LojaController : BaseController
    {
        public readonly IServicoLoja _servicoLoja;
        public LojaController(IServicoLoja servicoLoja)
        {
            _servicoLoja = servicoLoja;
        }

        [HttpGet]
        [Route("/Loja")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                List<LojaViewModel> lojas = await _servicoLoja.ListarAsync();
                ViewBag.Loja = lojas;
                return View();
            }
            catch (Exception ex)
            {
                MostraMensagem(ex.Message, ETipoMensagem.Erro);
                ViewBag.Loja = new List<LojaViewModel>();
                return View();
            }
        }

        [HttpGet]
        [Route("/Loja/Cadastrar")]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [Route("/Loja/Cadastrar")]
        public async Task<IActionResult> CadastrarAsync(LojaViewModel loja)
        {
            try
            {
                loja.USU_INT_IDF = Sessao.Usuario.USU_INT_IDF;
                loja.LJA_BIT_ATIVO = false;

                var outPadrao = await _servicoLoja.CadastrarAsync(loja);

                MostraMensagem(outPadrao.Mensagem, outPadrao.Sucesso ? ETipoMensagem.Sucesso : ETipoMensagem.Erro);

                if (outPadrao.Sucesso)
                {
                    return RedirectToAction("Listar");
                }

                return View();
            }
            catch (Exception ex)
            {
                MostraMensagem("Erro ao cadastrar no sistema", ETipoMensagem.Erro);

                return View();
            }
        }

        [HttpGet]
        [Route("/Loja/Editar/{Idf}")]
        public async Task<IActionResult> Editar(int Idf)
        {
            LojaViewModel loja = await _servicoLoja.ListarPorIdAsync(Idf);

            return View(loja);
        }

        [HttpPost]
        [Route("/Loja/Editar")]
        [Route("/Loja/Editar/{Idf}")]
        public async Task<IActionResult> EditarAsync(LojaViewModel loja)
        {
            try
            {
                var outPadrao = await _servicoLoja.EditarAsync(loja);

                MostraMensagem(outPadrao.Mensagem, outPadrao.Sucesso ? ETipoMensagem.Sucesso : ETipoMensagem.Erro);

                if (outPadrao.Sucesso)
                {
                    return RedirectToAction("Listar");
                }

                return View();
            }
            catch (Exception)
            {
                MostraMensagem("Erro ao editar no sistema", ETipoMensagem.Erro);

                return View();
            }
        }

        [HttpPost]
        [Route("/Loja/Excluir")]
        public async Task<IActionResult> ExcluirAsync(int idf)
        {
            try
            {
                var outPadrao = await _servicoLoja.ExcluirAsync(idf);

                if (outPadrao.Sucesso)
                {
                    MostraMensagem(outPadrao.Mensagem, ETipoMensagem.Sucesso);

                    return Ok(outPadrao.Mensagem);
                }
                else
                {
                    return BadRequest(outPadrao.Mensagem);
                }
            }
            catch (Exception)
            {
                return BadRequest("Erro ao tentar excluir Loja.");
            }
        }
    }
}