CREATE TABLE [dbo].[TableS] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [Sity]      NCHAR (10) NULL,
    [CountryId] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TableS_ToTable] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Table] ([Id])
);

