
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/20/2018 12:32:28
-- Generated from EDMX file: C:\Users\bulya\source\repos\Course2\Model\Vma.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TransformationModelModelTransformationRuleModelModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransformationRuleModelModelSet] DROP CONSTRAINT [FK_TransformationModelModelTransformationRuleModelModel];
GO
IF OBJECT_ID(N'[dbo].[FK_TransformationRuleModelModelEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransformationRuleModelModelSet] DROP CONSTRAINT [FK_TransformationRuleModelModelEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_TransformationRuleModelModelEntity1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransformationRuleModelModelSet] DROP CONSTRAINT [FK_TransformationRuleModelModelEntity1];
GO
IF OBJECT_ID(N'[dbo].[FK_TransformationModelTextTransformationRuleModelText]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransformationRuleModelTextSet] DROP CONSTRAINT [FK_TransformationModelTextTransformationRuleModelText];
GO
IF OBJECT_ID(N'[dbo].[FK_TransformationRuleModelTextEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransformationRuleModelTextSet] DROP CONSTRAINT [FK_TransformationRuleModelTextEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityAttribute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttributeSet] DROP CONSTRAINT [FK_EntityAttribute];
GO
IF OBJECT_ID(N'[dbo].[FK_RelationshipAttribute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttributeSet] DROP CONSTRAINT [FK_RelationshipAttribute];
GO
IF OBJECT_ID(N'[dbo].[FK_RelationshipRelationshipParent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationshipParentSet] DROP CONSTRAINT [FK_RelationshipRelationshipParent];
GO
IF OBJECT_ID(N'[dbo].[FK_RelationshipRelationshipParent1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationshipParentSet] DROP CONSTRAINT [FK_RelationshipRelationshipParent1];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelGraphModelGraphParent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModelGraphParentSet] DROP CONSTRAINT [FK_ModelGraphModelGraphParent];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelGraphParentModelGraph]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModelGraphParentSet] DROP CONSTRAINT [FK_ModelGraphParentModelGraph];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelGraphTransformationModelText]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransformationModelTextSet] DROP CONSTRAINT [FK_ModelGraphTransformationModelText];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelGraphTransformationModelModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransformationModelModelSet] DROP CONSTRAINT [FK_ModelGraphTransformationModelModel];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelGraphEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntitySet] DROP CONSTRAINT [FK_ModelGraphEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityEntityParent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityParentSet] DROP CONSTRAINT [FK_EntityEntityParent];
GO
IF OBJECT_ID(N'[dbo].[FK_EntityParentEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntityParentSet] DROP CONSTRAINT [FK_EntityParentEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_ModelGraphRelationship]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationshipSet] DROP CONSTRAINT [FK_ModelGraphRelationship];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TransformationRuleModelModelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransformationRuleModelModelSet];
GO
IF OBJECT_ID(N'[dbo].[TransformationRuleModelTextSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransformationRuleModelTextSet];
GO
IF OBJECT_ID(N'[dbo].[TransformationModelTextSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransformationModelTextSet];
GO
IF OBJECT_ID(N'[dbo].[TransformationModelModelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransformationModelModelSet];
GO
IF OBJECT_ID(N'[dbo].[AttributeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AttributeSet];
GO
IF OBJECT_ID(N'[dbo].[RelationshipParentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelationshipParentSet];
GO
IF OBJECT_ID(N'[dbo].[ModelGraphParentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModelGraphParentSet];
GO
IF OBJECT_ID(N'[dbo].[ModelGraphSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModelGraphSet];
GO
IF OBJECT_ID(N'[dbo].[EntitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntitySet];
GO
IF OBJECT_ID(N'[dbo].[EntityParentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntityParentSet];
GO
IF OBJECT_ID(N'[dbo].[RelationshipSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelationshipSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TransformationRuleModelModelSet'
CREATE TABLE [dbo].[TransformationRuleModelModelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TransformationModelModelId] int  NOT NULL,
    [Initial_Id] int  NOT NULL,
    [Final_Id] int  NOT NULL
);
GO

-- Creating table 'TransformationRuleModelTextSet'
CREATE TABLE [dbo].[TransformationRuleModelTextSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Final] nvarchar(max)  NOT NULL,
    [TransformationModelTextId] int  NOT NULL,
    [Initial_Id] int  NOT NULL
);
GO

-- Creating table 'TransformationModelTextSet'
CREATE TABLE [dbo].[TransformationModelTextSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ModelGraphId] int  NOT NULL
);
GO

-- Creating table 'TransformationModelModelSet'
CREATE TABLE [dbo].[TransformationModelModelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ModelGraphId] int  NOT NULL
);
GO

-- Creating table 'AttributeSet'
CREATE TABLE [dbo].[AttributeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [DefaultValue] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [EntityId] int  NOT NULL,
    [RelationshipId] int  NOT NULL
);
GO

-- Creating table 'RelationshipParentSet'
CREATE TABLE [dbo].[RelationshipParentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Relationship_Id] int  NOT NULL,
    [Parent_Id] int  NOT NULL
);
GO

-- Creating table 'ModelGraphParentSet'
CREATE TABLE [dbo].[ModelGraphParentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ModelGraph_Id] int  NOT NULL,
    [Parent_Id] int  NOT NULL
);
GO

-- Creating table 'ModelGraphSet'
CREATE TABLE [dbo].[ModelGraphSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EntitySet'
CREATE TABLE [dbo].[EntitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [InstanceCount] int  NOT NULL,
    [NameUniqueFlag] int  NOT NULL,
    [ModelGraphId] int  NOT NULL
);
GO

-- Creating table 'EntityParentSet'
CREATE TABLE [dbo].[EntityParentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Entity_Id] int  NOT NULL,
    [Parent_Id] int  NOT NULL
);
GO

-- Creating table 'RelationshipSet'
CREATE TABLE [dbo].[RelationshipSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Multiplicity1] int  NOT NULL,
    [Multiplicity2] int  NOT NULL,
    [NameUniqueFlag] int  NOT NULL,
    [Type] int  NOT NULL,
    [ModelGraphId] int  NOT NULL,
    [Entity1_Id] int  NOT NULL,
    [Entity2_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TransformationRuleModelModelSet'
ALTER TABLE [dbo].[TransformationRuleModelModelSet]
ADD CONSTRAINT [PK_TransformationRuleModelModelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransformationRuleModelTextSet'
ALTER TABLE [dbo].[TransformationRuleModelTextSet]
ADD CONSTRAINT [PK_TransformationRuleModelTextSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransformationModelTextSet'
ALTER TABLE [dbo].[TransformationModelTextSet]
ADD CONSTRAINT [PK_TransformationModelTextSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransformationModelModelSet'
ALTER TABLE [dbo].[TransformationModelModelSet]
ADD CONSTRAINT [PK_TransformationModelModelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AttributeSet'
ALTER TABLE [dbo].[AttributeSet]
ADD CONSTRAINT [PK_AttributeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RelationshipParentSet'
ALTER TABLE [dbo].[RelationshipParentSet]
ADD CONSTRAINT [PK_RelationshipParentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ModelGraphParentSet'
ALTER TABLE [dbo].[ModelGraphParentSet]
ADD CONSTRAINT [PK_ModelGraphParentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ModelGraphSet'
ALTER TABLE [dbo].[ModelGraphSet]
ADD CONSTRAINT [PK_ModelGraphSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EntitySet'
ALTER TABLE [dbo].[EntitySet]
ADD CONSTRAINT [PK_EntitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EntityParentSet'
ALTER TABLE [dbo].[EntityParentSet]
ADD CONSTRAINT [PK_EntityParentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RelationshipSet'
ALTER TABLE [dbo].[RelationshipSet]
ADD CONSTRAINT [PK_RelationshipSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TransformationModelModelId] in table 'TransformationRuleModelModelSet'
ALTER TABLE [dbo].[TransformationRuleModelModelSet]
ADD CONSTRAINT [FK_TransformationModelModelTransformationRuleModelModel]
    FOREIGN KEY ([TransformationModelModelId])
    REFERENCES [dbo].[TransformationModelModelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransformationModelModelTransformationRuleModelModel'
CREATE INDEX [IX_FK_TransformationModelModelTransformationRuleModelModel]
ON [dbo].[TransformationRuleModelModelSet]
    ([TransformationModelModelId]);
GO

-- Creating foreign key on [Initial_Id] in table 'TransformationRuleModelModelSet'
ALTER TABLE [dbo].[TransformationRuleModelModelSet]
ADD CONSTRAINT [FK_TransformationRuleModelModelEntity]
    FOREIGN KEY ([Initial_Id])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransformationRuleModelModelEntity'
CREATE INDEX [IX_FK_TransformationRuleModelModelEntity]
ON [dbo].[TransformationRuleModelModelSet]
    ([Initial_Id]);
GO

-- Creating foreign key on [Final_Id] in table 'TransformationRuleModelModelSet'
ALTER TABLE [dbo].[TransformationRuleModelModelSet]
ADD CONSTRAINT [FK_TransformationRuleModelModelEntity1]
    FOREIGN KEY ([Final_Id])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransformationRuleModelModelEntity1'
CREATE INDEX [IX_FK_TransformationRuleModelModelEntity1]
ON [dbo].[TransformationRuleModelModelSet]
    ([Final_Id]);
GO

-- Creating foreign key on [TransformationModelTextId] in table 'TransformationRuleModelTextSet'
ALTER TABLE [dbo].[TransformationRuleModelTextSet]
ADD CONSTRAINT [FK_TransformationModelTextTransformationRuleModelText]
    FOREIGN KEY ([TransformationModelTextId])
    REFERENCES [dbo].[TransformationModelTextSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransformationModelTextTransformationRuleModelText'
CREATE INDEX [IX_FK_TransformationModelTextTransformationRuleModelText]
ON [dbo].[TransformationRuleModelTextSet]
    ([TransformationModelTextId]);
GO

-- Creating foreign key on [Initial_Id] in table 'TransformationRuleModelTextSet'
ALTER TABLE [dbo].[TransformationRuleModelTextSet]
ADD CONSTRAINT [FK_TransformationRuleModelTextEntity]
    FOREIGN KEY ([Initial_Id])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransformationRuleModelTextEntity'
CREATE INDEX [IX_FK_TransformationRuleModelTextEntity]
ON [dbo].[TransformationRuleModelTextSet]
    ([Initial_Id]);
GO

-- Creating foreign key on [EntityId] in table 'AttributeSet'
ALTER TABLE [dbo].[AttributeSet]
ADD CONSTRAINT [FK_EntityAttribute]
    FOREIGN KEY ([EntityId])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityAttribute'
CREATE INDEX [IX_FK_EntityAttribute]
ON [dbo].[AttributeSet]
    ([EntityId]);
GO

-- Creating foreign key on [RelationshipId] in table 'AttributeSet'
ALTER TABLE [dbo].[AttributeSet]
ADD CONSTRAINT [FK_RelationshipAttribute]
    FOREIGN KEY ([RelationshipId])
    REFERENCES [dbo].[RelationshipSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelationshipAttribute'
CREATE INDEX [IX_FK_RelationshipAttribute]
ON [dbo].[AttributeSet]
    ([RelationshipId]);
GO

-- Creating foreign key on [Relationship_Id] in table 'RelationshipParentSet'
ALTER TABLE [dbo].[RelationshipParentSet]
ADD CONSTRAINT [FK_RelationshipRelationshipParent]
    FOREIGN KEY ([Relationship_Id])
    REFERENCES [dbo].[RelationshipSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelationshipRelationshipParent'
CREATE INDEX [IX_FK_RelationshipRelationshipParent]
ON [dbo].[RelationshipParentSet]
    ([Relationship_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'RelationshipParentSet'
ALTER TABLE [dbo].[RelationshipParentSet]
ADD CONSTRAINT [FK_RelationshipRelationshipParent1]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[RelationshipSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelationshipRelationshipParent1'
CREATE INDEX [IX_FK_RelationshipRelationshipParent1]
ON [dbo].[RelationshipParentSet]
    ([Parent_Id]);
GO

-- Creating foreign key on [ModelGraph_Id] in table 'ModelGraphParentSet'
ALTER TABLE [dbo].[ModelGraphParentSet]
ADD CONSTRAINT [FK_ModelGraphModelGraphParent]
    FOREIGN KEY ([ModelGraph_Id])
    REFERENCES [dbo].[ModelGraphSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelGraphModelGraphParent'
CREATE INDEX [IX_FK_ModelGraphModelGraphParent]
ON [dbo].[ModelGraphParentSet]
    ([ModelGraph_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'ModelGraphParentSet'
ALTER TABLE [dbo].[ModelGraphParentSet]
ADD CONSTRAINT [FK_ModelGraphParentModelGraph]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[ModelGraphSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelGraphParentModelGraph'
CREATE INDEX [IX_FK_ModelGraphParentModelGraph]
ON [dbo].[ModelGraphParentSet]
    ([Parent_Id]);
GO

-- Creating foreign key on [ModelGraphId] in table 'TransformationModelTextSet'
ALTER TABLE [dbo].[TransformationModelTextSet]
ADD CONSTRAINT [FK_ModelGraphTransformationModelText]
    FOREIGN KEY ([ModelGraphId])
    REFERENCES [dbo].[ModelGraphSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelGraphTransformationModelText'
CREATE INDEX [IX_FK_ModelGraphTransformationModelText]
ON [dbo].[TransformationModelTextSet]
    ([ModelGraphId]);
GO

-- Creating foreign key on [ModelGraphId] in table 'TransformationModelModelSet'
ALTER TABLE [dbo].[TransformationModelModelSet]
ADD CONSTRAINT [FK_ModelGraphTransformationModelModel]
    FOREIGN KEY ([ModelGraphId])
    REFERENCES [dbo].[ModelGraphSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelGraphTransformationModelModel'
CREATE INDEX [IX_FK_ModelGraphTransformationModelModel]
ON [dbo].[TransformationModelModelSet]
    ([ModelGraphId]);
GO

-- Creating foreign key on [ModelGraphId] in table 'EntitySet'
ALTER TABLE [dbo].[EntitySet]
ADD CONSTRAINT [FK_ModelGraphEntity]
    FOREIGN KEY ([ModelGraphId])
    REFERENCES [dbo].[ModelGraphSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelGraphEntity'
CREATE INDEX [IX_FK_ModelGraphEntity]
ON [dbo].[EntitySet]
    ([ModelGraphId]);
GO

-- Creating foreign key on [Entity_Id] in table 'EntityParentSet'
ALTER TABLE [dbo].[EntityParentSet]
ADD CONSTRAINT [FK_EntityEntityParent]
    FOREIGN KEY ([Entity_Id])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityEntityParent'
CREATE INDEX [IX_FK_EntityEntityParent]
ON [dbo].[EntityParentSet]
    ([Entity_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'EntityParentSet'
ALTER TABLE [dbo].[EntityParentSet]
ADD CONSTRAINT [FK_EntityParentEntity]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntityParentEntity'
CREATE INDEX [IX_FK_EntityParentEntity]
ON [dbo].[EntityParentSet]
    ([Parent_Id]);
GO

-- Creating foreign key on [ModelGraphId] in table 'RelationshipSet'
ALTER TABLE [dbo].[RelationshipSet]
ADD CONSTRAINT [FK_ModelGraphRelationship]
    FOREIGN KEY ([ModelGraphId])
    REFERENCES [dbo].[ModelGraphSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModelGraphRelationship'
CREATE INDEX [IX_FK_ModelGraphRelationship]
ON [dbo].[RelationshipSet]
    ([ModelGraphId]);
GO

-- Creating foreign key on [Entity1_Id] in table 'RelationshipSet'
ALTER TABLE [dbo].[RelationshipSet]
ADD CONSTRAINT [FK_RelationshipEntity]
    FOREIGN KEY ([Entity1_Id])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelationshipEntity'
CREATE INDEX [IX_FK_RelationshipEntity]
ON [dbo].[RelationshipSet]
    ([Entity1_Id]);
GO

-- Creating foreign key on [Entity2_Id] in table 'RelationshipSet'
ALTER TABLE [dbo].[RelationshipSet]
ADD CONSTRAINT [FK_RelationshipEntity1]
    FOREIGN KEY ([Entity2_Id])
    REFERENCES [dbo].[EntitySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelationshipEntity1'
CREATE INDEX [IX_FK_RelationshipEntity1]
ON [dbo].[RelationshipSet]
    ([Entity2_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------