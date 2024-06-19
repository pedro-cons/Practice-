using Dominio.Entidades;
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
    public class RepositorioLoja : Repositorio, IRepositorioLoja
    {
        #region SQL
        private const string INSERT_LOJA = @"INSERT INTO LOJA
        (LJA_BIT_CPF,LJA_STR_EMAIL,LJA_STR_CNPJ_CPF, LJA_STR_NOME, USU_INT_IDF, LJA_STR_WHATSAPP, LJA_STR_DESCRICAO, END_INT_IDF, LJA_BIT_ATIVO, LJA_BIN_FOTO)
        VALUES
        (@LJA_BIT_CPF,@LJA_STR_EMAIL,@LJA_STR_CNPJ_CPF,@LJA_STR_NOME, @USU_INT_IDF, @LJA_STR_WHATSAPP, @LJA_STR_DESCRICAO, @END_INT_IDF, @LJA_BIT_ATIVO, @LJA_BIN_FOTO)";
        private const string SELECT_LOJA = @"SELECT LJ.*, ED.END_STR_ESTADO , ED.END_STR_CIDADE FROM LOJA LJ
        INNER JOIN ENDERECO ED ON ED.END_INT_IDF = LJ.END_INT_IDF
		WHERE LJ.USU_INT_IDF = @IDF
        ";
        private const string SELECT_LOJA_POR_ID = @"SELECT LJ.*, ED.END_STR_ESTADO , ED.END_STR_CIDADE, ED.END_STR_NUMERO, ED.END_STR_COMPLEMENTO, ED.END_STR_BAIRRO, ED.END_STR_CEP, ED.END_STR_RUA  FROM LOJA LJ
        INNER JOIN ENDERECO ED ON ED.END_INT_IDF = LJ.END_INT_IDF
		WHERE LJ.USU_INT_IDF = @IDF_USUARIO AND LJ.LJA_INT_IDF = @IDF_LOJA";
        private const string DELETE_LOJA = @"DELETE FROM LOJA WHERE LJA_INT_IDF = @LJA_INT_IDF";
        private const string UPDATE_LOJA = @"UPDATE LOJA
        SET LJA_BIT_CPF = @LJA_BIT_CPF,
        LJA_STR_EMAIL = @LJA_STR_EMAIL,
        LJA_STR_CNPJ_CPF= @LJA_STR_CNPJ_CPF,
        LJA_STR_NOME = @LJA_STR_NOME,
        LJA_STR_WHATSAPP = @LJA_STR_WHATSAPP,
        LJA_STR_DESCRICAO = @LJA_STR_DESCRICAO,
        LJA_BIT_ATIVO = @LJA_BIT_ATIVO,
        LJA_BIN_FOTO = @LJA_BIN_FOTO
        WHERE LJA_INT_IDF = @LJA_INT_IDF";
        #endregion SQL
        public RepositorioLoja()
        {
        }

        public async Task ExcluirAsync(int idf)
        {
            try
            {
                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = DELETE_LOJA;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@LJA_INT_IDF", idf);

                    await command.ExecuteNonQueryAsync();

                    await conexao.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditarAsync(Loja lojaEntidade)
        {
            try
            {
                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = UPDATE_LOJA;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@LJA_STR_NOME", lojaEntidade.LJA_STR_NOME);
                    command.Parameters.AddWithValue("@LJA_STR_WHATSAPP", lojaEntidade.LJA_STR_WHATSAPP);
                    command.Parameters.AddWithValue("@LJA_STR_DESCRICAO", lojaEntidade.LJA_STR_DESCRICAO);
                    command.Parameters.AddWithValue("@LJA_BIT_ATIVO", lojaEntidade.LJA_BIT_ATIVO);
                    command.Parameters.AddWithValue("@LJA_BIN_FOTO", lojaEntidade.LJA_BIN_FOTO);
                    command.Parameters.AddWithValue("@LJA_BIT_CPF", lojaEntidade.LJA_BIT_CPF);
                    command.Parameters.AddWithValue("@LJA_STR_EMAIL", lojaEntidade.LJA_STR_EMAIL);
                    command.Parameters.AddWithValue("@LJA_STR_CNPJ_CPF", lojaEntidade.LJA_STR_CNPJ_CPF);
                    command.Parameters.AddWithValue("@LJA_INT_IDF", lojaEntidade.LJA_INT_IDF);

                    await command.ExecuteNonQueryAsync();

                    await conexao.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CadastrarAsync(Loja lojaEntidade)
        {
            try
            {
                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = INSERT_LOJA;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@LJA_STR_NOME", lojaEntidade.LJA_STR_NOME);
                    command.Parameters.AddWithValue("@USU_INT_IDF", lojaEntidade.USU_INT_IDF);
                    command.Parameters.AddWithValue("@LJA_STR_WHATSAPP", lojaEntidade.LJA_STR_WHATSAPP);
                    command.Parameters.AddWithValue("@LJA_STR_DESCRICAO", lojaEntidade.LJA_STR_DESCRICAO);
                    command.Parameters.AddWithValue("@LJA_BIT_ATIVO", lojaEntidade.LJA_BIT_ATIVO);
                    command.Parameters.AddWithValue("@END_INT_IDF", lojaEntidade.END_INT_IDF);
                    command.Parameters.AddWithValue("@LJA_BIN_FOTO", lojaEntidade.LJA_BIN_FOTO);
                    command.Parameters.AddWithValue("@LJA_BIT_CPF", lojaEntidade.LJA_BIT_CPF);
                    command.Parameters.AddWithValue("@LJA_STR_EMAIL", lojaEntidade.LJA_STR_EMAIL);
                    command.Parameters.AddWithValue("@LJA_STR_CNPJ_CPF", lojaEntidade.LJA_STR_CNPJ_CPF);

                    await command.ExecuteNonQueryAsync();

                    await conexao.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Loja>> ListarAsync()
        {
            try
            {
                List<Loja> lojas = new List<Loja>();

                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SELECT_LOJA;

                    command.Parameters.AddWithValue("@IDF", Sessao.Usuario.USU_INT_IDF);

                    await conexao.OpenAsync();

                    var reader = await command.ExecuteReaderAsync();

                    lojas = await PupulaEntidadeAsync(reader);

                    await conexao.CloseAsync();
                }

                return lojas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Loja> ListarPorIdAsync(int idf)
        {
            try
            {
                Loja loja = new Loja();

                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SELECT_LOJA_POR_ID;

                    command.Parameters.AddWithValue("@IDF_USUARIO", Sessao.Usuario.USU_INT_IDF);
                    command.Parameters.AddWithValue("@IDF_LOJA", idf);

                    await conexao.OpenAsync();

                    var reader = await command.ExecuteReaderAsync();

                    loja = await PupulaEntidadeUnicaAsync(reader);

                    await conexao.CloseAsync();
                }

                return loja;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Loja> PupulaEntidadeUnicaAsync(SqlDataReader reader)
        {
            Loja loja = new Loja();

            while (await reader.ReadAsync())
            {
                //Popula a loja
                loja.LJA_INT_IDF = Convert.ToInt32(reader["LJA_INT_IDF"]);
                loja.LJA_STR_NOME = Convert.ToString(reader["LJA_STR_NOME"]);
                loja.USU_INT_IDF = Convert.ToInt32(reader["USU_INT_IDF"]);
                loja.LJA_STR_WHATSAPP = Convert.ToString(reader["LJA_STR_WHATSAPP"]);
                loja.LJA_STR_DESCRICAO = Convert.ToString(reader["LJA_STR_DESCRICAO"]);
                loja.LJA_BIT_ATIVO = Convert.ToBoolean(reader["END_INT_IDF"]);
                loja.LJA_BIN_FOTO = (byte[])reader["LJA_BIN_FOTO"];
                loja.LJA_BIT_CPF = Convert.ToBoolean(reader["LJA_BIT_CPF"]);
                loja.LJA_STR_CNPJ_CPF = Convert.ToString(reader["LJA_STR_CNPJ_CPF"]);
                loja.LJA_STR_EMAIL = Convert.ToString(reader["LJA_STR_EMAIL"]);

                //Popula o endereço
                loja.Endereco = new Endereco();
                loja.Endereco.END_INT_IDF = Convert.ToInt32(reader["LJA_INT_IDF"]);
                loja.Endereco.END_STR_ESTADO = Convert.ToInt32(reader["END_STR_ESTADO"]);
                loja.Endereco.END_STR_CIDADE = Convert.ToString(reader["END_STR_CIDADE"]);
                loja.Endereco.END_STR_COMPLEMENTO = Convert.ToString(reader["END_STR_COMPLEMENTO"]);
                loja.Endereco.END_STR_BAIRRO = Convert.ToString(reader["END_STR_BAIRRO"]);
                loja.Endereco.END_STR_CEP = Convert.ToString(reader["END_STR_CEP"]);
                loja.Endereco.END_STR_NUMERO = Convert.ToString(reader["END_STR_NUMERO"]);
                loja.Endereco.END_STR_RUA = Convert.ToString(reader["END_STR_RUA"]);
            }

            return loja;
        }

        public async Task<List<Loja>> PupulaEntidadeAsync(SqlDataReader reader)
        {
            List<Loja> lojas = new List<Loja>();

            while (await reader.ReadAsync())
            {
                Loja loja = new Loja();

                //Popula a loja
                loja.LJA_INT_IDF = Convert.ToInt32(reader["LJA_INT_IDF"]);
                loja.LJA_STR_NOME = Convert.ToString(reader["LJA_STR_NOME"]);
                loja.USU_INT_IDF = Convert.ToInt32(reader["USU_INT_IDF"]);
                loja.LJA_STR_WHATSAPP = Convert.ToString(reader["LJA_STR_WHATSAPP"]);
                loja.LJA_STR_DESCRICAO = Convert.ToString(reader["LJA_STR_DESCRICAO"]);
                loja.LJA_BIT_ATIVO = Convert.ToBoolean(reader["END_INT_IDF"]);
                loja.LJA_BIN_FOTO = (byte[])reader["LJA_BIN_FOTO"];
                loja.LJA_BIT_CPF = Convert.ToBoolean(reader["LJA_BIT_CPF"]);
                loja.LJA_STR_CNPJ_CPF = Convert.ToString(reader["LJA_STR_CNPJ_CPF"]);
                loja.LJA_STR_EMAIL = Convert.ToString(reader["LJA_STR_EMAIL"]);

                //Popula o endereço
                loja.Endereco = new Endereco();
                loja.Endereco.END_INT_IDF = Convert.ToInt32(reader["LJA_INT_IDF"]);
                loja.Endereco.END_STR_ESTADO = Convert.ToInt32(reader["END_STR_ESTADO"]);
                loja.Endereco.END_STR_CIDADE = Convert.ToString(reader["END_STR_CIDADE"]);

                lojas.Add(loja);
            }

            return lojas;
        }
    }
}
