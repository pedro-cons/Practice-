using Dominio.Entidades;
using Dominio.Enumeradores;
using Dominio.Helpers;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorios
{
    public class RepositorioBotao : Repositorio, IRepositorioBotao
    {
        #region SQL
        private const string INSERT_BOTAO = @"INSERT INTO BOTAO
        (BTN_STR_NOME, BTN_STR_LINK, BTN_STR_COR, BTN_STR_WHATSAPP, BTN_STR_REDE, BTN_STR_SENHA, BTN_BIT_ATIVO, BTN_INT_TIPO, BTN_INT_ORDEM, LJA_INT_IDF)
        VALUES
        (@BTN_STR_NOME, @BTN_STR_LINK, @BTN_STR_COR, @BTN_STR_WHATSAPP, @BTN_STR_REDE, @BTN_STR_SENHA, @BTN_BIT_ATIVO, @BTN_INT_TIPO, @BTN_INT_ORDEM, @LJA_INT_IDF)
        SELECT SCOPE_IDENTITY() AS IDF";
        private const string UPDATE_BOTAO = @"UPDATE BOTAO SET 
        BTN_STR_NOME = @BTN_STR_NOME,
        BTN_STR_LINK = @BTN_STR_LINK,
        BTN_STR_COR = @BTN_STR_COR,
        BTN_STR_WHATSAPP = @BTN_STR_WHATSAPP,
        BTN_STR_REDE = @BTN_STR_REDE,
        BTN_STR_SENHA = @BTN_STR_SENHA,
        BTN_BIT_ATIVO = @BTN_BIT_ATIVO,
        BTN_INT_TIPO = @BTN_INT_TIPO,
        BTN_INT_ORDEM = @BTN_INT_ORDEM
        WHERE LJA_INT_IDF = @LJA_INT_IDF AND BTN_INT_IDF = @BTN_INT_IDF";
        private const string SELECT_BOTAO_POR_ID_LOJA = @"SELECT * FROM BOTAO WHERE LJA_INT_IDF = @LJA_INT_IDF";
        private const string DELETE_BOTAO = @"DELETE FROM BOTAO WHERE LJA_INT_IDF = @LJA_INT_IDF";
        #endregion SQL
        public RepositorioBotao()
        {
        }

        public async Task<List<Botao>> ListarPorLojaAsync(int lJA_INT_IDF)
        {
            List<Botao> loja = new List<Botao>();

            using (var command = conexao.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = SELECT_BOTAO_POR_ID_LOJA;

                command.Parameters.AddWithValue("@LJA_INT_IDF", lJA_INT_IDF);

                await conexao.OpenAsync();

                var reader = await command.ExecuteReaderAsync();

                loja = await PupulaEntidadeAsync(reader);

                await conexao.CloseAsync();
            }

            return loja;
        }

        public async Task CadastrarAsync(List<Botao> botao, int idfLoja, string nomeLoja)
        {
            try
            {
                var contador = 0;
                foreach (var item in botao)
                {
                    using (var command = conexao.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = INSERT_BOTAO;

                        await conexao.OpenAsync();

                        command.Parameters.AddWithValue("@BTN_STR_REDE", item.BTN_STR_REDE is null ? (object)DBNull.Value : item.BTN_STR_REDE);
                        command.Parameters.AddWithValue("@BTN_STR_COR", item.BTN_STR_COR);
                        command.Parameters.AddWithValue("@BTN_STR_WHATSAPP", item.BTN_STR_WHATSAPP is null ? (object)DBNull.Value : item.BTN_STR_WHATSAPP);
                        command.Parameters.AddWithValue("@BTN_STR_LINK", botao[contador].BTN_STR_LINK is null ? (object)DBNull.Value : botao[contador].BTN_STR_LINK);
                        command.Parameters.AddWithValue("@BTN_STR_SENHA", item.BTN_STR_SENHA is null ? (object)DBNull.Value : item.BTN_STR_SENHA);
                        command.Parameters.AddWithValue("@BTN_BIT_ATIVO", item.BTN_BIT_ATIVO);
                        command.Parameters.AddWithValue("@BTN_INT_TIPO", item.BTN_INT_TIPO);
                        command.Parameters.AddWithValue("@BTN_INT_ORDEM", item.BTN_INT_ORDEM);
                        command.Parameters.AddWithValue("@BTN_STR_NOME", item.BTN_STR_NOME);
                        command.Parameters.AddWithValue("@LJA_INT_IDF", idfLoja);

                        var reader = await command.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            botao[contador].BTN_INT_IDF = Convert.ToInt32(reader["IDF"]);
                        }

                        await conexao.CloseAsync();
                        contador++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditarAsync(List<Botao> botao, int lJA_INT_IDF)
        {
            try
            {
                foreach (var item in botao)
                {
                    using (var command = conexao.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = UPDATE_BOTAO;

                        await conexao.OpenAsync();

                        command.Parameters.AddWithValue("@BTN_STR_REDE", item.BTN_STR_REDE is null ? (object)DBNull.Value : item.BTN_STR_REDE);
                        command.Parameters.AddWithValue("@BTN_STR_COR", item.BTN_STR_COR);
                        command.Parameters.AddWithValue("@BTN_STR_WHATSAPP", item.BTN_STR_WHATSAPP is null ? (object)DBNull.Value : item.BTN_STR_WHATSAPP);
                        command.Parameters.AddWithValue("@BTN_STR_LINK", item.BTN_STR_LINK is null ? (object)DBNull.Value : item.BTN_STR_LINK);
                        command.Parameters.AddWithValue("@BTN_STR_SENHA", item.BTN_STR_SENHA is null ? (object)DBNull.Value : item.BTN_STR_SENHA);
                        command.Parameters.AddWithValue("@BTN_BIT_ATIVO", item.BTN_BIT_ATIVO);
                        command.Parameters.AddWithValue("@BTN_INT_TIPO", item.BTN_INT_TIPO);
                        command.Parameters.AddWithValue("@BTN_STR_NOME", item.BTN_STR_NOME);
                        command.Parameters.AddWithValue("@BTN_INT_ORDEM", item.BTN_INT_ORDEM);
                        command.Parameters.AddWithValue("@BTN_INT_IDF", item.BTN_INT_IDF);
                        command.Parameters.AddWithValue("@LJA_INT_IDF", lJA_INT_IDF);

                        var reader = await command.ExecuteNonQueryAsync();

                        await conexao.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ExcluirAsync(int lJA_INT_IDF)
        {
            try
            {
                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = DELETE_BOTAO;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@LJA_INT_IDF", lJA_INT_IDF);

                    var reader = await command.ExecuteNonQueryAsync();

                    await conexao.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Botao>> PupulaEntidadeAsync(SqlDataReader reader)
        {
            List<Botao> botoes = new List<Botao>();

            while (await reader.ReadAsync())
            {
                //Popula os botões
                Botao botao = new Botao();

                botao.BTN_STR_WHATSAPP = Convert.ToString(reader["BTN_STR_WHATSAPP"]);
                botao.BTN_STR_NOME = Convert.ToString(reader["BTN_STR_NOME"]);
                botao.BTN_STR_COR = Convert.ToString(reader["BTN_STR_COR"]);
                botao.BTN_STR_LINK = Convert.ToString(reader["BTN_STR_LINK"]);
                botao.BTN_STR_REDE = Convert.ToString(reader["BTN_STR_REDE"]);
                botao.BTN_BIT_ATIVO = Convert.ToBoolean(reader["BTN_BIT_ATIVO"]);
                botao.BTN_INT_IDF = Convert.ToInt32(reader["BTN_INT_IDF"]);
                botao.BTN_INT_ORDEM = Convert.ToInt32(reader["BTN_INT_ORDEM"]);
                botao.BTN_INT_TIPO = Convert.ToInt32(reader["BTN_INT_TIPO"]);
                botao.BTN_STR_SENHA = Convert.ToString(reader["BTN_STR_SENHA"]);

                botoes.Add(botao);
            }

            return botoes;
        }
    }
}
