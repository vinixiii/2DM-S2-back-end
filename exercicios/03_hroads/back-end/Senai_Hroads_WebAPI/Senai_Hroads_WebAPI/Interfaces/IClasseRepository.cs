using Senai_Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista com todas as classes</returns>
        List<Classe> ListarTodos();

        /// <summary>
        /// Busca uma classe pelo id
        /// </summary>
        /// <param name="id">Id da classe que será buscada</param>
        /// <returns>Uma classe com suas informações</returns>
        Classe BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="classe">Classe que será cadastrada</param>
        void Cadastrar(Classe classe);

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será atualizada</param>
        /// <param name="classe">Uma classe com as novas informações</param>
        void Atualizar(int id, Classe classe);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="id">Id da classe que será deletada</param>
        void Deletar(int id);
    }
}
