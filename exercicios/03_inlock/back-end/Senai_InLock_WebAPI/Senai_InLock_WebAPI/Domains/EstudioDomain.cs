using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai_InLock_WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade Estudios
    /// </summary>
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        public string NomeEstudio { get; set; }

        public List<JogoDomain> Jogos { get; set; }
    }
}
