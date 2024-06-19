using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Dominio.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Campo \"CNPJ ou CPF\" obrigatório.")]
        [MaxLength(14, ErrorMessage = "Número máximo de caracteres é 14.")]
        public string CNPJ_CPF { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo \"Senha\" obrigatório.")]
        public string Senha { get; set; }
    }
}
