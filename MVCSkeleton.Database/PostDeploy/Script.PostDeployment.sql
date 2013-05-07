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

Insert INTO dbo.Users (Id,Name,Password) 
Values (3,'User','Pwd@123');
Insert INTO dbo.Users (Id,Name,Password) 
Values (4,'TestUser','Pwd@123');

SET IDENTITY_INSERT [dbo].[MenuItems] ON
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (16, NULL, NULL, N'Menu Aggregate 1', NULL);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (17, N'testController1', N'testAction1', N'MenuItem1', 16);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (18, NULL, NULL, N'Menu Aggregate 2', NULL);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (19, N'testController1', N'testAction1', N'MenuItem1', 18);
INSERT INTO [dbo].[MenuItems] ([Id], [Controller], [Action], [Name], [ParentItem_Id]) VALUES (20, N'testController1', N'testAction1', N'MenuItem1', 18);
SET IDENTITY_INSERT [dbo].[MenuItems] OFF

