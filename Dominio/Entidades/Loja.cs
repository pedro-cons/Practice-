using Dominio.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Dominio.Entidades
{
    public class Loja
    {
        public int LJA_INT_IDF { get; set; }
        public string LJA_STR_NOME { get; set; }
        public int USU_INT_IDF { get; set; }
        public string LJA_STR_DESCRICAO { get; set; }
        public string LJA_STR_WHATSAPP { get; set; }
        public int END_INT_IDF { get; set; }
        public bool LJA_BIT_ATIVO { get; set; }
        public string LJA_STR_CNPJ_CPF { get; set; }
        public string LJA_STR_EMAIL { get; set; }
        public bool? LJA_BIT_CPF { get; set; }
        public byte[] LJA_BIN_FOTO { get; set; }
        public Endereco Endereco { get; set; }
    }
}
