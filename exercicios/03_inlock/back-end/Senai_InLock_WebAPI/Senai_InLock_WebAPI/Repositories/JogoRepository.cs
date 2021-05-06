using Senai_InLock_WebAPI.Domains;
using Senai_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai_InLock_WebAPI.Repositories
{
    /// <summary>
    /// Classe responsável por executar os métodos relacionados aos Jogos
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        // String de conexão com o banco de dados
        private string conexao = "Data Source=DESKTOP-T9H6KLN; initial catalog=InLock_Games_Manha; user Id=sa; pwd=vini@132";

        /// <summary>
        /// Cadastra um novo jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Objeto que contém as informações do jogo que será cadastrado</param>
        public void Cadastrar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                // Consulta que será executada
                string queryInsert =
                    "INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)" +
                    "VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                // Abre conexão com o banco de dados
                con.Open();

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Define que o valor das variáveis receberão o valor dos atributos do objeto jogo
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um jogo que está cadastrado no banco de dados, passando seu id
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                // Consulta que será executada
                string queryDelete = "DELETE FROM Jogos WHERE IdJogo = @IdJogo";

                // Abre conexão com o banco de dados
                con.Open();

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os jogos cadastrados no banco de dados
        /// </summary>
        /// <returns>Uma lista dos jogos cadastrados</returns>
        public List<object> ListarTodos()
        {
            // Cria uma lista de jogos
            List<object> jogos = new List<object>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                // Consulta que será executada
                string queryRead = "SELECT " +
                                        "IdJogo, " +
                                        "NomeJogo, " +
                                        "Descricao, " +
                                        "DataLancamento, " +
                                        "Valor, " +
                                        "J.IdEstudio, " +
                                        "NomeEstudio " +
                                     "FROM Jogos J " +
                                     "INNER JOIN Estudios E ON J.IdEstudio = E.IdEstudio";

                // Abre conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryRead, con))
                {
                    // Executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver dados no rdr:
                    while (rdr.Read())
                    {
                        // Instancia um novo jogo
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            NomeJogo = rdr[1].ToString(),
                            Descricao = rdr[2].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = Convert.ToDecimal(rdr[4]),
                            IdEstudio = Convert.ToInt32(rdr[5]),
                            Estudios = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr[5]),
                                NomeEstudio = rdr[6].ToString()
                            }
                        };

                        // Adiciona o jogo na lista de jogos
                        jogos.Add(jogo);
                    }
                }
            }

            // Retorna a lista de jogos
            return jogos;
        }

        /// <summary>
        /// Cria uma lista de jogos de de um determinado estúdio, passando seu id
        /// </summary>
        /// <param name="idEstudio">Id do estúdio que deseja-se exibir os jogos</param>
        /// <returns>Uma lista de jogos do estúdio desejado</returns>
        public List<JogoDomain> ListarJogosDeUmEstudio(int idEstudio)
        {
            // Cria uma lista de jogos
            List<JogoDomain> jogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                // Consulta que será executada
                string querySelectById = "SELECT " +
                                            "IdJogo, " +
                                            "NomeJogo, " +
                                            "Descricao, " +
                                            "DataLancamento, " +
                                            "Valor " +
                                         "FROM Jogos J INNER JOIN Estudios E ON J.IdEstudio = E.IdEstudio " +
                                         "WHERE E.IdEstudio = @Id";

                // Abre conexão com o banco de dados
                con.Open();

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Define que o valor das variáveis receberão o valor dos atributos do objeto jogo
                    cmd.Parameters.AddWithValue("@Id", idEstudio);

                    // Executa a query e armazena os dados na rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Enquanto houver dados no rdr:
                    while (rdr.Read())
                    {
                        // Cria um novo jogo
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr[0]),
                            NomeJogo = rdr[1].ToString(),
                            Descricao = rdr[2].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[3]),
                            Valor = Convert.ToDecimal(rdr[4])
                        };

                        // Adiciona o jogo criado na lista de jogos
                        jogos.Add(jogo);
                    }

                    // Retorna a lista de jogos
                    return jogos;
                }
            }
        }
    }
}
