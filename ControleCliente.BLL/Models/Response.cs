using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCliente.BLL
{
    public class Response
    {
        [JsonProperty("value")]
        public IEnumerable<Cliente> Clientes { get; set; }
    }
}
