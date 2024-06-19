using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Dominio.Entidades
{
    public class Botao
    {
        public int BTN_INT_IDF { get; set; }
        public string BTN_STR_NOME { get; set; }
        public string BTN_STR_LINK { get; set; }
        public string BTN_STR_COR { get; set; }
        public string BTN_STR_WHATSAPP { get; set; }
        public string BTN_STR_REDE { get; set; }
        public string BTN_STR_SENHA { get; set; }
        public bool BTN_BIT_ATIVO { get; set; }
        public int BTN_INT_TIPO { get; set; }
        public int BTN_INT_ORDEM { get; set; }
    }
}
