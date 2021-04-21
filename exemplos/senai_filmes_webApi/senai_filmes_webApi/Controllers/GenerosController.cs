using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints (URL's) referentes ao gêneros
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato: dominio/api/NomeDoController
    //Exemplo: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    //Define que é um controller de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface IGenerosRepository
        /// </summary>
        private IGeneroRepository _GeneroRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _GeneroRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Cria uma lista nomeada generos para receber os dados
            List<GeneroDomain> generos = _GeneroRepository.ListarTodos();

            //Retorna o status code 200(Ok) com a lista de gêneros no formato JSON
            return Ok(generos);
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero recebido na requisição</param>
        /// <returns>Um status code 201(created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            //Chama o método cadastrar passando o novo gênero
            _GeneroRepository.Cadastrar(novoGenero);

            //Retorna um status code 201(created)
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um gênero que já existe
        /// </summary>
        /// <param name="id">Id do gênero que será deletado</param>
        /// <returns>Um status code 204(no content)</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Chama o método deletar passando o id do gênero que será deletado
            _GeneroRepository.Deletar(id);

            //Retorna um status code 204(no content)
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um gênero pelo seu id
        /// </summary>
        /// <param name="id">Id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou NotFound caso nenhum gênero seja encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Cria um objeto GeneroDomain que irá receber o gênero buscado no banco de dados
            GeneroDomain genero = _GeneroRepository.BuscarPorId(id);

            if (genero == null)
            {
                //Caso não seja encontrado retorna um status code 404 com uma mensagem personalizada
                return NotFound("Nenhum gênero foi encontrado.");
            }

            //Caso não seja encontrado retorna o gênero buscado com um status code 200
            return Ok(genero);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="genero"></param>
        /// <returns>Status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, GeneroDomain genero)
        {
            //Cria um objeto GeneroDomain que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                //Caso não seja encontrado retorna um status code 404 com uma mensagem personalizada
                //e um booleano (flag)
                return NotFound(new{
                    mensagem = "Gênero não encontrado",
                    erro = true
                });
            }

            //Tenta atualizar o registro
            try
            {
                //Chama o método AtualizarIdUrl() passando os parâmetros
                _GeneroRepository.AtualizarIdUrl(genero, id);

                //Retorna um status code 204 - No content
                return StatusCode(204);
            }
            //Caso ocorra algum erro
            catch (Exception erro)
            {
                //Retorna um status code 400 e o código do erro
                return BadRequest(erro);
            }

            //try catch serve para tratar erros (exceptions)
        }

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição (JSON)
        /// </summary>
        /// <param name="genero">Objeto GeneroDomain com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutBody(GeneroDomain genero)
        {
            //Cria um objeto GeneroDomain que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _GeneroRepository.BuscarPorId(genero.IdGenero);

            //Verifica se algum gênero foi encontrado
            if (generoBuscado != null)
            {
                //Se sim, tenta atualizar o registro
                try
                {
                    //Chama o método AtualizarIdCorpo() passando os parâmetros
                    _GeneroRepository.AtualizarIdCorpo(genero);

                    //Retorna um status code 204 - No content
                    return StatusCode(204);
                }
                //Caso ocorra algum erro
                catch (Exception erro)
                {
                    //Retorna um status code 400 e o código do erro
                    return BadRequest(erro);
                }
            }

            //Caso não seja encontrado retorna um status code 404 com uma mensagem personalizada
            //e um booleano (flag)
            return NotFound(new
            {
                mensagem = "Gênero não encontrado",
                erro = true
            });
        }
    }
}
