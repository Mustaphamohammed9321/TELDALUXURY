
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/10/2021 08:52:39
-- Generated from EDMX file: C:\Users\mgmohammed\source\repos\THELDALUXURY\WEBAPI\Models\teldaluxuryMODEL.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [theldaluxury];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tb_AddNewItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_AddNewItem];
GO
IF OBJECT_ID(N'[dbo].[tb_AdminRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_AdminRole];
GO
IF OBJECT_ID(N'[dbo].[tb_AdminUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_AdminUser];
GO
IF OBJECT_ID(N'[dbo].[tb_Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_Country];
GO
IF OBJECT_ID(N'[dbo].[tb_ErrorLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_ErrorLog];
GO
IF OBJECT_ID(N'[dbo].[tb_Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_Item];
GO
IF OBJECT_ID(N'[dbo].[tb_ItemCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_ItemCategory];
GO
IF OBJECT_ID(N'[dbo].[tb_ItemStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_ItemStatus];
GO
IF OBJECT_ID(N'[dbo].[tb_LGA]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_LGA];
GO
IF OBJECT_ID(N'[dbo].[tb_Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_Sales];
GO
IF OBJECT_ID(N'[dbo].[tb_State]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_State];
GO
IF OBJECT_ID(N'[dbo].[tb_Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_Users];
GO
IF OBJECT_ID(N'[theldaluxuryModelStoreContainer].[ViewCountries]', 'U') IS NOT NULL
    DROP TABLE [theldaluxuryModelStoreContainer].[ViewCountries];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tb_AddNewItem'
CREATE TABLE [dbo].[tb_AddNewItem] (
    [ItemId] int IDENTITY(1,1) NOT NULL,
    [ItemName] varchar(max)  NULL,
    [ItemDescription] varchar(max)  NULL,
    [CategoryId] int  NULL,
    [ItemPrice] decimal(18,0)  NULL,
    [ItemStatusId] int  NULL,
    [DateAdded] datetime  NULL,
    [Photo] varchar(max)  NULL
);
GO

-- Creating table 'tb_AdminRole'
CREATE TABLE [dbo].[tb_AdminRole] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [Role] varchar(50)  NULL,
    [AdminId] int  NULL
);
GO

-- Creating table 'tb_AdminUser'
CREATE TABLE [dbo].[tb_AdminUser] (
    [AdminId] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [OtherName] varchar(50)  NULL,
    [EmailAddress] varchar(max)  NULL,
    [PhoneNumber] varchar(50)  NULL,
    [UserName] varchar(50)  NULL,
    [Password] varchar(max)  NULL,
    [Photo] varchar(max)  NULL,
    [RoleId] int  NULL,
    [ResidentialAddress] varchar(max)  NULL
);
GO

-- Creating table 'tb_Country'
CREATE TABLE [dbo].[tb_Country] (
    [countryId] int IDENTITY(1,1) NOT NULL,
    [Country] varchar(max)  NULL,
    [Capital] varchar(max)  NULL
);
GO

-- Creating table 'tb_ErrorLog'
CREATE TABLE [dbo].[tb_ErrorLog] (
    [logId] int IDENTITY(1,1) NOT NULL,
    [Error] varchar(max)  NULL,
    [ErrorMessage] varchar(max)  NULL,
    [DateandTime] datetime  NULL
);
GO

-- Creating table 'tb_Item'
CREATE TABLE [dbo].[tb_Item] (
    [ItemId] int IDENTITY(1,1) NOT NULL,
    [ItemName] varchar(max)  NULL,
    [ItemDescription] varchar(max)  NULL,
    [CategoryId] int  NULL,
    [ItemPrice] decimal(18,0)  NULL,
    [ItemStatusId] int  NULL,
    [DateAdded] datetime  NULL,
    [Photo] varchar(max)  NULL
);
GO

-- Creating table 'tb_ItemCategory'
CREATE TABLE [dbo].[tb_ItemCategory] (
    [CategoryId] int IDENTITY(1,1) NOT NULL,
    [Category] varchar(max)  NULL,
    [ItemId] int  NULL
);
GO

-- Creating table 'tb_ItemStatus'
CREATE TABLE [dbo].[tb_ItemStatus] (
    [ItemId] int IDENTITY(1,1) NOT NULL,
    [Item] varchar(max)  NULL,
    [ItemStatus] int  NULL
);
GO

-- Creating table 'tb_LGA'
CREATE TABLE [dbo].[tb_LGA] (
    [lgaID] int IDENTITY(1,1) NOT NULL,
    [lgaName] varchar(50)  NULL,
    [StateID] varchar(50)  NULL
);
GO

-- Creating table 'tb_Sales'
CREATE TABLE [dbo].[tb_Sales] (
    [SalesId] int IDENTITY(1,1) NOT NULL,
    [Item] varchar(max)  NULL,
    [ItemId] int  NULL,
    [StatusId] int  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'tb_State'
CREATE TABLE [dbo].[tb_State] (
    [StateId] int IDENTITY(1,1) NOT NULL,
    [StateName] varchar(50)  NULL,
    [CountryId] varchar(max)  NULL
);
GO

-- Creating table 'tb_Users'
CREATE TABLE [dbo].[tb_Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [OtherName] varchar(50)  NULL,
    [StatusId] int  NOT NULL,
    [Country] varchar(50)  NULL,
    [State] varchar(50)  NULL,
    [LGA] varchar(50)  NULL,
    [EmailAddress] varchar(max)  NULL,
    [PhoneNumber] varchar(50)  NULL,
    [UserName] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [DateAdded] datetime  NULL,
    [Photo] varchar(max)  NULL,
    [ResidentialAddress] varchar(max)  NULL
);
GO

-- Creating table 'ViewCountries'
CREATE TABLE [dbo].[ViewCountries] (
    [countryId] int IDENTITY(1,1) NOT NULL,
    [Country] varchar(max)  NULL,
    [Capital] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ItemId] in table 'tb_AddNewItem'
ALTER TABLE [dbo].[tb_AddNewItem]
ADD CONSTRAINT [PK_tb_AddNewItem]
    PRIMARY KEY CLUSTERED ([ItemId] ASC);
GO

-- Creating primary key on [RoleId] in table 'tb_AdminRole'
ALTER TABLE [dbo].[tb_AdminRole]
ADD CONSTRAINT [PK_tb_AdminRole]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [AdminId] in table 'tb_AdminUser'
ALTER TABLE [dbo].[tb_AdminUser]
ADD CONSTRAINT [PK_tb_AdminUser]
    PRIMARY KEY CLUSTERED ([AdminId] ASC);
GO

-- Creating primary key on [countryId] in table 'tb_Country'
ALTER TABLE [dbo].[tb_Country]
ADD CONSTRAINT [PK_tb_Country]
    PRIMARY KEY CLUSTERED ([countryId] ASC);
GO

-- Creating primary key on [logId] in table 'tb_ErrorLog'
ALTER TABLE [dbo].[tb_ErrorLog]
ADD CONSTRAINT [PK_tb_ErrorLog]
    PRIMARY KEY CLUSTERED ([logId] ASC);
GO

-- Creating primary key on [ItemId] in table 'tb_Item'
ALTER TABLE [dbo].[tb_Item]
ADD CONSTRAINT [PK_tb_Item]
    PRIMARY KEY CLUSTERED ([ItemId] ASC);
GO

-- Creating primary key on [CategoryId] in table 'tb_ItemCategory'
ALTER TABLE [dbo].[tb_ItemCategory]
ADD CONSTRAINT [PK_tb_ItemCategory]
    PRIMARY KEY CLUSTERED ([CategoryId] ASC);
GO

-- Creating primary key on [ItemId] in table 'tb_ItemStatus'
ALTER TABLE [dbo].[tb_ItemStatus]
ADD CONSTRAINT [PK_tb_ItemStatus]
    PRIMARY KEY CLUSTERED ([ItemId] ASC);
GO

-- Creating primary key on [lgaID] in table 'tb_LGA'
ALTER TABLE [dbo].[tb_LGA]
ADD CONSTRAINT [PK_tb_LGA]
    PRIMARY KEY CLUSTERED ([lgaID] ASC);
GO

-- Creating primary key on [SalesId] in table 'tb_Sales'
ALTER TABLE [dbo].[tb_Sales]
ADD CONSTRAINT [PK_tb_Sales]
    PRIMARY KEY CLUSTERED ([SalesId] ASC);
GO

-- Creating primary key on [StateId] in table 'tb_State'
ALTER TABLE [dbo].[tb_State]
ADD CONSTRAINT [PK_tb_State]
    PRIMARY KEY CLUSTERED ([StateId] ASC);
GO

-- Creating primary key on [Id] in table 'tb_Users'
ALTER TABLE [dbo].[tb_Users]
ADD CONSTRAINT [PK_tb_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [countryId] in table 'ViewCountries'
ALTER TABLE [dbo].[ViewCountries]
ADD CONSTRAINT [PK_ViewCountries]
    PRIMARY KEY CLUSTERED ([countryId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------