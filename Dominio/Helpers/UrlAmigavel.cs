using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Helpers
{
    public class UrlAmigavel
    {
        public static string ValidaLink(string link)
        {
            if (!string.IsNullOrEmpty(link))
            {
                if (link.Contains("https://") || link.Contains("http://"))
                {
                    return link;
                }
                else
                {
                    return "https://" + link;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string TituloAmigavel(string titulo)
        {
            return titulo
                .Replace(",", "")
                .Replace(" ", "-")
                .Replace("|", "")
                .Replace("ç", "c")
                .Replace("ã", "a")
                .Replace("õ", "o")
                .Replace("%", "")
                .Replace("á", "a")
                .Replace("â", "a")
                .Replace("ó", "o")
                .Replace("Ó", "o")
                .Replace("â", "o")
                .Replace("é", "e")
                .Replace("ê", "e")
                .Replace("ú", "u")
                .Replace("û", "u")
                .Replace("í", "i")
                .Replace("î", "i")
                .Replace("ñ", "n");
        }
    }
}
