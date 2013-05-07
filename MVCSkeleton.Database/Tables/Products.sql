CREATE TABLE [dbo].[Products](
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)