/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


SET IDENTITY_INSERT [dbo].Users ON

Insert INTO dbo.Users (Id,CreationDate, UpdateDate,Name,Password) 
Values (1,'10/10/2010',null,'User','Pwd@123');
Insert INTO dbo.Users (Id,CreationDate, UpdateDate,Name,Password) 
Values (2,'10/10/2010',null,'TestUser','Pwd@123');

SET IDENTITY_INSERT [dbo].Users OFF

SET IDENTITY_INSERT [dbo].[MenuItems] ON

INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (1,'10/10/2010',null, NULL, NULL, N'Products', NULL);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (2,'10/10/2010',null, N'Product', N'GetProducts', N'List Products', 1);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (3,'10/10/2010',null, NULL, NULL, N'Menu Aggregate 2', NULL);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (4,'10/10/2010',null, N'testController1', N'testAction1', N'MenuItem1', 3);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (5,'10/10/2010',null, N'testController1', N'testAction1', N'MenuItem1', 3);

SET IDENTITY_INSERT [dbo].[MenuItems] OFF

INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Gula Malacca', N'GM', 2.33, 3, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Sirop dérable', N'SDE', 3.45, 5, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Gravad lax', N'GL', 5.77, 0, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Konbu', N'KB', 10.27, 13, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Alice Mutton', N'AM', 9.86, 20, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Pâté chinois', N'PC', 21.43, 100, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Tunnbröd', N'TB', 1.13, 7, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Ravioli Angelo', N'RA', 4.89, 11, '2013-05-07 14:51:05', null);


