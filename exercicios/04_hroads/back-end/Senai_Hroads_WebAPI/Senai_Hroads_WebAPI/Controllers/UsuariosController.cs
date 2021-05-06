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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Um status code Ok(200) e uma lista de Usuarios</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult ListarTodos()
        {
            // Retorna um status code Ok(200) e uma lista de Usuarios
            return Ok(_UsuarioRepository.ListarTodos());
        }

        /// <summary>
        /// Lista um Usuario pelo id
        /// </summary>
        /// <param name="id">Id do Usuario que será listado</param>
        /// <returns>Um status code Ok(200) e um Usuario</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult ListarPorId(int id)
        {
            // Retorna um status code Ok(200) e um Usuario
            return Ok(_UsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="usuario">Usuario que será cadastrado</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Usuario usuario)
        {
            // Cadastra um novo Usuario
            _UsuarioRepository.Cadastrar(usuario);

            // Retorna um status code Created(201)
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="id">Id do Usuario que será atualizado</param>
        /// <param name="usuario">Um Usuario com as novas informações</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            // Atualiza um Usuario existente
            _UsuarioRepository.Atualizar(id, usuario);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="id">Id do Usuario que será deletado</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            // Deleta um Usuario existente
            _UsuarioRepository.Deletar(id);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }
    }
}
