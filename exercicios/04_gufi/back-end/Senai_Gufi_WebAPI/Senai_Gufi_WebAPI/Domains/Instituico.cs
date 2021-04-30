﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_Gufi_WebAPI.Domains
{
    public partial class Instituico
    {
        public Instituico()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdInstituicao { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
