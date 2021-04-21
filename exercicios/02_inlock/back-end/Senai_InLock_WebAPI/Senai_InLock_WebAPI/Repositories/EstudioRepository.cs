using Senai_InLock_WebAPI.Domains;
using Senai_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_InLock_WebAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string conexao = "Data Source=DESKTOP-T9H6KLN; initial catalog=InLock_Games_Manha; user Id=sa; pwd=vini@132";

        public List<object> ListarTodos()
        {
            List<object> estudios = new List<object>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                // Consulta que será executada
                string queryRead = "SELECT " +
                                        "E.IdEstudio, " +
                                        "NomeEstudio, " +
                                        "IdJogo, " +
                                        "NomeJogo, " +
                                        "Descricao, " +
                                        "DataLancamento, " +
                                        "Valor " +
                                   "FROM Estudios E LEFT JOIN Jogos J ON E.IdEstudio = J.IdEstudio";

                // Abre conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryRead, con))
                {
                    // Executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoRepository _JogoRepository = new JogoRepository();

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            NomeEstudio = rdr[1].ToString(),
                            Jogos = _JogoRepository.ListarJogosDeUmEstudio(Convert.ToInt32(rdr[0]))
                        };

                        estudios.Add(estudio);
                    }
                }
            }

            return estudios;
        }
    }
}
