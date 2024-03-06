USE [TodoList]

CREATE TABLE [Atividade] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Titulo] NVARCHAR(300) NOT NULL,
	[Conclusao] BINARY,
	[DataCriacao] DATETIME NOT NULL,
	[DataUltimaModificacao] DATETIME,
	[DataExclusao] DATETIME
);