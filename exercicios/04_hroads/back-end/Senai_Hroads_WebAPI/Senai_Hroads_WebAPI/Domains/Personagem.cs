using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Hroads_WebAPI.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Mana { get; set; }
        public DateTime DataDeAtualizacao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
