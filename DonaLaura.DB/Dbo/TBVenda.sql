CREATE TABLE [dbo].[TBVenda]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NomeProduto] VARCHAR(50) NULL, 
    [NomeCliente] VARCHAR(50) NULL, 
    [Quantidade] INT NULL, 
    [Lucro] DECIMAL(20, 2) NULL
)
