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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Um status code Ok(200) e uma lista de Habilidades</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            // Retorna um status code Ok(200) e uma lista de Habilidades
            return Ok(_HabilidadeRepository.ListarTodos());
        }

        /// <summary>
        /// Lista um Habilidade pelo id
        /// </summary>
        /// <param name="id">Id da Habilidade que será listada</param>
        /// <returns>Um status code Ok(200) e uma Habilidade</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            // Retorna um status code Ok(200) e uma Habilidade
            return Ok(_HabilidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="habilidade">Habilidade que será cadastrada</param>
        /// <returns>Um status code Created(201)</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Cadastrar(Habilidade habilidade)
        {
            // Cadastra uma nova Habilidade
            _HabilidadeRepository.Cadastrar(habilidade);

            // Retorna um status code Created(201)
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma Habilidade existente
        /// </summary>
        /// <param name="id">Id da Habilidade que será atualizada</param>
        /// <param name="habilidade">Uma Habilidade com as novas informações</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, Habilidade habilidade)
        {
            // Atualiza uma Habilidade existente
            _HabilidadeRepository.Atualizar(id, habilidade);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma Habilidade existente
        /// </summary>
        /// <param name="id">Id da Habilidade que será deletada</param>
        /// <returns>Um status code NoContent(204)</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Deletar(int id)
        {
            // Deleta uma Habilidade existente
            _HabilidadeRepository.Deletar(id);

            // Retorna um status code NoContent(204)
            return StatusCode(204);
        }
    }
}
