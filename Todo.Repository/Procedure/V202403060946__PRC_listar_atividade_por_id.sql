CREATE PROCEDURE [PRC_LISTAR_ATIVIDADE_POR_ID]
	(
		@Id INT
	) AS

BEGIN
	
	SELECT 
		[Id], [Titulo], [Conclusao] AS [ByteBanco]
	FROM
		[Atividade]
	WHERE
		[DataExclusao] IS NULL AND [Id] = @Id

END