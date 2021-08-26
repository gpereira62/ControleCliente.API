using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCliente.BLL
{
    public class Cliente
    {
        [JsonProperty("Id")]
        public int ClienteId { get; set; }

        [JsonProperty("Name")]
        public string Nome { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Phone")]
        public string Telefone { get; set; }
    }
}
