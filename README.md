/*

Tabelas que foram criadas ppor mim.
Criei a tabekla de centro de distribuição para sanar a primeira parte do problema onde os produtos poderiam ser distribuidos 
por Estado
*/


USE [BancoTeste]
GO

/****** Object:  Table [dbo].[CentroDistribuicao]    Script Date: 16/01/2023 16:02:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CentroDistribuicao](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [nvarchar](60) NULL,
	[UF] [nchar](2) NULL,
	[ENDERECO] [nvarchar](100) NULL,
	[TELEFONE] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






USE [BancoTeste]
GO

/****** Object:  Table [dbo].[Produtos]    Script Date: 16/01/2023 15:58:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produtos](
	[ID_PRODUTO] [varchar](5) NOT NULL,
	[NOME] [nvarchar](60) NULL,
	[QUANTIDADE] [int] NULL,
	[ID_CENTRODISTRIBUICAO] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_PRODUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produtos] ADD  DEFAULT ((0)) FOR [QUANTIDADE]
GO

ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [fk_PRD_CentroDistribuicao] FOREIGN KEY([ID_CENTRODISTRIBUICAO])
REFERENCES [dbo].[CentroDistribuicao] ([ID])
GO

ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [fk_PRD_CentroDistribuicao]
GO


