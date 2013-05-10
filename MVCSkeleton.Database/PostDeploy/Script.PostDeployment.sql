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


--SET IDENTITY_INSERT [dbo].Users ON

Insert INTO dbo.Users (Id,CreationDate, UpdateDate,Name,Password) 
Values ('121457B8-C532-4D1B-98EF-9ADE39819145','10/10/2010',null,'User','Pwd@123');
Insert INTO dbo.Users (Id,CreationDate, UpdateDate,Name,Password) 
Values ('E041F344-A098-4578-BBB0-13B4BCC1658F','10/10/2010',null,'TestUser','Pwd@123');

--SET IDENTITY_INSERT [dbo].Users OFF

--SET IDENTITY_INSERT [dbo].[MenuItems] ON

INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES ('E29BE52A-BA01-4932-8BF4-6D8C181A2FF3','10/10/2010',null, NULL, NULL, N'Products', NULL);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES ('150BDCD3-8A61-467A-B90D-DE8714D6ADCD','10/10/2010',null, N'Product', N'GetProducts', N'List Products', '150BDCD3-8A61-467A-B90D-DE8714D6ADCD');
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES ('AAC449E0-57A0-434B-B724-8CA69A6B46C6','10/10/2010',null, NULL, NULL, N'Menu Aggregate 2', NULL);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES ('12AC41DC-942E-4B3A-9F93-84CE6FF87CCC','10/10/2010',null, N'testController1', N'testAction1', N'MenuItem1', 'AAC449E0-57A0-434B-B724-8CA69A6B46C6');
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES ('76EFC264-C88D-4C8E-A444-6E944D76D0BF','10/10/2010',null, N'testController1', N'testAction1', N'MenuItem1', 'AAC449E0-57A0-434B-B724-8CA69A6B46C6');

--SET IDENTITY_INSERT [dbo].[MenuItems] OFF

INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Gula Malacca', N'GM', 2.33, 3, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Sirop dérable', N'SDE', 3.45, 5, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Gravad lax', N'GL', 5.77, 0, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Konbu', N'KB', 10.27, 13, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Alice Mutton', N'AM', 9.86, 20, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Pâté chinois', N'PC', 21.43, 100, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Tunnbröd', N'TB', 1.13, 7, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (N'Ravioli Angelo', N'RA', 4.89, 11, '2013-05-07 14:51:05', null);

INSERT INTO [dbo].[Stores] ([Id], [Name], [Email], [CreationDate], [UpdateDate]) VALUES ('9351BA4E-5AEF-436F-95CE-A61557EC1669', 'firstStore','first@first.com','01-01-2001','01-01-2001')


