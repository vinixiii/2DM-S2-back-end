using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        /// <summary>
        /// Retorna todos os gêneros
        /// </summary>
        /// <returns>Lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero pelo seu id
        /// </summary>
        /// <param name="id">Id do gênero que será buscado</param>
        /// <returns>Objeto do tipo GeneroDomain</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Gênero que será que cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pela URl da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        /// <param name="id">Id do gênero que será atualizado</param>
        void AtualizarIdUrl(GeneroDomain genero, int id);

        /// <summary>
        /// Deleta um gênero
        /// </summary>
        /// <param name="id">Id do gênero que será deletado</param>
        void Deletar(int id);
    }
}
