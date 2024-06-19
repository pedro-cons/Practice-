using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorios;

namespace Dominio.Servicos
{
    public class ServicoMenu: IServicoMenu
    {
        private readonly IRepositorioMenu _repositorioMenu;

        public ServicoMenu(IRepositorioMenu repositorioMenu)
        {
            _repositorioMenu = repositorioMenu;
        }
    }
}
