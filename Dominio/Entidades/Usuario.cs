using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    /// <summary>
    /// Tabela USUARIO do banco de dados
    /// </summary>
    public class Usuario
    {
        public int USU_INT_IDF { get; set; }
        public string USU_STR_SENHA { get; set; }
        public string USU_STR_SENHA_CONFIRMAR { get; set; }
        public string USU_STR_WHATSAPP { get; set; }
        public string USU_STR_LOGIN { get; set; }
    }
}
