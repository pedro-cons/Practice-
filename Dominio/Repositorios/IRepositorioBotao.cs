using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IRepositorioBotao : IRepositorio
    {
        Task CadastrarAsync(List<Botao> botao, int idfLoja, string nomeLoja);
        Task EditarAsync(List<Botao> botao, int lJA_INT_IDF);
        Task ExcluirAsync(int lJA_INT_IDF);
        Task<List<Botao>> ListarPorLojaAsync(int lJA_INT_IDF);
    }
}
