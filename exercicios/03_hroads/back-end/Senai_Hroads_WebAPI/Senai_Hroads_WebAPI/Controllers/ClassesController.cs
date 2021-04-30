using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using Senai_Hroads_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Controllers
{
    // Define que a resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requesição será no formato: dominio/api/nomedocontroller
    [Route("api/[controller]")]

    // Define que é um Controller de API
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _ClasseRepository { get; set; }

        public ClassesController()
        {
            _ClasseRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todas as Classes
        /// </summary>
        /// <returns>Um status code Ok(200) e uma lista de Classes</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            // Retorna um status code Ok(200) e uma lista de Classes
            return Ok(_ClasseRepository.ListarTodos());
        }

        /// <summary>
        /// Lista um Classe pelo id
        /// </summary>
        /// <param name="id">Id da Classe que será listada</param>
        /// <returns>Um status code Ok(200) e uma Classe</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            // Retorna um status code Ok(200) e uma Classe
            return Ok(_ClasseRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="classe">Classe que será cadastrada</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Classe classe)
        {
            // Cadastra uma nova Classe
            _ClasseRepository.Cadastrar(classe);

            // Retorna um status code Created(201)
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma Classe existente
        /// </summary>
        /// <param name="id">Id da Classe que será atualizada</param>
        /// <param name="classe">Uma Classe com as novas informações</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, Classe classe)
        {
            // Atualiza uma Classe existente
            _ClasseRepository.Atualizar(id, classe);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma Classe existente
        /// </summary>
        /// <param name="id">Id da Classe que será deletada</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            // Deleta uma Classe existente
            _ClasseRepository.Deletar(id);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }
    }
}
