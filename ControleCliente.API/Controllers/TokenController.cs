using ControleCliente.API.Services;
using ControleCliente.BLL.Models;
using ControleCliente.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCliente.API.Controllers
{
    [Route("api/v1/conta")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public TokenController(IUsuarioRepository usuarioRepository)
		{
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario usuario)
        {
            Usuario usuarioEncontrado = _usuarioRepository.GetToken(usuario).Result;

            if (usuarioEncontrado == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuarioEncontrado);

            // Oculta a senha do return
            usuarioEncontrado.Senha = "";

            return new
            {
                user = usuarioEncontrado,
                token = token
            };
        }
    }
}
