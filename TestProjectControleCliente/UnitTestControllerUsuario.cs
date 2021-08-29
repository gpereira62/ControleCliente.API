using ControleCliente.API.Controllers;
using ControleCliente.BLL.Models;
using ControleCliente.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectControleCliente
{
    public class UnitTestControllerUsuario
    {
        private IUsuarioRepository usuarioRepository;
        private UsuariosController usuariosController;

        public UnitTestControllerUsuario()
        {
            usuarioRepository = Substitute.For<IUsuarioRepository>();
            usuariosController = new UsuariosController(usuarioRepository);
        }

        #region Post

        [Fact(DisplayName = "Cadastrar um usuário com sucesso")]
        public async void TestUsuarioControllerPostUsuario()
        {
            // Arrange
            var usuario = new Usuario { UsuarioId = 1, Login = "gustavo", Senha = "1234" };

            // Act
            var resultado = await usuariosController.PostUsuario(usuario);

            // Assert
            Assert.IsType<CreatedAtActionResult>(resultado.Result);
        }

        #endregion

        #region GetUsuarios

        [Fact(DisplayName = "Consultar usuários com sucesso")]
        public void TestUsuarioControllerGetUsuarios()
        {
            // Arrange
            List<Usuario> listUsuarios = new List<Usuario>();
            listUsuarios.Add(new Usuario { UsuarioId = 1, Login = "gustavo1", Senha = "1234" });
            listUsuarios.Add(new Usuario { UsuarioId = 2, Login = "gustavo2", Senha = "1234" });
            listUsuarios.Add(new Usuario { UsuarioId = 3, Login = "gustavo3", Senha = "1234" });
            ActionResult<IEnumerable<Usuario>> Usuarios = listUsuarios;
            usuarioRepository.GetAll().Returns(Task.FromResult(Usuarios));

            // Act
            var resultado = usuariosController.GetUsuarios();

            // Assert
            Assert.Equal(Usuarios.Value.Where(u => u.UsuarioId == 1 && u.Login.Equals("gustavo1") && u.Senha.Equals("1234")),
                resultado.Result.Value.Where(r => r.UsuarioId == 1 && r.Login.Equals("gustavo1") && r.Senha.Equals("1234")));

            Assert.Equal(Usuarios.Value.Where(u => u.UsuarioId == 2 && u.Login.Equals("gustavo2") && u.Senha.Equals("1234")),
                resultado.Result.Value.Where(r => r.UsuarioId == 2 && r.Login.Equals("gustavo2") && r.Senha.Equals("1234")));

            Assert.Equal(Usuarios.Value.Where(u => u.UsuarioId == 3 && u.Login.Equals("gustavo3") && u.Senha.Equals("1234")),
                resultado.Result.Value.Where(r => r.UsuarioId == 3 && r.Login.Equals("gustavo3") && r.Senha.Equals("1234")));

            Assert.Equal(Usuarios.Value.Count(), resultado.Result.Value.Count());
            Assert.IsType<ActionResult<IEnumerable<Usuario>>>(resultado.Result);
        }

        #endregion

        #region Put

        [Fact(DisplayName = "Alterar um usuário com sucesso")]
        public async void TestUsuarioControllerPutUsuario()
        {
            // Arrange
            usuarioRepository.UsuarioExists(1).Returns(true);
            var usuario = new Usuario { UsuarioId = 1, Login = "gustavo", Senha = "1234" };
            int id = 1;

            // Act
            var resultado = await usuariosController.PutUsuario(id, usuario);

            // Assert
            Assert.IsType<NoContentResult>(resultado);
        }

        [Fact(DisplayName = "Alterar um usuário com id diferente do id do request body")]
        public async void TestUsuarioControllerPutUsuarioIdDeferenteRequestBody()
        {
            // Arrange
            var usuario = new Usuario { UsuarioId = 1, Login = "gustavo", Senha = "1234" };
            int id = 2;

            // Act
            var resultado = await usuariosController.PutUsuario(id, usuario);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact(DisplayName = "Alterar um usuário inexistente")]
        public async void TestUsuarioControllerPutUsuarioInexistente()
        {
            // Arrange
            usuarioRepository.UsuarioExists(1).Returns(false);
            var usuario = new Usuario { UsuarioId = 1, Login = "gustavo", Senha = "1234" };
            int id = 1;

            // Act
            var resultado = await usuariosController.PutUsuario(id, usuario);

            // Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        #endregion
    }
}
