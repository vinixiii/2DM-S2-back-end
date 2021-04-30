using Senai_Gufi_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Gufi_WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TiposEventoRepository
    /// </summary>
    interface ITiposEventoRepository
    {
        List<TiposEvento> ListarTodos();

        TiposEvento BuscarPorId(int id);

        void Cadastrar(TiposEvento tipoEvento);

        void Atualizar(int id, TiposEvento tipoEvento);

        void Deletar(int id);
    }
}
