using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_Hroads_WebAPI.Domains;
using Senai_Hroads_WebAPI.Interfaces;
using Senai_Hroads_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_Hroads_WebAPI.Controllers
{
    // Define que a resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requesição será no formato: dominio/api/nomedocontroller
    [Route("api/[controller]")]

    // Define que é um Controller de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            List<Usuario> usuarioLogin = _UsuarioRepository.Login(usuario.Email, usuario.Senha);

            //Usuario novoUsuario = usuarioLogin.First();

            if (usuarioLogin.Count() == 0)
            {
                return NotFound("E-mail ou Senha inválidos!");
            }

            // Caso encontre um usuário com o email e senha informados:
            
            // Payload -> Define os dados que serão definidos no Token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogin[0].IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogin[0].Email),
                new Claim(ClaimTypes.Role, usuarioLogin[0].IdTipoUsuario.ToString())
            };

            // Define a chave de acesso do Token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-de-acesso"));

            // Header -> Define as credenciais do Token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Define a composição do Token
            var token = new JwtSecurityToken(
                issuer: "HROADS",
                audience: "HROADS",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            // Retorna um status code Ok(200) com o token criado
            return Ok(new
            {
                // Gera o token com base nas informações definidas anteriormente e retorna junto com o status code
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
