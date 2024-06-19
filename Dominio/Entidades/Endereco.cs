using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Dominio.Entidades
{
    public class Endereco
    {
        public int END_INT_IDF { get; set; }
        public string END_STR_COMPLEMENTO { get; set; }
        public int END_STR_ESTADO { get; set; }
        public string END_STR_BAIRRO { get; set; }
        public string END_STR_NUMERO { get; set; }
        public string END_STR_CEP { get; set; }
        public string END_STR_RUA { get; set; }
        public string END_STR_CIDADE { get; set; }
    }
}
