using Microsoft.Extensions.Primitives;
using Todo.Web.Commands;

namespace Todo.Test.Commands
{
    [TestClass]
    public class AtividadeCommandTests
    {
        [TestMethod]
        [TestCategory("Command-Criar")]
        [DataRow("")]
        [DataRow("1234")]
        [DataRow("Lorem ipsum dolor sit amet, consectetur adipiscing elit. In condimentum erat ac ante facilisis facilisis. Nullam sed dolor ac sapien vulputate dapibus. Suspendisse eget ipsum volutpat, ultricies diam vel, iaculis nisi. Suspendisse vestibulum tristique lacus a tincidunt. Ut ut sodales nibh. Donec ut.")]
        public void Dado_uma_propriedade_invalida_no_command_de_criar_deve_gerar_erro(
                string titulo
            )
        {
            var testeCommand = new CriarAtividadeCommand(titulo);

            testeCommand.ValidarEnvioDados();

            Assert.IsFalse(testeCommand.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Criar")]
        [DataRow("Testando atividade")]
        public void Dado_uma_propriedade_valida_no_command_de_criar_deve_prosseguir(
                string titulo
            )
        {
            var testeCommand = new CriarAtividadeCommand(titulo);

            testeCommand.ValidarEnvioDados();

            Assert.IsTrue(testeCommand.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Editar")]
        [DataRow(1, false, "")]
        [DataRow(1, false, "1234")]
        [DataRow(-1, false, "String válida")]
        [DataRow(1, false, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In condimentum erat ac ante facilisis facilisis. Nullam sed dolor ac sapien vulputate dapibus. Suspendisse eget ipsum volutpat, ultricies diam vel, iaculis nisi. Suspendisse vestibulum tristique lacus a tincidunt. Ut ut sodales nibh. Donec ut.")]
        public void Dado_uma_propriedade_invalida_no_command_de_editar_deve_gerar_erro(
            int id,
            bool conclusao,
            string titulo
            )
        {
            var testeCommand = new EditarAtividadeCommand(id, conclusao, titulo);

            testeCommand.ValidarEnvioDados();

            Assert.IsFalse(testeCommand.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Editar")]
        [DataRow(2, false, "Teste válido")]
        public void Dado_uma_propriedade_valida_no_command_de_editar_deve_prosseguir(int id, bool conclusao, string titulo)
        {
            var testeCommand = new EditarAtividadeCommand(id, conclusao, titulo);

            testeCommand.ValidarEnvioDados();

            Assert.IsTrue(testeCommand.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Excluir")]
        [DataRow(-3)]
        public void Dado_uma_propriedade_invalida_no_command_de_excluir_deve_gerar_erro(int id)
        {
            var testeCommand = new ExcluirAtividadeCommand(id);

            testeCommand.ValidarEnvioDados();

            Assert.IsFalse(testeCommand.IsValid);
        }

        [TestMethod]
        [TestCategory("Command-Excluir")]
        [DataRow(2)]
        public void Dado_uma_propriedade_valida_no_command_de_excluir_deve_prosseguir(int id)
        {
            var testeCommand = new ExcluirAtividadeCommand(id);

            testeCommand.ValidarEnvioDados();

            Assert.IsTrue(testeCommand.IsValid);
        }

    }
}
