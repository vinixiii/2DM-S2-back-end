using Senai_Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Interfaces
{
    interface ITiposDeHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os TiposDeHabilidades
        /// </summary>
        /// <returns>Uma lista com todos os TiposDeHabilidades</returns>
        List<TiposDeHabilidade> ListarTodos();

        /// <summary>
        /// Busca um TipoDeHabilidade pelo id
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será buscado</param>
        /// <returns>Um TipoDeHabilidade com suas informações</returns>
        TiposDeHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo TipoDeHabilidade
        /// </summary>
        /// <param name="tipoDeHabilidade">TipoDeHabilidade que será cadastrado</param>
        void Cadastrar(TiposDeHabilidade tipoDeHabilidade);

        /// <summary>
        /// Atualiza um TipoDeHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será atualizado</param>
        /// <param name="tipoDeHabilidade">Um TipoDeHabilidade com as novas informações</param>
        void Atualizar(int id, TiposDeHabilidade tipoDeHabilidade);

        /// <summary>
        /// Deleta um TipoDeHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será deletado</param>
        void Deletar(int id);
    }
}
