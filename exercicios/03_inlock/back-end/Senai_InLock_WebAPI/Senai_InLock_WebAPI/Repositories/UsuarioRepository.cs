using Senai_InLock_WebAPI.Domains;
using Senai_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_InLock_WebAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private string conexao = "Data Source=DESKTOP-T9H6KLN; initial catalog=InLock_Games_Manha; user Id=sa; pwd=vini@132";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string queryLogin = "SELECT IdUsuario, Email, Senha, IdTipoUsuario " +
                                    "FROM Usuarios " +
                                    "WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Email = rdr[1].ToString(),
                            Senha = rdr[2].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr[3])
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
