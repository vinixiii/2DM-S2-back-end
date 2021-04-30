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

    public class TiposDeUsuariosController : ControllerBase
    {
        private ITiposDeUsuarioRepository _TiposDeUsuarioRepository { get; set; }

        public TiposDeUsuariosController()
        {
            _TiposDeUsuarioRepository = new TiposDeUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os TiposDeUsuarios
        /// </summary>
        /// <returns>Um status code Ok(200) e uma lista de TiposDeUsuarios</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodos()
        {
            // Retorna um status code Ok(200) e uma lista de TiposDeUsuarios
            return Ok(_TiposDeUsuarioRepository.ListarTodos());
        }

        /// <summary>
        /// Lista um TipoDeUsuario pelo id
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será listado</param>
        /// <returns>Um status code Ok(200) e um TipoDeUsuario</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult ListarPorId(int id)
        {
            // Retorna um status code Ok(200) e um TipoDeUsuario
            return Ok(_TiposDeUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo TipoDeUsuario
        /// </summary>
        /// <param name="tipoDeUsuario">TipoDeUsuario que será cadastrado</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(TiposDeUsuario tipoDeUsuario)
        {
            // Cadastra um novo TipoDeUsuario
            _TiposDeUsuarioRepository.Cadastrar(tipoDeUsuario);

            // Retorna um status code Created(201)
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um TipoDeUsuario existente
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será atualizado</param>
        /// <param name="tipoDeUsuario">Um TipoDeUsuario com as novas informações</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, TiposDeUsuario tipoDeUsuario)
        {
            // Atualiza um TipoDeUsuario existente
            _TiposDeUsuarioRepository.Atualizar(id, tipoDeUsuario);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um TipoDeUsuario existente
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será deletado</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            // Deleta um TipoDeUsuario existente
            _TiposDeUsuarioRepository.Deletar(id);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }
    }
}
