using ControleCliente.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCliente.DAL.HttpClients
{
    public interface IClienteApi
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task Add(Cliente cliente);
        Task Update(int id, Cliente cliente);
        Task Delete(int id);
    }
}
