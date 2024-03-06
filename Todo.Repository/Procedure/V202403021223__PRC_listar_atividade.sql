CREATE PROCEDURE [PRC_LISTAR_ATIVIDADES] (
	@Titulo NVARCHAR(300),
	@Conclusao BIT = NULL
) AS

BEGIN

	SELECT 
		[Id], [Titulo], [Conclusao] AS [ByteBanco]
	FROM [Atividade]
		WHERE 
		[DataExclusao] IS NULL AND 
		(@Titulo = '' OR [Titulo] LIKE '%' + @Titulo + '%') AND
		((@Conclusao IS NULL) OR ([Conclusao] = @Conclusao))

END