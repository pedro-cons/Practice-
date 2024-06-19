using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.ViewModels
{
    public class OutPadraoViewModel
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = string.Empty;

        public OutPadraoViewModel(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}
