using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_InLock_WebAPI.Domains;
using Senai_InLock_WebAPI.Interfaces;
using Senai_InLock_WebAPI.Repositories;
using System.Collections.Generic;

namespace Senai_InLock_WebAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato: dominio/api/NomeDoController
    // Exemplo: http://localhost:5000/api/jogos
    [Route("api/[controller]")]

    // Define que é um controller de API
    [ApiController]

    /// <summary>
    /// Classe responsável pelos endpoints (URL's) referentes aos jogos
    /// </summary>
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Objeto que recebe os métodos definidos na interface IJogoRepository
        /// </summary>
        private IJogoRepository _JogoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _JogoRepository para referenciar os métodos no repositório
        /// </summary>
        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Um status code 200(ok) junto com as informações dos jogos</returns>
        //  [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult ListarJogos()
        {
            // Cria uma lista de jogos e seus respectivos estúdios
            List<object> jogos = _JogoRepository.ListarTodos();

            // Retorna um status code 200(ok) junto com as informações dos jogos
            return Ok(jogos);
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="jogo">Objeto com as informações do jogo que será cadastrado</param>
        /// <returns>Um status code 201(created)</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastarJogo(JogoDomain jogo)
        {
            // Chama o método cadastrar passando o novo jogo
            _JogoRepository.Cadastrar(jogo);

            // Retorna um status code 201(created)
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="id">Id do jogo que será deletado</param>
        /// <returns>Um status code 204(no content)</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult DeletarJogo(int id)
        {
            // Chama o método deletar passando o id do jogo que será deletado
            _JogoRepository.Deletar(id);

            // Retorna um status code 204(no content)
            return StatusCode(204);
        }
    }
}
