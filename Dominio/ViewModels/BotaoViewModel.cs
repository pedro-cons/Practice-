using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Dominio.ViewModels
{
    public class BotaoViewModel
    {
        public int BTN_INT_IDF { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string BTN_STR_NOME { get; set; }
        [Display(Name = "Link")]
        [Required(ErrorMessage = "O campo \"Link\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string BTN_STR_LINK { get; set; }
        public string BTN_STR_COR { get; set; }
        [Display(Name = "Whatsapp")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo \"Whatsapp\" é obrigatório.")]
        [MaxLength(30, ErrorMessage = "A quantidade máxima de caracteres permitida é 30.")]
        public string BTN_STR_WHATSAPP { get; set; }
        public string BTN_STR_REDE { get; set; }
        public string BTN_STR_SENHA { get; set; }
        public bool BTN_BIT_ATIVO { get; set; }
        public int BTN_INT_TIPO { get; set; }
        public int BTN_INT_ORDEM { get; set; }
    }
}
