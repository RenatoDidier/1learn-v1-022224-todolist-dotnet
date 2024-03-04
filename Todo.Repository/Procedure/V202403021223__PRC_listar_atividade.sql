CREATE PROCEDURE [PRC_LISTAR_ATIVIDADES] AS

BEGIN

	SELECT 
		[Id], [Titulo], [Conclusao] AS [ByteBanco], [DataCriacao], [DataUltimaModificacao]
	FROM [Atividade]
		WHERE [DataExclusao] IS NULL

END