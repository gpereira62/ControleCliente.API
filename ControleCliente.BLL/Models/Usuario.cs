using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCliente.BLL.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O login do usuário é obrigatório")]
        [MaxLength(50, ErrorMessage = "Login do usuário está muito grande, máximo 20 caracteres!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória")]
        [MaxLength(50, ErrorMessage = "Senha do usuário está muito grande, máximo 20 caracteres!")]
        public string Senha { get; set; }
    }
}
