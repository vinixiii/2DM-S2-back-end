using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Hroads_WebAPI.Domains
{
    public partial class TiposDeHabilidade
    {
        public TiposDeHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
