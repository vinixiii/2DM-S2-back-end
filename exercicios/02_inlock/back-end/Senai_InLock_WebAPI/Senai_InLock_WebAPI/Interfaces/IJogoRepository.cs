using Senai_InLock_WebAPI.Domains;
using System.Collections.Generic;

namespace Senai_InLock_WebAPI.Interfaces
{
    /// <summary>
    /// Interface relacionada aos Jogos. Define quais serão os métodos executados pela API
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Objeto que contém as informações do jogo que será cadastrado</param>
        void Cadastrar(JogoDomain jogo);

        /// <summary>
        /// Lista todos os jogos cadastrados no banco de dados
        /// </summary>
        /// <returns>Uma lista dos jogos cadastrados</returns>
        List<object> ListarTodos();

        /// <summary>
        /// Deleta um jogo que está cadastrado no banco de dados, passando seu id
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os jogos de determinado estúdio
        /// </summary>
        /// <param name="id">Id do estúdio que deseja consultar os jogos</param>
        /// <returns>Uma lista com todos os jogos do estúdio desejado</returns>
        List<JogoDomain> ListarJogosDeUmEstudio(int id);
    }
}
