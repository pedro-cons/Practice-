using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Dominio.Helpers
{
    public class Criptografia
    {
        /// <summary>
        /// Gera uma hash MD5
        /// </summary>
        /// <param name="input">valor a ser criptografado</param>
        /// <returns></returns>
        public static string GerarMD5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// Verifica se a palavra é a mesma da hash
        /// </summary>
        /// <param name="input">valor do campo</param>
        /// <param name="hash">valor da hash</param>
        /// <returns></returns>
        public static bool verificaHash(string input, string hash)
        {
            string hashInput = GerarMD5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
