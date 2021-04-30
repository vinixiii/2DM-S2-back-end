using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Hroads_WebAPI.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public int? IdTipo { get; set; }
        public string Nome { get; set; }

        public virtual TiposDeHabilidade IdTipoNavigation { get; set; }
    }
}
