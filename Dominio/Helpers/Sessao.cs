using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Helpers
{
    public enum SessaoItem
    {
        Usuario,
    }
    public class Sessao
    {
        #region Propriedades

        public static Usuario Usuario
        {
            get
            {
                return Sessao.Recuperar<Usuario>(SessaoItem.Usuario);
            }
        }


        #endregion Propriedades

        #region Métodos Sessão

        private static IHttpContextAccessor _httpContextAccessor;

        // Injeção de dependencia do contexto da aplicação
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Abandona todas as sessões atuais
        /// </summary>
        public static void AbandonarSessao()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        /// <summary>
        /// Adiciona um item na sessão
        /// </summary>
        /// <typeparam name="T">Tipo do item objeto</typeparam>
        /// <param name="chave">Enumerador do item da sessão</param>
        /// <param name="objeto">Objeto genérico passado para ser adicionado à sessão</param>
        public static void Setar<T>(SessaoItem chave, T objeto)
        {
            _httpContextAccessor.HttpContext.Session.SetString(chave.ToString(), JsonConvert.SerializeObject(objeto, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }

        /// <summary>
        /// Recupera um item na sessão
        /// </summary>
        /// <typeparam name="T">Tipo do item objeto</typeparam>
        /// <param name="chave">Enumerador do item da sessão</param>
        /// <returns>Valor da sessão cujo tipo foi definido por T</returns>
        public static T Recuperar<T>(SessaoItem chave)
        {
            var sessao = _httpContextAccessor.HttpContext.Session.GetString(chave.ToString());
            if (sessao != null)
                return JsonConvert.DeserializeObject<T>(sessao);
            else
                return default(T);
        }

        /// <summary>
        /// Remove um item da sessão
        /// </summary>
        /// <param name="chave">Enumerador do item da sessão</param>
        public static void Remover(SessaoItem chave)
        {
            _httpContextAccessor.HttpContext.Session.Remove(chave.ToString());
        }

        public static void Redireciona(string pagina)
        {
            _httpContextAccessor.HttpContext.Response.Redirect(pagina);
        }

        #endregion Métodos Sessão
    }
}
