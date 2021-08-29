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
            _request.RequestUri = new System.Uri("https://app21-api2.ploomes.com/Contacts");
            _request.Method = HttpMethod.Get;

            HttpResponseMessage responseMessage = await _httpClient.SendAsync(_request);
            Response response = JsonConvert.DeserializeObject<Response>(responseMessage.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(response.Clientes);
        }

        public async Task Add(Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            _request.RequestUri = new System.Uri("https://app21-api2.ploomes.com/Contacts");
            _request.Method = HttpMethod.Post;
            _request.Content = stringContent;

            await _httpClient.SendAsync(_request);
        }

        public async Task Update(int id, Cliente cliente)
        {
            var json = JsonConvert.SerializeObject(cliente);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            _request.RequestUri = new System.Uri(string.Format("https://app21-api2.ploomes.com/Contacts({0})", id));
            _request.Method = HttpMethod.Patch;
            _request.Content = stringContent;

            await _httpClient.SendAsync(_request);
        }

        public async Task Delete(int id)
        {
            _request.RequestUri = new System.Uri(string.Format("https://app21-api2.ploomes.com/Contacts({0})", id));
            _request.Method = HttpMethod.Delete;

            await _httpClient.SendAsync(_request);
        }
    }
}
