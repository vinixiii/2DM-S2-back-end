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
    public class TiposDeHabilidadesController : ControllerBase
    {
        private ITiposDeHabilidadeRepository _TiposDeHabilidade { get; set; }

        public TiposDeHabilidadesController()
        {
            _TiposDeHabilidade = new TiposDeHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os TiposDeHabilidade
        /// </summary>
        /// <returns>Um status code Ok(200) e uma lista de TiposDeHabilidade</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            // Retorna um status code Ok(200) e uma lista de TiposDeHabilidade
            return Ok(_TiposDeHabilidade.ListarTodos());
        }

        /// <summary>
        /// Lista um TipoDeHabilidade pelo id
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será listado</param>
        /// <returns>Um status code Ok(200) e um TipoDeHabilidade</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            // Retorna um status code Ok(200) e um TipoDeHabilidade
            return Ok(_TiposDeHabilidade.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo TipoDeHabilidade
        /// </summary>
        /// <param name="tipoDeHabilidade">TipoDeHabilidade que será cadastrado</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(TiposDeHabilidade tipoDeHabilidade)
        {
            // Cadastra um novo TipoDeHabilidade
            _TiposDeHabilidade.Cadastrar(tipoDeHabilidade);

            // Retorna um status code Created(201)
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um TipoDeHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será atualizado</param>
        /// <param name="tipoDeHabilidade">Um TipoDeHabilidade com as novas informações</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, TiposDeHabilidade tipoDeHabilidade)
        {
            // Atualiza um TipoDeHabilidade existente
            _TiposDeHabilidade.Atualizar(id, tipoDeHabilidade);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um TipoDeHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será deletado</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            // Deleta um TipoDeHabilidade existente
            _TiposDeHabilidade.Deletar(id);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }
    }
}
