IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Proprietarios] (
    [Id] uniqueidentifier NOT NULL,
    [EnderecoId] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Documento] varchar(14) NOT NULL,
    [CNH] varchar(11) NOT NULL,
    CONSTRAINT [PK_Proprietarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Carros] (
    [Id] uniqueidentifier NOT NULL,
    [ProprietarioId] uniqueidentifier NOT NULL,
    [Fabricante] varchar(100) NOT NULL,
    [ModeloCarro] varchar(30) NOT NULL,
    [AnoModelo] int NOT NULL,
    [Categoria] varchar(100) NOT NULL,
    [Cor] varchar(100) NOT NULL,
    CONSTRAINT [PK_Carros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Carros_Proprietarios_ProprietarioId] FOREIGN KEY ([ProprietarioId]) REFERENCES [Proprietarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [Logradouro] varchar(100) NOT NULL,
    [Numero] varchar(14) NOT NULL,
    [Complemento] nvarchar(max) NULL,
    [Cep] varchar(8) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(100) NOT NULL,
    [UF] varchar(2) NOT NULL,
    [ProprietarioId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Proprietarios_ProprietarioId] FOREIGN KEY ([ProprietarioId]) REFERENCES [Proprietarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Carros_ProprietarioId] ON [Carros] ([ProprietarioId]);
GO

CREATE UNIQUE INDEX [IX_Enderecos_ProprietarioId] ON [Enderecos] ([ProprietarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230518213627_Initial', N'6.0.10');
GO

COMMIT;
GO

