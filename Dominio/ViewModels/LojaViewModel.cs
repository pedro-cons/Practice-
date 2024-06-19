using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.ViewModels
{
    public class LojaViewModel
    {
        public int LJA_INT_IDF { get; set; }
        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo \"Nome\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string LJA_STR_NOME { get; set; }
        public int USU_INT_IDF { get; set; }
        [Display(Name = "Descriçao")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo \"Descriçao\" é obrigatório.")]
        [MaxLength(1000, ErrorMessage = "A quantidade máxima de caracteres permitida é 1000.")]
        public string LJA_STR_DESCRICAO { get; set; }
        [Display(Name = "Whatsapp")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O Campo \"Whatsapp\" é obrigatório.")]
        [MaxLength(30, ErrorMessage = "A quantidade máxima de caracteres permitida é 30.")]
        public string LJA_STR_WHATSAPP { get; set; }
        public int END_INT_IDF { get; set; }
        public bool LJA_BIT_ATIVO { get; set; }
        [Display(Name = "CPF ou CNPJ")]
        [Required(ErrorMessage = "O campo \"CPF ou CNPJ\" é obrigatório.")]
        [MaxLength(14, ErrorMessage = "A quantidade máxima de caracteres permitida é 14 (CPF) e 18 (CNPJ).")]
        public string LJA_STR_CNPJ_CPF { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo \"Email\" é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A quantidade máxima de caracteres permitida é 255.")]
        public string LJA_STR_EMAIL { get; set; }
        [Required(ErrorMessage = "O campo \"Pessoa Física / Pessoa Júridica\" é obrigatório.")]
        public bool? LJA_BIT_CPF { get; set; }
        public byte[] LJA_BIN_FOTO { get; set; }
        [Display(Name = "Logo")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "0 Campo \"Logo\" é obrigatório.")]
        public IFormFile LJA_FILE_ARQUIVO { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
