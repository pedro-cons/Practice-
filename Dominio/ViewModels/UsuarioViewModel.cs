using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.ViewModels
{
    public class UsuarioViewModel
    {
        public int USU_INT_IDF { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo \"Senha\" é obrigatório.")]
        public string USU_STR_SENHA { get; set; }
        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "O campo \"Confirmar Senha\" é obrigatório.")]
        public string USU_STR_SENHA_CONFIRMAR { get; set; }
        [Display(Name = "Whatsapp")]
        [Required(ErrorMessage = "O campo \"Whatsapp\" é obrigatório.")]
        [MaxLength(30, ErrorMessage = "A quantidade máxima de caracteres permitida é 30")]
        public string USU_STR_WHATSAPP { get; set; }
        [Display(Name = "Usuário de Login no Sistema")]
        [Required(ErrorMessage = "O campo \"Usuário de Login no Sistema\" é obrigatório.")]
        [MaxLength(30, ErrorMessage = "A quantidade máxima de caracteres permitida é 30")]
        public string USU_STR_LOGIN { get; set; }
        public UsuarioEnderecoViewModel UsuarioEndereco { get; set; }
    }
}
