using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Helpers
{
    public static class Configuracao
    {
        public static string Conexao { get; set; }
        public static string Aplicacao { get; set; }

        public static void AddSettings(IConfiguration configuration)
        {
            Conexao = configuration["Conexao"].ToString();
            Aplicacao = configuration["Aplicacao"].ToString();
        }
    }
}
