using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string stringConexao = "Data Source=DESKTOP-T9H6KLN; initial catalog=Filmes; user Id=sa; pwd=vini@132";

        /// <summary>
        /// Atualiza um gênero passando o id pelo corpo do JSON
        /// </summary>
        /// <param name="genero">Objeto gênero com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryUpdateBody = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    //Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@Id", genero.IdGenero);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o id pelo recurso (url)
        /// </summary>
        /// <param name="genero">Objeto gênero com as novas informações</param>
        /// <param name="id">Id do gênero que será atualizado</param>
        public void AtualizarIdUrl(GeneroDomain genero, int id)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryUpdateUrl = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@Id", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @Id";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //Passa o valor para o parâmetro @Id
                    cmd.Parameters.AddWithValue("Id", id);

                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se a query retornou algum registro
                    if (rdr.Read())
                    {
                        //Se verdadeiro, instancia um novo objeto GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui à propriedade IdGenero o valor da coluna IdGenero da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            //Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                            Nome = rdr["Nome"].ToString()
                        };

                        return genero;
                    }

                    //Se não houver registro na query, retorna nulo
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto GeneroDomain com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryInsert = "INSERT INTO Generos (Nome) VALUES(@Nome)";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um gênero através do seu id
        /// </summary>
        /// <param name="id">Id do gênero que será deletado</param>
        public void Deletar(int id)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query a ser executada
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @Id";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Passa o valor para o parâmetro @Id
                    cmd.Parameters.AddWithValue("@Id", id);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista onde serão armazenados os dados dos gêneros
            List<GeneroDomain> generos = new List<GeneroDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdGenero, Nome FROM Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui à propriedade Nome o valor da segunda coluna da tabela do banco de dados
                            Nome = rdr[1].ToString()
                        };

                        //Adiciona o objeto gênero à lista gêneros
                        generos.Add(genero);
                    }
                }
            }

            //Retorna a lista de gêneros
            return generos;
        }
    }
}
