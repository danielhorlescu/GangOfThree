CREATE TABLE [dbo].[Products](
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[UnitsInStock] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL
)
