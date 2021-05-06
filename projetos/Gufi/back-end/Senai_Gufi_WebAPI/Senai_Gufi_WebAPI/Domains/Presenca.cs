using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Gufi_WebAPI.Domains
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }
        public string Situacao { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
