using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_Gufi_WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade TiposEventos
    /// </summary>
    public partial class TiposEvento
    {
        public TiposEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdTipoEvento { get; set; }

        // Define que o campo é obrigatório ao cadastrar um novo TipoEvento
        [Required(ErrorMessage = "O título de um tipo de evento é obrigatório")]
        public string Titulo { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
