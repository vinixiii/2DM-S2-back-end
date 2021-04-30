using Senai_Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Interfaces
{
    interface ITiposDeUsuarioRepository
    {
        /// <summary>
        /// Lista todos os TiposDeUsuarios
        /// </summary>
        /// <returns>Uma lista com todos os TiposDeUsuarios</returns>
        List<TiposDeUsuario> ListarTodos();

        /// <summary>
        /// Busca um TipoDeUsuario pelo id
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será buscado</param>
        /// <returns>Um TipoDeUsuario com suas informações</returns>
        TiposDeUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo TipoDeUsuario
        /// </summary>
        /// <param name="tipoDeUsuario">TipoDeUsuario que será cadastrado</param>
        void Cadastrar(TiposDeUsuario tipoDeUsuario);

        /// <summary>
        /// Atualiza um TipoDeUsuario existente
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será atualizado</param>
        /// <param name="tipoDeUsuario">Um TipoDeUsuario com as novas informações</param>
        void Atualizar(int id, TiposDeUsuario tipoDeUsuario);

        /// <summary>
        /// Deleta um TipoDeUsuario existente
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será deletado</param>
        void Deletar(int id);
    }
}
