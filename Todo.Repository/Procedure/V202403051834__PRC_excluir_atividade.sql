CREATE PROCEDURE [PRC_EXCLUIR_ATIVIDADE] (
		@Id INT,
		@DataExclusao DateTime
	) AS
BEGIN
	UPDATE
		[Atividade]
	SET
		[DataExclusao] = @DataExclusao
	WHERE 
		[Id] = @Id
END