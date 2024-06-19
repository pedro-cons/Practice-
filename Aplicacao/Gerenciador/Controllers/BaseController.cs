using Dominio.Enumeradores;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public void MostraMensagem(string mensagem, ETipoMensagem eTipoMensagem = ETipoMensagem.Sucesso)
        {
            switch (eTipoMensagem)
            {
                case ETipoMensagem.Sucesso:
                    TempData["Sucesso"] = mensagem;
                    break;
                case ETipoMensagem.Erro:
                    TempData["Erro"] = mensagem;
                    break;
                case ETipoMensagem.Aviso:
                    TempData["Aviso"] = mensagem;
                    break;
                default:
                    break;
            }
        }
    }
}
