using Dominio.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repositorio.Repositorios
{
    public class Repositorio
    {
        public SqlConnection conexao { get; set; }

        public Repositorio()
        {
            this.conexao = new SqlConnection(Configuracao.Conexao);
        }
    }
}
