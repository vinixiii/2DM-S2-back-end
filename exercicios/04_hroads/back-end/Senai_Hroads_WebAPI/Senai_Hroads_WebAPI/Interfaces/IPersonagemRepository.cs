using Senai_Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos os Personagens
        /// </summary>
        /// <returns>Uma lista com todos os Personagens</returns>
        List<Personagem> ListarTodos();

        /// <summary>
        /// Busca um Personagem pelo id
        /// </summary>
        /// <param name="id">Id do Personagem que será buscada</param>
        /// <returns>Um Personagem com suas informações</returns>
        Personagem BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personagem">Personagem que será cadastrado</param>
        void Cadastrar(int id, Personagem personagem);

        /// <summary>
        /// Atualiza um Personagem existente
        /// </summary>
        /// <param name="id">Id do Personagem que será atualizado</param>
        /// <param name="personagemAtualizado">Um Personagem com as novas informações</param>
        void Atualizar(int id, Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um Personagem existente
        /// </summary>
        /// <param name="id">Id do Personagem que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todos os Personagens de determinado jogador
        /// </summary>
        /// <returns>Uma lista dos Personagens de determinado jogador</returns>
        List<Personagem> ListarPorIdJogador(int id);

        /// <summary>
        /// Lista todos os Personagens com as informações dos Usuarios
        /// </summary>
        /// <returns>Uma lista com todos os Personagens e as informações dos Usuarios</returns>
        List<Personagem> ListarTodosADM();
    }
}
