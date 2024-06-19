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
    public class RepositorioUsuario: Repositorio, IRepositorioUsuario
    {
        #region SQL
        private const string SELECT_USUARIO = @"SELECT * FROM USUARIO WHERE USU_STR_LOGIN = @LOGIN";
        private const string INSERT_USUARIO = @"INSERT INTO USUARIO 
					(USU_STR_LOGIN, USU_STR_WHATSAPP, USU_STR_SENHA)
					VALUES
					(@USU_STR_LOGIN, @USU_STR_WHATSAPP, @USU_STR_SENHA)";
        #endregion
        public RepositorioUsuario()
        {
        }

        public async Task CadastrarAsync(Usuario usuarioEntidade)
        {
            try
            {
                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = INSERT_USUARIO;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@USU_STR_LOGIN", usuarioEntidade.USU_STR_LOGIN);
                    command.Parameters.AddWithValue("@USU_STR_WHATSAPP", usuarioEntidade.USU_STR_WHATSAPP);
                    command.Parameters.AddWithValue("@USU_STR_SENHA", usuarioEntidade.USU_STR_SENHA);

                    await command.ExecuteNonQueryAsync();

                    await conexao.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> ListarPorLoginAsync(string login)
        {
            try
            {
                Usuario usuario = new Usuario();

                using (var command = conexao.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = SELECT_USUARIO;

                    await conexao.OpenAsync();

                    command.Parameters.AddWithValue("@LOGIN", login);

                    var reader = await command.ExecuteReaderAsync();

                    usuario = await PupulaEntidadeAsync(reader);

                    await conexao.CloseAsync();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> PupulaEntidadeAsync(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();

            while (await reader.ReadAsync())
            {
                usuario.USU_STR_SENHA = Convert.ToString(reader["USU_STR_SENHA"]);
                usuario.USU_INT_IDF = Convert.ToInt32(reader["USU_INT_IDF"]);
                usuario.USU_STR_LOGIN = Convert.ToString(reader["USU_STR_LOGIN"]);
                usuario.USU_STR_WHATSAPP = Convert.ToString(reader["USU_STR_WHATSAPP"]);
            }

            return usuario;
        }
    }
}
