CREATE TABLE [dbo].[TBProduto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(50) NULL, 
    [PrecoVenda] DECIMAL(20, 2) NULL, 
    [PrecoCusto] DECIMAL(20, 2) NULL, 
    [Estoque] INT NULL, 
    [DataFabricacao] DATE NULL, 
    [DataValidade] DATE NULL
)
