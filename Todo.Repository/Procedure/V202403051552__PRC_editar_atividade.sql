CREATE PROCEDURE [PRC_EDITAR_ATIVIDADE] (
	@Id INT,
	@Titulo VARCHAR(300),
	@Conclusao BIT,
	@DataUltimaModificacao DateTime
) AS
BEGIN

	UPDATE [Atividade]
		SET Titulo = @Titulo, Conclusao = @Conclusao, DataUltimaModificacao = @DataUltimaModificacao
		WHERE Id = @Id

END