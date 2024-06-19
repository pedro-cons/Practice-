using Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IServicoUsuario
    {
        Task<OutPadraoViewModel> AuthenticarAsync(LoginViewModel login);
        Task<OutPadraoViewModel> CadastrarAsync(UsuarioViewModel usuario);
    }
}
