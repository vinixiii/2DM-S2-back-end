using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Retorna todos os filmes
        /// </summary>
        /// <returns>Lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme pelo seu id
        /// </summary>
        /// <param name="id">Id do filme que será buscado</param>
        /// <returns>Objeto do tipo FilmeDomain</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoGenero">Filme que será que cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando o id pela URl da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        /// <param name="id">Id do filme que será atualizado</param>
        void AtualizarIdUrl(FilmeDomain filme, int id);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id">Id do filme que será deletado</param>
        void Deletar(int id);
    }
}
