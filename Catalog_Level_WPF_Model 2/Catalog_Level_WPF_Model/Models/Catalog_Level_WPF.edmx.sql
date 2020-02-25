
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/22/2020 20:31:03
-- Generated from EDMX file: E:\Черновики для портфолио\Catalog_Level_WPF_Model 2\Catalog_Level_WPF_Model\Models\Catalog_Level_WPF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TZ];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Aggregates_dbo_Catalogs_CatalogID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Aggregates] DROP CONSTRAINT [FK_dbo_Aggregates_dbo_Catalogs_CatalogID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Models_dbo_Aggregates_AggregateID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Models] DROP CONSTRAINT [FK_dbo_Models_dbo_Aggregates_AggregateID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Aggregates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aggregates];
GO
IF OBJECT_ID(N'[dbo].[Catalog_level]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Catalog_level];
GO
IF OBJECT_ID(N'[dbo].[Catalogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Catalogs];
GO
IF OBJECT_ID(N'[dbo].[Models]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Models];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aggregates'
CREATE TABLE [dbo].[Aggregates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [CatalogID] int  NOT NULL
);
GO

-- Creating table 'Catalog_level'
CREATE TABLE [dbo].[Catalog_level] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ParentID] int  NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'Catalogs'
CREATE TABLE [dbo].[Catalogs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'Models'
CREATE TABLE [dbo].[Models] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [AggregateID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Aggregates'
ALTER TABLE [dbo].[Aggregates]
ADD CONSTRAINT [PK_Aggregates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Catalog_level'
ALTER TABLE [dbo].[Catalog_level]
ADD CONSTRAINT [PK_Catalog_level]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Catalogs'
ALTER TABLE [dbo].[Catalogs]
ADD CONSTRAINT [PK_Catalogs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Models'
ALTER TABLE [dbo].[Models]
ADD CONSTRAINT [PK_Models]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CatalogID] in table 'Aggregates'
ALTER TABLE [dbo].[Aggregates]
ADD CONSTRAINT [FK_dbo_Aggregates_dbo_Catalogs_CatalogID]
    FOREIGN KEY ([CatalogID])
    REFERENCES [dbo].[Catalogs]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Aggregates_dbo_Catalogs_CatalogID'
CREATE INDEX [IX_FK_dbo_Aggregates_dbo_Catalogs_CatalogID]
ON [dbo].[Aggregates]
    ([CatalogID]);
GO

-- Creating foreign key on [AggregateID] in table 'Models'
ALTER TABLE [dbo].[Models]
ADD CONSTRAINT [FK_dbo_Models_dbo_Aggregates_AggregateID]
    FOREIGN KEY ([AggregateID])
    REFERENCES [dbo].[Aggregates]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Models_dbo_Aggregates_AggregateID'
CREATE INDEX [IX_FK_dbo_Models_dbo_Aggregates_AggregateID]
ON [dbo].[Models]
    ([AggregateID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------