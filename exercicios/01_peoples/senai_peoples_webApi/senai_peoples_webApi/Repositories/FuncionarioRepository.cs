using Senai_Peoples_WebAPI.Domains;
using Senai_Peoples_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Peoples_WebAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        // String de conexão com o banco de dados
        private string conexao = "Data Source=DESKTOP-T9H6KLN; initial catalog=Peoples; user Id=sa; pwd=vini@132";

        /// <summary>
        /// Cadastra um novo funcionário na tabela de funcionários do banco de dados
        /// </summary>
        /// <param name="funcionario">Objeto que recebe os dados do funcionário que será cadastrado</param>
        public void Create(FuncionarioDomain funcionario)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(conexao))
            {
                // Declara a query a ser executada
                string queryInsert = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES(@Nome, @Sobrenome)";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Define que o valor da variável @Nome será igual ao atributo Nome do funcionário que será criado
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    // Define que o valor da variável @Sobrenome será igual ao atributo Sobrenome do funcionário que será criado
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar um funcionário da tabela funcionários no banco de dados
        /// </summary>
        /// <param name="id">Id do funcionário que será deletado</param>
        public void Delete(int id)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(conexao))
            {
                //Declara a query a ser executada
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";

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
        /// Lista todos os funcionários
        /// </summary>
        /// <returns>Uma lista com todos os funcionários</returns>
        public List<FuncionarioDomain> ReadAll()
        {
            // Cria uma lista onde serão armazenados os dados de todos funcionários
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(conexao))
            {
                // Declara a query a ser executada
                string queryRead = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryRead, con))
                {
                    // Executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto do tipo GeneroDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //Atribui à propriedade IdFuncionario o valor da coluna IdGenero da tabela do banco de dados
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            //Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                            Nome = rdr[1].ToString(),
                            //Atribui à propriedade Sobrenome o valor da coluna Sobrenome da tabela do banco de dados
                            Sobrenome = rdr[2].ToString()
                        };

                        // Adiciona o objeto funcionario à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionários
            return funcionarios;
        }

        /// <summary>
        /// Busca um funcionário passando um id específico
        /// </summary>
        /// <param name="id">Id do funcionário que se deseja buscar</param>
        /// <returns>Um funcionário ou nulo</returns>
        public FuncionarioDomain SearchById(int id)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(conexao))
            {
                //Declara a query a ser executada
                string querySearchById = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @Id";

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Passa o valor para o parâmetro @Id
                    cmd.Parameters.AddWithValue("Id", id);

                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Verifica se a query retornou algum registro
                    if(rdr.Read())
                    {
                        //Se verdadeiro, instancia um novo objeto GeneroDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            //Atribui à propriedade IdFuncionario o valor da coluna IdGenero da tabela do banco de dados
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            //Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                            Nome = rdr[1].ToString(),
                            //Atribui à propriedade Sobrenome o valor da coluna Sobrenome da tabela do banco de dados
                            Sobrenome = rdr[2].ToString()
                        };
                        
                        return funcionario;
                    }

                    //Se não houver registro na query, retorna nulo
                    return null;
                }
            }
        }

        /// <summary>
        /// Atualiza um funcionário passando o id pelo recurso (url)
        /// </summary>
        /// <param name="id">Id do funcionário que será atualizado</param>
        /// <param name="funcionario">Objeto com os novos dados do funcionário</param>
        public void Update(int id, FuncionarioDomain funcionario)
        {
            //Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(conexao))
            {
                //Declara a query a ser executada
                string queryUpdateUrl = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //Passa os valores para os parâmetros
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);                    

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
