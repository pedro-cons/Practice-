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
    public class RepositorioEndereco : Repositorio, IRepositorioEndereco
    {
        #region SQL
        private const string INSERT_ENDERECO = @"INSERT INTO ENDERECO
        (END_STR_NUMERO, END_STR_COMPLEMENTO, END_STR_BAIRRO, END_STR_CEP, END_STR_RUA, END_STR_ESTADO, END_STR_CIDADE)
        VALUES (@END_STR_NUMERO, @END_STR_COMPLEMENTO, @END_STR_BAIRRO, @END_STR_CEP, @END_STR_RUA, @END_STR_ESTADO, @END_STR_CIDADE)
        SELECT SCOPE_IDENTITY() AS IDF";
        private const string UPDATE_ENDERECO = @"UPDATE ENDERECO
        SET END_STR_NUMERO = @END_STR_NUMERO,
        END_STR_COMPLEMENTO = @END_STR_COMPLEMENTO, 
        END_STR_BAIRRO = @END_STR_BAIRRO,
        END_STR_CEP = @END_STR_CEP,
        END_STR_RUA = @END_STR_RUA,
        END_STR_ESTADO = @END_STR_ESTADO,
        END_STR_CIDADE = @END_STR_CIDADE 
        WHERE END_INT_IDF = @END_INT_IDF";
        #endregion SQL
        public RepositorioEndereco()
        {
        }

        public async Task EditarAsync(Endereco endereco)
        {
            try
            {
                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = UPDATE_ENDERECO;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@END_STR_NUMERO", endereco.END_STR_NUMERO);
                    command.Parameters.AddWithValue("@END_STR_COMPLEMENTO", endereco.END_STR_COMPLEMENTO);
                    command.Parameters.AddWithValue("@END_STR_BAIRRO", endereco.END_STR_BAIRRO);
                    command.Parameters.AddWithValue("@END_STR_CEP", endereco.END_STR_CEP);
                    command.Parameters.AddWithValue("@END_STR_RUA", endereco.END_STR_RUA);
                    command.Parameters.AddWithValue("@END_STR_ESTADO", endereco.END_STR_ESTADO);
                    command.Parameters.AddWithValue("@END_STR_CIDADE", endereco.END_STR_CIDADE);
                    command.Parameters.AddWithValue("@END_INT_IDF", endereco.END_INT_IDF);

                    var reader = await command.ExecuteNonQueryAsync();

                    await conexao.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CadastrarAsync(Endereco endereco)
        {
            try
            {
                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = INSERT_ENDERECO;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@END_STR_NUMERO", endereco.END_STR_NUMERO);
                    command.Parameters.AddWithValue("@END_STR_COMPLEMENTO", endereco.END_STR_COMPLEMENTO);
                    command.Parameters.AddWithValue("@END_STR_BAIRRO", endereco.END_STR_BAIRRO);
                    command.Parameters.AddWithValue("@END_STR_CEP", endereco.END_STR_CEP);
                    command.Parameters.AddWithValue("@END_STR_RUA", endereco.END_STR_RUA);
                    command.Parameters.AddWithValue("@END_STR_ESTADO", endereco.END_STR_ESTADO);
                    command.Parameters.AddWithValue("@END_STR_CIDADE", endereco.END_STR_CIDADE);

                    var reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        endereco.END_INT_IDF = Convert.ToInt32(reader["IDF"]);
                    }

                    await conexao.CloseAsync();
                }

                return endereco.END_INT_IDF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
