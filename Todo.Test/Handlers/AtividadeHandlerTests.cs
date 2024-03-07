using Todo.Shared.Repositories;
using Todo.Test.Repositories;
using Todo.Web.Commands;
using Todo.Web.Handlers;
using Todo.Web.Handlers.Interfaces;

namespace Todo.Test.Handlers
{


    [TestClass]
    public class AtividadeHandlerTests
    {
        private readonly ITodoRepository _repository;
        private readonly AtividadeHandler _handler;
        public AtividadeHandlerTests()
        {
            _repository = new FakeAtividadeRepository();
            _handler = new AtividadeHandler(_repository);
        }

        [TestMethod]
        [TestCategory("Handler-Criar")]
        public void Dado_uma_propriedade_Valida_para_criar_atividade_deve_proseeguir()
        {
            var commandTeste = new CriarAtividadeCommand("Criação atividade");

            var resposta = _handler.Handle(commandTeste);

            Assert.AreEqual(resposta.Result.Status, 201);
        }

        [TestMethod]
        [TestCategory("Handler-Editar")]
        public void Dado_uma_atividade_inexistente_no_banco_deve_gerar_erro_no_editar()
        {
            var commandTeste = new EditarAtividadeCommand(0, false, "Tarefa inexistente");

            var resposta = _handler.Handle(commandTeste);

            Assert.AreEqual(resposta.Result.Status, 400);
        }

        [TestMethod]
        [TestCategory("Handler-Editar")]
        public void Dado_uma_atividade_existente_no_banco_deve_prosseguir_no_editar()
        {
            var commandTeste = new EditarAtividadeCommand(1, false, "Tarefa inexistente");

            var resposta = _handler.Handle(commandTeste);

            Assert.AreEqual(resposta.Result.Status, 201);
        }

        [TestMethod]
        [TestCategory("Handler-Excluir")]
        public void Dado_uma_atividade_inexistente_no_banco_deve_gerar_erro_no_excluir()
        {
            var commandTeste = new ExcluirAtividadeCommand(0);

            var resposta = _handler.Handle(commandTeste);

            Assert.AreEqual(resposta.Result.Status, 400);
        }

        [TestMethod]
        [TestCategory("Handler-Excluir")]
        public void Dado_uma_atividade_existente_no_banco_deve_prosseguir_no_excluir()
        {
            var commandTeste = new ExcluirAtividadeCommand(1);

            var resposta = _handler.Handle(commandTeste);

            Assert.AreEqual(resposta.Result.Status, 201);
        }

        [TestMethod]
        [TestCategory("Handler-Listar")]
        public void Dado_uma_consulta_sem_atividades_ao_banco_deve_retornar_uma_lista_vazia()
        {
            var commandTeste = new ListarAtividadeCommand();
            commandTeste.Titulo = "atividade inexistente";

            var resposta = _handler.Handle(commandTeste);

            Assert.AreEqual(resposta.Result.ListaDados.Count, 0);
        }

        [TestMethod]
        [TestCategory("Handler-Listar")]
        public void Dado_uma_consulta_com_atividades_existentes_ao_banco_deve_retornar_uma_lista()
        {
            var commandTeste = new ListarAtividadeCommand();
            commandTeste.Titulo = "Atividades Existentes";

            var resposta = _handler.Handle(commandTeste);

            Assert.IsTrue(resposta.Result.ListaDados.Count > 0);
        }
    }
}
