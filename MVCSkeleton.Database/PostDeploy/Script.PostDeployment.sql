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

delete users;
delete Products;

Insert INTO dbo.Users (CreationDate, UpdateDate,Name,Password) 
Values ('10/10/2010',null,'User','Pwd@123');
Insert INTO dbo.Users (CreationDate, UpdateDate,Name,Password) 
Values ('10/10/2010',null,'TestUser','Pwd@123');

INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (1, N'Gula Malacca', N'GM', 2.33, 3, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (1, N'Sirop dérable', N'SDE', 3.45, 5, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (2, N'Gravad lax', N'GL', 5.77, 0, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (2, N'Konbu', N'KB', 10.27, 13, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (3, N'Alice Mutton', N'AM', 9.86, 20, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (3, N'Pâté chinois', N'PC', 21.43, 100, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (4, N'Tunnbröd', N'TB', 1.13, 7, '2013-05-07 14:51:05', null);
INSERT INTO [dbo].[Products] ([CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES (4, N'Ravioli Angelo', N'RA', 4.89, 11, '2013-05-07 14:51:05', null);


