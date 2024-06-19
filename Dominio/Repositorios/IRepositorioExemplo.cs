using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IRepositorioExemplo: IRepositorio
    {
        Task Exemplo();
    }
}
