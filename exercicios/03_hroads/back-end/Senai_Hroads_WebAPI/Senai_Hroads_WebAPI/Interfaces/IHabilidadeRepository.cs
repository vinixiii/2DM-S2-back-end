using Senai_Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as Habilidades
        /// </summary>
        /// <returns>Uma lista com todas as Habilidades</returns>
        List<Habilidade> ListarTodos();

        /// <summary>
        /// Busca uma Habilidade pelo id
        /// </summary>
        /// <param name="id">Id da Habilidade que será buscada</param>
        /// <returns>Uma Habilidade com suas informações</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova Habilidade
        /// </summary>
        /// <param name="habilidade">Habilidade que será cadastrada</param>
        void Cadastrar(Habilidade habilidade);

        /// <summary>
        /// Atualiza uma Habilidade existente
        /// </summary>
        /// <param name="id">Id da Habilidade que será atualizada</param>
        /// <param name="habilidade">Uma Habilidade com as novas informações</param>
        void Atualizar(int id, Habilidade habilidade);

        /// <summary>
        /// Deleta uma Habilidade existente
        /// </summary>
        /// <param name="id">Id da Habilidade que será deletada</param>
        void Deletar(int id);
    }
}
