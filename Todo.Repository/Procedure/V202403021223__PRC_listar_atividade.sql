CREATE PROCEDURE [PRC_LISTAR_ATIVIDADES] AS

BEGIN

	SELECT 
		[Id], [Titulo], [Conclusao], [DataCriacao], [DataUltimaModificacao]
	FROM [Atividade]
		WHERE [DataExclusao] IS NULL

END