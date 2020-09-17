IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Jogadores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Senha] nvarchar(max) NULL,
    [DataNascimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Jogadores] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Jogos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [DataLancamento] datetime2 NOT NULL,
    CONSTRAINT [PK_Jogos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [JogoJogadores] (
    [Id] uniqueidentifier NOT NULL,
    [IdJogo] uniqueidentifier NOT NULL,
    [IdJogador] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_JogoJogadores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JogoJogadores_Jogadores_IdJogador] FOREIGN KEY ([IdJogador]) REFERENCES [Jogadores] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_JogoJogadores_Jogos_IdJogo] FOREIGN KEY ([IdJogo]) REFERENCES [Jogos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_JogoJogadores_IdJogador] ON [JogoJogadores] ([IdJogador]);

GO

CREATE INDEX [IX_JogoJogadores_IdJogo] ON [JogoJogadores] ([IdJogo]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200915004256_InitialCreate', N'3.1.8');

GO

