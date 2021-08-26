using ControleCliente.BLL;
using ControleCliente.DAL.HttpClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCliente.API.Controllers
{
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
        /// Retorna os produtos cadastrados
        /// </summary>
        /// <returns>Os produtos cadastrados</returns>
        /// <response code="200">Retorna uma lista dos produtos cadastrados</response>
        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok( await _clienteApi.GetAll() );
        }
    }
}
