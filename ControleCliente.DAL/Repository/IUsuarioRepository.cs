using ControleCliente.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCliente.DAL.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetToken(Usuario usuario);
        Task<ActionResult<IEnumerable<Usuario>>> GetAll();
        Task Update(Usuario usuario);
        Task Add(Usuario usuario);
        bool UsuarioExists(int id);
    }
}
