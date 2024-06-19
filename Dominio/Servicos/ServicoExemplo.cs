using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorios;

namespace Dominio.Servicos
{
    public class ServicoExemplo: IServicoExemplo
    {
        private readonly IRepositorioExemplo _repositorioExemplo;

        public ServicoExemplo(IRepositorioExemplo repositorioExemplo)
        {
            _repositorioExemplo = repositorioExemplo;
        }
    }
}
