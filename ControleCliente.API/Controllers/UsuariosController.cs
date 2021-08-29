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
    [Produces("application/json")]
    [Route("api/v1/usuarios/")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/v1/usuarios/
        /// <summary>
        /// Retorna os usuários cadastrados
        /// </summary>
        /// <returns>Os usuários cadastrados</returns>
        /// <response code="200">Retorna uma lista dos usuários cadastrados</response>
        /// <response code="401">Sem autorização para utilizar está requisição</response>
        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _usuarioRepository.GetAll();
        }

        // PUT: api/v1/usuarios/1
        /// <summary>
        /// Edita o usuário pelo id informado
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     api/v1/usuarios/1
        ///     {
        ///        "usuarioid": 1,
        ///        "login": "gustavo1",
        ///        "senha": "1234",
        ///     }
        ///
        /// </remarks>
        /// <returns>O usuário cadastrado pelo id informado</returns>
        /// <response code="204">Retorna vazio indicando que o usuário foi alterado com sucesso</response>
        /// <response code="401">Sem autorização para utilizar está requisição</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
                return BadRequest(new { message = "Id filtrado é diferente do Id do request body." });

            if (!_usuarioRepository.UsuarioExists(id))
                return NotFound(new { message = "Usuário não encontrado." });

            usuario.Login = usuario.Login.Trim();
            usuario.Senha = usuario.Senha.Trim();

            await _usuarioRepository.Update(usuario);

            return NoContent();
        }

        // POST: api/v1/usuarios/
        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     api/v1/usuarios/
        ///     {
        ///        "usuarioid": 1,
        ///        "login": "gustavo",
        ///        "senha": "123",
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo usuário criado</returns>
        /// <response code="201">Retorna o usuário indicando que ele foi criado com sucesso</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            usuario.Login = usuario.Login.Trim();
            usuario.Senha = usuario.Senha.Trim();

            await _usuarioRepository.Add(usuario);

            return CreatedAtAction("GetUsuarios", new { id = usuario.UsuarioId }, usuario);
        }
    }
}
