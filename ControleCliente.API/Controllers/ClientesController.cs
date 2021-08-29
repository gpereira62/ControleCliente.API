using ControleCliente.BLL;
using ControleCliente.DAL.HttpClients;
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
    [Route("api/v1/clientes/")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteApi _clienteApi;

        public ClientesController(IClienteApi clienteApi)
        {
            _clienteApi = clienteApi;
        }

        // GET: api/v1/clientes/
        /// <summary>
        /// Retorna os clientes cadastrados
        /// </summary>
        /// <returns>Os clientes cadastrados</returns>
        /// <response code="200">Retorna uma lista dos clientes cadastrados</response>
        /// <response code="401">Sem autorização para utilizar está requisição</response>
        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok( await _clienteApi.GetAll() );
        }

        // POST: api/v1/clientes/
        /// <summary>
        /// Cria um novo cliente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     api/v1/clientes/
        ///     {
        ///        "Id": 0,
        ///        "name": "Gustavo Pereira 2",
        ///        "email": "gustavopereirasantos2@hotmail.com",
        ///     }
        ///
        /// </remarks>
        /// <returns>Um novo cliente criado</returns>
        /// <response code="201">Retorna o cliente indicando que ele foi criado com sucesso</response>
        /// <response code="401">Sem autorização para utilizar está requisição</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            await _clienteApi.Add(cliente);
            return CreatedAtAction("GetClientes", cliente);
        }

        // PUT: api/v1/clientes/1
        /// <summary>
        /// Edita o cliente pelo id informado
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     api/v1/clientes/1
        ///     {
        ///        "Id": 0,
        ///        "name": "Gustavo Pereira 2",
        ///        "email": "gustavopereirasantos2@hotmail.com",
        ///     }
        ///
        /// </remarks>
        /// <returns>O cliente cadastrado pelo id informado</returns>
        /// <response code="200">Retorna o cliente editado indicando que foi alterado com sucesso</response>
        /// <response code="401">Sem autorização para utilizar está requisição</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> PatchCliente(int id, Cliente cliente)
        {
            await _clienteApi.Update(id, cliente);
            return Ok(cliente);
        }

        // DELETE: api/v1/clientes/1
        /// <summary>
        /// Deleta o cliente pelo id informado
        /// </summary>
        /// <returns>Não é retornado nenhuma informação, indicando que a exclusão foi feita com sucesso</returns>
        /// <response code="200">Retorna vazio indicando que a exclusão foi feita com sucesso</response>
        /// <response code="401">Sem autorização para utilizar está requisição</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [Authorize]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteApi.Delete(id);
            return Ok();
        }
    }
}
