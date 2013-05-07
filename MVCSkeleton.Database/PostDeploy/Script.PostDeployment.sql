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
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (1,'10/10/2010',null, NULL, NULL, N'Menu Aggregate 1', NULL);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (2,'10/10/2010',null, N'testController1', N'testAction1', N'MenuItem1', 1);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (3,'10/10/2010',null, NULL, NULL, N'Menu Aggregate 2', NULL);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (4,'10/10/2010',null, N'testController1', N'testAction1', N'MenuItem1', 3);
INSERT INTO [dbo].[MenuItems] ([Id],CreationDate, UpdateDate, [Controller], [Action], [Name], [ParentItem_Id]) VALUES (5,'10/10/2010',null, N'testController1', N'testAction1', N'MenuItem1', 3);

SET IDENTITY_INSERT [dbo].[MenuItems] OFF


