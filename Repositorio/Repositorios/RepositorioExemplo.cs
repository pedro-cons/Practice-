using Dominio.Helpers;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class RepositorioExemplo: Repositorio, IRepositorioExemplo
    {
        public RepositorioExemplo()
        {
        }

        public Task Exemplo()
        {
            throw new NotImplementedException();
        }
    }
}
