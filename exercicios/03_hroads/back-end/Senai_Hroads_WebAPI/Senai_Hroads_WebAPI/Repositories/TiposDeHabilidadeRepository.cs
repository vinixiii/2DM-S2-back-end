using Senai_Hroads_WebAPI.Contexts;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Repositories
{
    public class TiposDeHabilidadeRepository : ITiposDeHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um TipoDeHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será atualizado</param>
        /// <param name="tipoDeHabilidade">Um TipoDeHabilidade com as novas informações</param>
        public void Atualizar(int id, TiposDeHabilidade tipoDeHabilidade)
        {
            TiposDeHabilidade tipoDeHabilidadeAtualizado = BuscarPorId(id);

            if (tipoDeHabilidade != null)
            {
                tipoDeHabilidadeAtualizado.Nome = tipoDeHabilidade.Nome;
            }

            ctx.TiposDeHabilidades.Update(tipoDeHabilidadeAtualizado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um TipoDeHabilidade pelo id
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será buscado</param>
        /// <returns>Um TipoDeHabilidade</returns>
        public TiposDeHabilidade BuscarPorId(int id)
        {
            return ctx.TiposDeHabilidades.Find(id);
        }

        /// <summary>
        /// Cadastra um novo TipoDeHabilidade
        /// </summary>
        /// <param name="tipoDeHabilidade">TipoDeHabilidade que será cadastrado</param>
        public void Cadastrar(TiposDeHabilidade tipoDeHabilidade)
        {
            ctx.TiposDeHabilidades.Add(tipoDeHabilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um TipoDeHabilidade existente
        /// </summary>
        /// <param name="id">Id do TipoDeHabilidade que será deletado</param>
        public void Deletar(int id)
        {
            TiposDeHabilidade tipoDeHabilidade = BuscarPorId(id);
            
            ctx.Remove(tipoDeHabilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os TiposDeHabilidades
        /// </summary>
        /// <returns>Uma lista de TiposDeHabilidades</returns>
        public List<TiposDeHabilidade> ListarTodos()
        {
            return ctx.TiposDeHabilidades.ToList();
        }
    }
}
