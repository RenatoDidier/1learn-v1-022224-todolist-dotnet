CREATE PROCEDURE [PRC_LISTAR_ATIVIDADES] (
	@Titulo NVARCHAR(300)
) AS

BEGIN

	SELECT 
		[Id], [Titulo], [Conclusao] AS [ByteBanco]
	FROM [Atividade]
		WHERE 
		[DataExclusao] IS NULL AND @Titulo = '' OR [Titulo] LIKE '%' + @Titulo + '%'

END