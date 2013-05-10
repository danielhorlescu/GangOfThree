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

Insert INTO dbo.Users (Id,CreationDate, UpdateDate,Name,Password) 
Values ('121457B8-C532-4D1B-98EF-9ADE39819145','10/10/2010','10/10/2010','User','Pwd@123');
Insert INTO dbo.Users (Id,CreationDate, UpdateDate,Name,Password) 
Values ('E041F344-A098-4578-BBB0-13B4BCC1658F','10/10/2010','10/10/2010','TestUser','Pwd@123');

INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('1051A360-2E1F-409B-B04A-0F623B89233C', '0B4FDF16-0B02-4806-AD66-CB75B0B5716B', N'Gula Malacca', N'GM', 2.33, 3, '2013-05-07 14:51:05', '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('0BACC451-C240-4ED9-BE77-2CC87182FF70', '0B4FDF16-0B02-4806-AD66-CB75B0B5716B', N'Sirop dérable', N'SDE', 3.45, 5, '2013-05-07 14:51:05', '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('D5E8FDEF-B022-4E10-A293-EA128AC30602', 'E457645C-BC7B-4EEF-AC46-863B24C3BACE', N'Gravad lax', N'GL', 5.77, 0, '2013-05-07 14:51:05', '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('14C4B179-CCAD-47EE-AC53-AFA93BE59A12', 'E457645C-BC7B-4EEF-AC46-863B24C3BACE', N'Konbu', N'KB', 10.27, 13, '2013-05-07 14:51:05', '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('7AFA6D71-7B53-4971-8165-D1EB00DC4774', 'C54C4209-CF50-4603-9FDB-5620EF330E38', N'Alice Mutton', N'AM', 9.86, 20, '2013-05-07 14:51:05', '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('F2A92077-91DC-4806-86FC-1F91D5BA4C19', 'C54C4209-CF50-4603-9FDB-5620EF330E38', N'Pâté chinois', N'PC', 21.43, 100, '2013-05-07 14:51:05', '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('A1D377FA-436A-4D89-870C-9124B7110019', '4B985BA0-126E-4478-8C0F-0CDE556D44F2', N'Tunnbröd', N'TB', 1.13, 7, '2013-05-07 14:51:05', '2013-05-07 14:51:05');
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Name], [Code], [UnitPrice], [UnitsInStock], [CreationDate], [UpdateDate]) VALUES ('C56D250F-BA41-4BA4-8D9B-0A46212550CB', '4B985BA0-126E-4478-8C0F-0CDE556D44F2', N'Ravioli Angelo', N'RA', 4.89, 11, '2013-05-07 14:51:05', '2013-05-07 14:51:05');

INSERT INTO [dbo].[Stores] ([Id], [Name], [Email], [CreationDate], [UpdateDate]) VALUES ('9351BA4E-5AEF-436F-95CE-A61557EC1669', 'firstStore','first@first.com','01-01-2001','01-01-2001')


