using Dominio.Entidades;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IRepositorioUsuario : IRepositorio
    {
        Task CadastrarAsync(Usuario usuarioEntidade);
        Task<Usuario> ListarPorLoginAsync(string login);
    }
}
