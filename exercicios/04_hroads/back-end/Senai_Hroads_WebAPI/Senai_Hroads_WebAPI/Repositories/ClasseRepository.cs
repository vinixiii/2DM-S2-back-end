using Senai_Hroads_WebAPI.Contexts;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma Classe existente
        /// </summary>
        /// <param name="id">Id da Classe que será atualizada</param>
        /// <param name="classe">Uma Classe com as novas informações</param>
        public void Atualizar(int id, Classe classe)
        {
            Classe classeAtualizada = BuscarPorId(id);

            if (classe != null)
            {
                classeAtualizada.Nome = classe.Nome;
            }

            ctx.Classes.Update(classeAtualizada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Classe pelo id
        /// </summary>
        /// <param name="id">Id da Classe que será buscada</param>
        public Classe BuscarPorId(int id)
        {
            return ctx.Classes.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova Classe
        /// </summary>
        /// <param name="classe">Classe que será cadastrada</param>
        public void Cadastrar(Classe classe)
        {
            ctx.Classes.Add(classe);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Classe existente
        /// </summary>
        /// <param name="id">Id da Classe que será deletada</param>
        public void Deletar(int id)
        {
            Classe classe = BuscarPorId(id);

            ctx.Classes.Remove(classe);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Classes
        /// </summary>
        /// <returns>Uma lista de Classes</returns>
        public List<Classe> ListarTodos()
        {
            return ctx.Classes.ToList();
        }
    }
}
