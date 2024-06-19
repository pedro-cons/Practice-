using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IRepositorioEndereco : IRepositorio
    {
        Task<int> CadastrarAsync(Endereco endereco);
        Task EditarAsync(Endereco endereco);
    }
}
