using System;
using System.ComponentModel.DataAnnotations;

namespace Senai_InLock_WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogos
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage =  "O nome do jogo é obrigatório")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "A descrição do jogo é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O id do estúdio é obrigatório")]
        public int IdEstudio { get; set; }

        public EstudioDomain Estudios { get; set; }
    }
}
