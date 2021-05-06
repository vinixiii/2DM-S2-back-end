using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Senai_Hroads_WebAPI.Contexts;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um Personagem existente
        /// </summary>
        /// <param name="id">Id do Personagem que será atualizado</param>
        /// <param name="personagem">Um Personagem com as novas informações</param>
        public void Atualizar(int id, Personagem personagem)
        {
            Personagem personagemAtualizado = BuscarPorId(id);

            if (personagem != null)
            {
                personagemAtualizado.IdClasse = personagem.IdClasse;
                personagemAtualizado.Nome = personagem.Nome;
                personagemAtualizado.Vida = personagem.Vida;
                personagemAtualizado.Mana = personagem.Mana;
                personagemAtualizado.DataDeAtualizacao = personagem.DataDeAtualizacao;
                personagemAtualizado.DataDeCriacao = personagem.DataDeCriacao;
            }

            ctx.Personagens.Update(personagemAtualizado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Personagem pelo id
        /// </summary>
        /// <param name="id">Id do Personagem que será listado</param>
        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagens.Find(id);
        }

        /// <summary>
        /// Cadastra um novo Personagem
        /// </summary>
        /// <param name="id">Id do Usuario que cadastrou o personagem</param>
        /// <param name="personagem">Personagem que será cadastrado</param>
        public void Cadastrar(int id, Personagem personagem)
        {
            Personagem novoPersonagem = new Personagem
            {
                IdPersonagem = personagem.IdPersonagem,
                IdClasse = personagem.IdClasse,
                Nome = personagem.Nome,
                Vida = personagem.Vida,
                Mana = personagem.Mana,
                DataDeAtualizacao = personagem.DataDeAtualizacao,
                DataDeCriacao = personagem.DataDeCriacao,
                IdUsuario = Convert.ToInt32(id)
            };

            ctx.Personagens.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Personagem existente
        /// </summary>
        /// <param name="id">Id do Personagem que será deletado</param>
        public void Deletar(int id)
        {
            Personagem personagem = BuscarPorId(id);

            ctx.Personagens.Remove(personagem);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Personagens de determinado jogador
        /// </summary>
        /// <param name="id">Id do Jogador terá seus Personagens listados</param>
        /// <returns>Uma lista dos Personagens de determinado jogador</returns>
        public List<Personagem> ListarPorIdJogador(int id)
        {
            return ctx.Personagens
                .Include(p => p.IdClasseNavigation)
                .Where(p => p.IdUsuario == id)
                .OrderBy(p => p.IdClasseNavigation.Nome)
                .ToList();
        }

        /// <summary>
        /// Lista todos os Personagens
        /// </summary>
        /// <returns>Uma lista de Personagens</returns>
        public List<Personagem> ListarTodos()
        {
            return ctx.Personagens
                .Include(p => p.IdClasseNavigation)
                .OrderBy(p => p.IdClasseNavigation.Nome)
                .ToList();
        }

        /// <summary>
        /// Lista todos os Personagens com as informações dos Usuarios
        /// </summary>
        /// <returns>Uma lista com todos os Personagens e as informações dos Usuarios</returns>
        public List<Personagem> ListarTodosADM()
        {
            return ctx.Personagens
                .Include(p => p.IdClasseNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Select(p => new Personagem
                {
                    IdPersonagem = p.IdPersonagem,
                    IdClasse = p.IdClasse,
                    Nome = p.Nome,
                    Vida = p.Vida,
                    Mana = p.Mana,
                    DataDeAtualizacao = p.DataDeAtualizacao,
                    DataDeCriacao = p.DataDeCriacao,
                    IdUsuario = p.IdUsuario,
                    IdUsuarioNavigation = new Usuario
                    {
                        IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                        Email = p.IdUsuarioNavigation.Email,
                        IdTipoUsuario = p.IdUsuarioNavigation.IdTipoUsuario
                    },
                    IdClasseNavigation = new Classe
                    {
                        IdClasse = p.IdClasseNavigation.IdClasse,
                        Nome = p.IdClasseNavigation.Nome
                    }
                })
                .OrderBy(p => p.IdClasseNavigation.Nome)
                .ToList();
        }
    }
}
