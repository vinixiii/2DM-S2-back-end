using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using Senai_Hroads_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Controllers
{
    // Define que a resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requesição será no formato: dominio/api/nomedocontroller
    [Route("api/[controller]")]

    // Define que é um Controller de API
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _PersonagemRepository { get; set; }

        public PersonagensController()
        {
            _PersonagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os Personagens
        /// </summary>
        /// <returns>Um status code Ok(200) e uma lista de Personagens</returns>
        [HttpGet]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarTodos()
        {
            // Retorna um status code Ok(200) e uma lista de Personagens
            return Ok(_PersonagemRepository.ListarTodos());
        }

        [HttpGet("adm")]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodosADM()
        {
            return Ok(_PersonagemRepository.ListarTodosADM());
        }

        /// <summary>
        /// Lista um Personagem pelo id
        /// </summary>
        /// <param name="id">Id do Personagem que será listado</param>
        /// <returns>Um status code Ok(200) e um Personagem</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarPorId(int id)
        {
            // Retorna um status code Ok(200) e um Personagem
            return Ok(_PersonagemRepository.BuscarPorId(id));
        }

        [HttpGet("jogador/{id}")]
        [Authorize(Roles = "1, 2")]
        public IActionResult ListarPorIdJogador(int id)
        {
            return Ok(_PersonagemRepository.ListarPorIdJogador(id));
        }

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="personagem">Personagem que será cadastrado</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        [Authorize(Roles = "2")]
        public IActionResult Cadastrar(Personagem personagem)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                int id = Convert.ToInt32(identity.FindFirst("Jti").Value);

                // Cadastra um novo Personagem, passando o IdUsuario
                _PersonagemRepository.Cadastrar(id, personagem);

                // Retorna um status code Created(201)
                return StatusCode(201);
            }

            // Retorna um status code BadRequest() e uma mensagem personalizada
            return BadRequest("Não deu certo");
        }

        /// <summary>
        /// Atualiza um Personagem existente
        /// </summary>
        /// <param name="id">Id do Personagem que será atualizado</param>
        /// <param name="personagem">Um Personagem com as novas informações</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Atualizar(int id, Personagem personagem)
        {
            // Atualiza um Personagem existente
            _PersonagemRepository.Atualizar(id, personagem);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um Personagem existente
        /// </summary>
        /// <param name="id">Id do Personagem que será deletado</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Deletar(int id)
        {
            // Deleta um Personagem existente
            _PersonagemRepository.Deletar(id);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }
    }
}
