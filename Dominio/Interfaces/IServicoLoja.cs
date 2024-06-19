using Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IServicoLoja
    {
        Task<OutPadraoViewModel> CadastrarAsync(LojaViewModel loja);
        Task<OutPadraoViewModel> EditarAsync(LojaViewModel loja);
        Task<OutPadraoViewModel> ExcluirAsync(int idf);
        Task<List<LojaViewModel>> ListarAsync();
        Task<LojaViewModel> ListarPorIdAsync(int idf);
    }
}
