CREATE PROCEDURE [PRC_CRIAR_ATIVIDADE] (
	@Titulo NVARCHAR(300),
	@Conclusao BIT,
	@DataCriacao DATETIME,
	@Id INT OUTPUT
) AS
BEGIN

	INSERT INTO 
		[Atividade]
		([Titulo], [Conclusao], [DataCriacao])
	VALUES
		(@Titulo, @Conclusao, @DataCriacao)

	SET @Id = SCOPE_IDENTITY();

END
