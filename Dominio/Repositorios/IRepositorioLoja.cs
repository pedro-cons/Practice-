using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IRepositorioLoja : IRepositorio
    {
        Task CadastrarAsync(Loja lojaEntidade);
        Task EditarAsync(Loja lojaEntidade);
        Task ExcluirAsync(int idf);
        Task<List<Loja>> ListarAsync();
        Task<Loja> ListarPorIdAsync(int idf);
    }
}
