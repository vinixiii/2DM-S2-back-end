using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Hroads_WebAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Personagens = new HashSet<Personagem>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public virtual TiposDeUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
