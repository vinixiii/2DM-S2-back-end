using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros:
        /// Data source=DESKTOP-T9H6KLN; = Nome do servidor
        /// initial catalog=Filmes; = Nome do banco de dados
        /// user Id=sa; pwd=vini@132; = Faz a autenticação pelo user do SQL Server, passando o logon
        /// integrated security=true; = Faz a autenticação pelo user do sistema (windows)
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-T9H6KLN; initial catalog=Filmes; user Id=sa; pwd=vini@132";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(FilmeDomain filme, int id)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
        // private string stringConexao = "Data Source=DESKTOP-T9H6KLN; initial catalog=Filmes; integrated scurity=true";

    }
}
