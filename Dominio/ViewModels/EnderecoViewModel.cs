using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Dominio.ViewModels
{
    public class EnderecoViewModel
    {
        public int END_INT_IDF { get; set; }
        [Display(Name = "Complemento")]
        [Required(ErrorMessage = "O campo \"Complemento\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string END_STR_COMPLEMENTO { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo \"Estado\" é obrigatório.")]
        public int END_STR_ESTADO{ get; set; }
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O campo \"Bairro\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string END_STR_BAIRRO { get; set; }
        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo \"Número\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string END_STR_NUMERO { get; set; }
        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo \"CEP\" é obrigatório.")]
        [MaxLength(10, ErrorMessage = "A quantidade máxima de caracteres permitida é 10.")]
        public string END_STR_CEP{ get; set; }
        [Display(Name = "Rua")]
        [Required(ErrorMessage = "O campo \"Rua\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string END_STR_RUA { get; set; }
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo \"Cidade\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string END_STR_CIDADE { get; set; }
    }
}
