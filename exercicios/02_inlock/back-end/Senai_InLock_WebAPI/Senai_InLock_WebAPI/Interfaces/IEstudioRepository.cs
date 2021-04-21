using System.Collections.Generic;

namespace Senai_InLock_WebAPI.Interfaces
{
    /// <summary>
    /// Interface relacionada aos Estudios. Define quais serão os métodos executados pela API
    /// </summary>
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estudios e seus respectivos jogos cadastrados no banco de dados
        /// </summary>
        /// <returns>Uma lista dos estudios e seus respectivos jogos cadastrados</returns>
        List<object> ListarTodos();
    }
}
