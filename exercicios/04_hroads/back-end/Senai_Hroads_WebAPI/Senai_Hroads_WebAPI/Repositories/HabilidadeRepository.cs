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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma Habilidade existente
        /// </summary>
        /// <param name="id">Id da Habilidade que será atualizada</param>
        /// <param name="habilidade">Uma Habilidade com as novas informações</param>
        public void Atualizar(int id, Habilidade habilidade)
        {
            Habilidade habilidadeAtualizada = BuscarPorId(id);

            if (habilidade != null)
            {
                habilidadeAtualizada.Nome = habilidade.Nome;
                habilidadeAtualizada.IdTipo = habilidade.IdTipo;
            }

            ctx.Habilidades.Update(habilidadeAtualizada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Habilidade pelo id
        /// </summary>
        /// <param name="id">Id da Habilidade que será buscada</param>
        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="habilidade">Habilidade que será cadastrada</param>
        public void Cadastrar(Habilidade habilidade)
        {
            ctx.Habilidades.Add(habilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Habilidade existente
        /// </summary>
        /// <param name="id">Id da Habilidade que será deletada</param>
        public void Deletar(int id)
        {
            Habilidade habilidade = BuscarPorId(id);

            ctx.Habilidades.Remove(habilidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Uma lista de Habilidades</returns>
        public List<Habilidade> ListarTodos()
        {
            return ctx.Habilidades.Include(h => h.IdTipoNavigation).ToList();
        }
    }
}
