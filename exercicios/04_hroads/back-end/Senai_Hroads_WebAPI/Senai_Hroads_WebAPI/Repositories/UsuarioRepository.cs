using Microsoft.EntityFrameworkCore;
using Senai_Hroads_WebAPI.Contexts;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai_Hroads_WebAPI.Repositories
{    
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="id">Id do Usuario que será atualizado</param>
        /// <param name="usuario">Um Usuario com as novas informações</param>
        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioAtualizado = ctx.Usuarios.Find(id);

            if (usuario != null)
            {
                usuarioAtualizado.Email = usuario.Email;
                usuarioAtualizado.Senha = usuario.Senha;
                usuarioAtualizado.IdTipoUsuario = usuario.IdTipoUsuario;
            }

            ctx.Usuarios.Update(usuarioAtualizado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Usuario pelo id
        /// </summary>
        /// <param name="id">Id do Usuario que será listado</param>
        public Usuario BuscarPorId(int id)
        {
            Usuario usuario = new Usuario
            {
                IdUsuario = ctx.Usuarios.Find(id).IdUsuario,
                Email = ctx.Usuarios.Find(id).Email,
                IdTipoUsuario = ctx.Usuarios.Find(id).IdTipoUsuario
            };

            return usuario;
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="usuario">Usuario que será cadastrado</param>
        public void Cadastrar(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="id">Id do Usuario que será deletado</param>
        public void Deletar(int id)
        {
            Usuario usuario = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios</returns>
        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios
                    .Include(u => u.IdTipoUsuarioNavigation)
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Email = u.Email,
                        IdTipoUsuario = u.IdTipoUsuario,
                        IdTipoUsuarioNavigation = new TiposDeUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                            Titulo = u.IdTipoUsuarioNavigation.Titulo
                        }
                    })
                    .ToList();
        }

        public List<Usuario> Login(string email, string senha)
        {
            List<Usuario> usuario = ctx.Usuarios.Where(u => u.Email == email && u.Senha == senha).ToList();

            if (usuario != null)
            {
                return usuario;
            }

            return null;
        }
    }
}
