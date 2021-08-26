using ControleCliente.BLL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ControleCliente.DAL.HttpClients
{
    public class ClienteApi : IClienteApi
    {

        private HttpClient _httpClient { get; set; }
        private HttpRequestMessage _request { get; set; }

        public ClienteApi()
        {
            _httpClient = new HttpClient();
            _request = new HttpRequestMessage();
            _request.Headers.Add("User-Key", "C8810EE14E94D0F7FAF2969316CAC535DD9CA3D3A44104E1C934DA2BC315FD9B99DA588D44FD9FB9299E8FEF42BB73F14ACCC3E6542C5DEDC8397DE1C42A4B55");
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            _request.RequestUri = new System.Uri("https://public-api2.ploomes.com/Users");
            _request.Method = HttpMethod.Get;
            HttpResponseMessage response = await _httpClient.SendAsync(_request);
            Response responseResult = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(responseResult.Clientes);
        }

        public async Task Add(Cliente cliente)
        {
            _request.RequestUri = new System.Uri("https://public-api2.ploomes.com/Users");
            _request.Method = HttpMethod.Post;
            HttpResponseMessage response = await _httpClient.SendAsync(_request);
        }

        public Task Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
