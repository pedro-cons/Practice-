using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dominio.Helpers
{
    public static class Geral
    {
        #region Métodos

        public static string ApenasNumeros(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return new string(str.Where(char.IsDigit).ToArray());
        }

        public static string FormatarCpf(string cpf)
        {
            cpf = ApenasNumeros(cpf);

            if (string.IsNullOrEmpty(cpf))
                return string.Empty;
            else
                return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static string FormatarCnpj(string cnpj)
        {
            cnpj = ApenasNumeros(cnpj);

            if (string.IsNullOrEmpty(cnpj))
                return string.Empty;
            else
                return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatarTelefone(string telefone)
        {
            telefone = ApenasNumeros(telefone);

            if (string.IsNullOrEmpty(telefone))
                return string.Empty;
            else
            {
                if (telefone.Length == 10)
                    return Convert.ToUInt64(telefone).ToString(@"\(00\) 0000\-0000");
                else
                    return Convert.ToUInt64(telefone).ToString(@"\(00\) 00000\-0000");
            }
        }

        public static string FormatarCEP(string cep)
        {
            cep = ApenasNumeros(cep);

            if (string.IsNullOrEmpty(cep))
                return string.Empty;
            else
                return Convert.ToUInt64(cep).ToString(@"00000\-000");
        }

        public static string OcultarEmail(string email)
        {
            if (email.LastIndexOf("@") > -1)
            {
                var partes = email.Split('@');
                var subpartes = partes[1].Split('.');
                var mascarado = $"{partes[0].Substring(0, 2)}***@{subpartes[0].Substring(0, 2)}***.{subpartes[subpartes.Length - 1]}";

                return mascarado;
            }
            else
                return email;
        }

        public static string ToUrl(string text)
        {
            return text.Replace("+", "1sm2").Replace("/", "1bi2");
        }

        public static string FromUrl(string text)
        {
            return text.Replace("1sm2", "+").Replace("1bi2", "/");
        }

        public static bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            cpf = ApenasNumeros(cpf);

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool ValidarCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static int CalculaIdadeInt(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            //Se o dia de nascimento for superior a data de hoje diminui uma unidade da idade.
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }

        public static string PrimeiroNome(string nome)
        {
            var nomes = nome.Split(' ');

            string primeiroMome = nomes[0];

            return primeiroMome;
        }

        /// <summary>
        /// Retorna a letra inicial do nome mais a letra inicial do sobrenome
        /// </summary>
        /// <param name="nome">Nome completo</param>
        /// <returns></returns>
        public static string IniciaisNome(string nome)
        {
            var nomes = nome.Trim().Split(' ');

            string primeiroNome = string.Empty;
            string segundoNome = string.Empty;

            if (nomes[0] != null)
                primeiroNome = nomes[0];

            if (nomes.Count() > 1)
                segundoNome = nomes[nomes.Count() - 1]; //Pega sempre a posição do ultimo sobrenome

            string iniciais = primeiroNome.Substring(0, 1) + segundoNome.Substring(0, 1);

            return iniciais;
        }

        public static string ConverterParaJson<T>(T objeto)
        {
            var jsonObjeto = JsonConvert.SerializeObject(objeto, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return jsonObjeto.Trim();
        }

        public static T ConverterJsonParaObjeto<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch
            {
                throw;
            }
        }

        public static List<string> ObterListaString(Type type, bool orderByValue = false)
        {
            var values = Enum.GetValues(type);

            List<string> textos = new List<string>();

            System.Reflection.MemberInfo[] mia = null;
            System.ComponentModel.DataAnnotations.DisplayAttribute[] atribs = null;
            foreach (Enum value in values)
            {
                mia = value.GetType().GetMember(value.ToString());
                atribs = (mia != null && mia.Length > 0) ? (System.ComponentModel.DataAnnotations.DisplayAttribute[])
                mia[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false) : null;
                textos.Add(atribs != null && atribs.Length == 1 ? atribs[0].Name : value.ToString());
            }
            return textos;
        }

        /// <summary>
        /// Método utilizado para popular dropdownlists a partir de enumeradores
        /// Obs.: Obrigatório utilizar a Annotation Display e values
        /// Ex.: [Display(Name = "Solteiro(a)")] Solteiro = 1
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Lista de Itens atribuindo os values numéricos</returns>
        public static SelectList ObterListaInt(Type type, bool orderByValue = false)
        {
            var values = Enum.GetValues(type);

            List<string> textos = new List<string>();
            List<int> valores = new List<int>();

            System.Reflection.MemberInfo[] mia = null;
            System.ComponentModel.DataAnnotations.DisplayAttribute[] atribs = null;
            foreach (Enum value in values)
            {
                mia = value.GetType().GetMember(value.ToString());
                atribs = (mia != null && mia.Length > 0) ? (System.ComponentModel.DataAnnotations.DisplayAttribute[])
                mia[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false) : null;
                textos.Add(atribs != null && atribs.Length == 1 ? atribs[0].Name : value.ToString());

                for (int i = 0; i < values.Length; i++)
                {
                    if (values.GetValue(i).ToString() == value.ToString())
                    {
                        valores.Add((int)values.GetValue(i));
                        break;
                    }
                }
            }

            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem
            {
                Value = "",
                Text = "Selecione"
            });

            for (var i = 0; i < textos.Count; i++)
            {
                list.Add(new SelectListItem() { Text = textos[i], Value = valores[i].ToString(), Selected = true, Disabled = false });
            }

            if (orderByValue)
                return new SelectList(list.OrderBy(x => x.Value), "Value", "Text");
            else
                return new SelectList(list.OrderBy(x => x.Text), "Value", "Text");
        }

        /// <summary>
        /// Método utilizado para popular dropdownlists a partir de enumeradores
        /// Obs.: Obrigatório utilizar a Annotation Display e values
        /// Ex.: [Display(Name = "Solteiro(a)")] Solteiro = 1
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Lista de Itens atribuindo os values numéricos</returns>
        public static List<SelectListItem> ObterListaSelectListItem(Type type, bool orderByValue = false)
        {
            var values = Enum.GetValues(type);

            List<string> textos = new List<string>();
            List<int> valores = new List<int>();

            System.Reflection.MemberInfo[] mia = null;
            System.ComponentModel.DataAnnotations.DisplayAttribute[] atribs = null;
            foreach (Enum value in values)
            {
                mia = value.GetType().GetMember(value.ToString());
                atribs = (mia != null && mia.Length > 0) ? (System.ComponentModel.DataAnnotations.DisplayAttribute[])
                mia[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false) : null;
                textos.Add(atribs != null && atribs.Length == 1 ? atribs[0].Name : value.ToString());

                for (int i = 0; i < values.Length; i++)
                {
                    if (values.GetValue(i).ToString() == value.ToString())
                    {
                        valores.Add((int)values.GetValue(i));
                        break;
                    }
                }
            }

            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem
            {
                Value = "",
                Text = "Selecione"
            });

            for (var i = 0; i < textos.Count; i++)
            {
                list.Add(new SelectListItem() { Text = textos[i], Value = valores[i].ToString(), Selected = false, Disabled = false });
            }

            if (orderByValue)
                return list.OrderBy(x => x.Value).ToList();
            else
                return list.OrderBy(x => x.Text).ToList();
        }

        public static string RemoverAcentos(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        #endregion Métodos
    }
}
