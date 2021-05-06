using Senai_Peoples_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Peoples_WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository.
    /// Nesta camada são listados os métodos que serão executados pela API.
    /// </summary>
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Cadastra um novo funcionário à tabela do banco de dados.
        /// </summary>
        /// <param name="funcionario">Funcionário que será cadastrado.</param>
        void Create(FuncionarioDomain funcionario);

        /// <summary>
        /// Lista todos os funcionários cadastrados.
        /// </summary>
        /// <returns>Uma lista de funcionários.</returns>
        List<FuncionarioDomain> ReadAll();

        /// <summary>
        /// Atualiza um funcionário à tabela do banco de dados, passando o id.
        /// </summary>
        /// <param name="id">Id do funcionário que terá os dados atualizados.</param>
        /// <param name="funcionario">Objeto funcionário com as novas informações.</param>
        void Update(int id, FuncionarioDomain funcionario);

        /// <summary>
        /// Deleta um funcionário na tabela do banco de dados, passando o id.
        /// </summary>
        /// <param name="id">Id do funcionário que será deletado.</param>
        void Delete(int id);

        /// <summary>
        /// Busca um funcionário na tabela do banco de dados pelo seu id.
        /// </summary>
        /// <param name="id">Id do funcionário que será buscado.</param>
        /// <returns>Um objeto 'funcionário' do tipo FuncionariosDomain.</returns>
        FuncionarioDomain SearchById(int id);
    }
}
