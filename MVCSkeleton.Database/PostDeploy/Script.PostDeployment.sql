﻿/*
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
Insert INTO dbo.Users (Id,Name,Password) 
Values (3,'User','Pwd@123');
Insert INTO dbo.Users (Id,Name,Password) 
Values (4,'TestUser','Pwd@123');

SET IDENTITY_INSERT [dbo].[MenuItems] ON
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (1, NULL, NULL, N'Products', NULL);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (2, N'Product', N'GetProducts', N'List Products', 1);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (18, NULL, NULL, N'Menu Aggregate 2', NULL);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (19, N'testController1', N'testAction1', N'MenuItem1', 18);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (20, N'testController1', N'testAction1', N'MenuItem1', 18);
SET IDENTITY_INSERT [dbo].[MenuItems] OFF

INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Gula Malacca', N'GM', 2.33, 3, '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Sirop dérable', N'SDE', 3.45, 5, '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Gravad lax', N'GL', 5.77, 0, '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Konbu', N'KB', 10.27, 13, '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Alice Mutton', N'AM', 9.86, 20, '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Pâté chinois', N'PC', 21.43, 100, '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Tunnbröd', N'TB', 1.13, 7, '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate]) VALUES (N'Ravioli Angelo', N'RA', 4.89, 11, '2013-05-07 14:51:05');

