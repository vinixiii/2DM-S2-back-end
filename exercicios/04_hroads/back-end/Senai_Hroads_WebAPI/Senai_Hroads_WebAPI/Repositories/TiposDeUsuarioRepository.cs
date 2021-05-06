using Microsoft.EntityFrameworkCore;
using Senai_Hroads_WebAPI.Contexts;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Repositories
{
    public class TiposDeUsuarioRepository : ITiposDeUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um TipoDeUsuario existente
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será atualizado</param>
        /// <param name="tipoDeUsuario">Um TipoDeUsuario com as novas informações</param>
        public void Atualizar(int id, TiposDeUsuario tipoDeUsuario)
        {
            TiposDeUsuario tipoDeUsuarioAtualizado = BuscarPorId(id);

            if (tipoDeUsuario != null)
            {
                tipoDeUsuarioAtualizado.Titulo = tipoDeUsuario.Titulo;
            }

            ctx.TiposDeUsuarios.Update(tipoDeUsuarioAtualizado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um TipoDeUsuario pelo id
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será buscado</param>
        /// <returns>Um TipoDeUsuario</returns>
        public TiposDeUsuario BuscarPorId(int id)
        {
            return ctx.TiposDeUsuarios.Find(id);
        }

        /// <summary>
        /// Cadastra um novo TipoDeUsuario
        /// </summary>
        /// <param name="tipoDeUsuario">TipoDeUsuario que será cadastrado</param>
        public void Cadastrar(TiposDeUsuario tipoDeUsuario)
        {
            ctx.TiposDeUsuarios.Add(tipoDeUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um TipoDeUsuario existente
        /// </summary>
        /// <param name="id">Id do TipoDeUsuario que será deletado</param>
        public void Deletar(int id)
        {
            TiposDeUsuario tipoDeUsuario = BuscarPorId(id);

            ctx.TiposDeUsuarios.Remove(tipoDeUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os TiposDeUsuarios
        /// </summary>
        /// <returns>Uma lista de TiposDeUsuarios</returns>
        public List<TiposDeUsuario> ListarTodos()
        {
            return ctx.TiposDeUsuarios.ToList();
        }
    }
}
