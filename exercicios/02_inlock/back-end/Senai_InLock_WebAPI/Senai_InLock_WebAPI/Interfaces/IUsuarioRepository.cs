using Senai_InLock_WebAPI.Domains;

namespace Senai_InLock_WebAPI.Interfaces
{
    /// <summary>
    /// Interface relacionada aos Usuarios. Define quais serão os métodos executados pela API
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Faz a validação de email e senha do usuário
        /// </summary>
        /// <param name="email">Email inserido pelo usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Objeto contendo as informações do usuário</returns>
        UsuarioDomain Login(string email, string senha);
    }
}
