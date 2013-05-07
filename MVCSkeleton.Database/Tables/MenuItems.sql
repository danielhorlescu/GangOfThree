CREATE TABLE [dbo].[MenuItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[Controller] [nvarchar](100) NULL,
	[Action] [nvarchar](100) NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ParentItem_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.MenuItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
go
ALTER TABLE [dbo].[MenuItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MenuItems_dbo.MenuItems_ParentItem_Id] FOREIGN KEY([ParentItem_Id])
REFERENCES [dbo].[MenuItems] ([Id])
go
ALTER TABLE [dbo].[MenuItems] CHECK CONSTRAINT [FK_dbo.MenuItems_dbo.MenuItems_ParentItem_Id]
go