CREATE TABLE [dbo].[TBVenda]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [NomeCliente] VARCHAR(50) NULL, 
    [Quantidade] INT NULL, 
    [Lucro] DECIMAL(20, 2) NULL, 
	[ProdutoId] INT NOT NULL,
    CONSTRAINT [FK_TBVenda_TBProduto] FOREIGN KEY ([ProdutoId]) REFERENCES [Dbo].[TBProduto] ([Id])
)
