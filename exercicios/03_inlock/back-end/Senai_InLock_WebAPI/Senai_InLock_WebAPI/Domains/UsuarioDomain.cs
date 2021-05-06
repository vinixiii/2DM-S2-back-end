using System.ComponentModel.DataAnnotations;

namespace Senai_InLock_WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe seu e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O tipo de permissão de usuário é obrigatório")]
        public int IdTipoUsuario { get; set; }
    }
}
