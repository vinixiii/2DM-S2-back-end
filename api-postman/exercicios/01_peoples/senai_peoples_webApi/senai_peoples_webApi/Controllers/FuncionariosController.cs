using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Peoples_WebAPI.Domains;
using Senai_Peoples_WebAPI.Interfaces;
using Senai_Peoples_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Peoples_WebAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato: dominio/api/NomeDoController
    // Exemplo: http://localhost:5000/api/funcionarios
    [Route("api/[controller]")]

    // Define que é um controller de API
    [ApiController]

    /// <summary>
    /// Classe responsável pelos endpoints (URL's) referentes aos funcionários
    /// </summary>
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que recebe possui todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _FuncionarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionariosController()
        {
            _FuncionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Busca todos os funcionários
        /// </summary>
        /// <returns>Um status code 200(ok) junto com os dados dos funcionários</returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //Cria uma lista de funcionarios que irá receber os dados
            List<FuncionarioDomain> funcionarios = _FuncionarioRepository.ReadAll();

            //Retorna o status code 200(Ok) com a lista de funcionários no formato JSON
            return Ok(funcionarios);
        }

        /// <summary>
        /// Busca um funcionário passando seu id
        /// </summary>
        /// <param name="id">Id do funcionário que será buscado</param>
        /// <returns>Um status code 404(not found) ou um status code 200(ok) junto com os dados do funcionário</returns>
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            //Cria um objeto que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionario = _FuncionarioRepository.SearchById(id);

            //Verifica se o objeto funcionário está vazio
            if (funcionario == null)
            {
                //Caso não seja encontrado retorna um status code 404(not found) com uma mensagem personalizada
                return NotFound("Nenhum funcionário foi encontrado!");
            }

            //Caso seja encontrado retorna um status code 200(ok) e o funcionário buscado
            return Ok(funcionario);
        }

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="funcionario">Objeto recebido na requisição</param>
        /// <returns>Um status code 201(created)</returns>
        [HttpPost]
        public IActionResult Create(FuncionarioDomain funcionario)
        {
            //Chama o método cadastrar passando o novo funcionário
            _FuncionarioRepository.Create(funcionario);

            //Retorna um status code 201(created)
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um funcionário
        /// </summary>
        /// <param name="id">Id do funcionário que será deletado</param>
        /// <returns>Um status code 204(no content)</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Chama o método deletar passando o id do gênero que será deletado
            _FuncionarioRepository.Delete(id);

            //Retorna um status code 204(no content)
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza os dados de um funcionário específico
        /// </summary>
        /// <param name="id">Id do funcionário que terá os dados atualizados</param>
        /// <param name="funcionario">Objeto com os novos dados do funcionário</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, FuncionarioDomain funcionario)
        {
            //Cria um objeto que irá receber os dados do funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _FuncionarioRepository.SearchById(id);

            //Verifica se o funcionarioBuscado é vazio
            if (funcionarioBuscado == null)
            {
                //Caso não seja encontrado retorna um status code 404 com uma mensagem personalizada
                //e um booleano (flag)
                return NotFound(new
                {
                    mensagem = "Funcionário não encontrado",
                    erro = true
                });
            }

            //Tenta atualizar o registro
            try
            {
                //Chama o método Update() passando os parâmetros
                _FuncionarioRepository.Update(id, funcionario);

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
    }
}
