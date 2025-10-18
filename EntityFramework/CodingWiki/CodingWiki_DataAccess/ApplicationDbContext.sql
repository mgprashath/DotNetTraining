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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251016165812_AddBookToDB'
)
BEGIN
    CREATE TABLE [Books] (
        [BookId] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [ISBN] nvarchar(max) NOT NULL,
        [Price] float NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([BookId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251016165812_AddBookToDB'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251016165812_AddBookToDB', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017044206_ChangeDataType'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'Price');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [Books] ALTER COLUMN [Price] decimal(10,5) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017044206_ChangeDataType'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017044206_ChangeDataType', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017044737_AddGenreTable'
)
BEGIN
    CREATE TABLE [Genres] (
        [GenreId] int NOT NULL IDENTITY,
        [GenreName] nvarchar(max) NOT NULL,
        [Display] int NOT NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([GenreId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017044737_AddGenreTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017044737_AddGenreTable', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017050103_renameDisplayInGenre'
)
BEGIN
    EXEC sp_rename N'[Genres].[Display]', N'DisplayOrder', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017050103_renameDisplayInGenre'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Genres]') AND [c].[name] = N'GenreName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Genres] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Genres] ALTER COLUMN [GenreName] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017050103_renameDisplayInGenre'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'Title');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Books] ALTER COLUMN [Title] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017050103_renameDisplayInGenre'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'ISBN');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Books] ALTER COLUMN [ISBN] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017050103_renameDisplayInGenre'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017050103_renameDisplayInGenre', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017050534_RemoveGenreTable'
)
BEGIN
    DROP TABLE [Genres];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017050534_RemoveGenreTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017050534_RemoveGenreTable', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017054433_reAddGenere'
)
BEGIN
    CREATE TABLE [Genres] (
        [GenreId] int NOT NULL IDENTITY,
        [GenreName] nvarchar(max) NULL,
        [DisplayOrder] int NOT NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY ([GenreId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017054433_reAddGenere'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017054433_reAddGenere', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017055741_seedBookTable'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'ISBN', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
        SET IDENTITY_INSERT [Books] ON;
    EXEC(N'INSERT INTO [Books] ([BookId], [ISBN], [Price], [Title])
    VALUES (1, N''ASD123444'', 50.5, N''Generics''),
    (2, N''BGG9005'', 100.0, N''Advance C sharp''),
    (3, N''GOOGLE'', 150.5, N''Google''),
    (4, N''FFF4590'', 50.0, N''Basic C sharp''),
    (5, N''AAA5555'', 75.0, N''Intermediate C sharp'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'ISBN', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
        SET IDENTITY_INSERT [Books] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017055741_seedBookTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017055741_seedBookTable', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017071908_changeGenereTableName'
)
BEGIN
    ALTER TABLE [Genres] DROP CONSTRAINT [PK_Genres];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017071908_changeGenereTableName'
)
BEGIN
    EXEC sp_rename N'[Genres]', N'tb_geners', 'OBJECT';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017071908_changeGenereTableName'
)
BEGIN
    EXEC sp_rename N'[tb_geners].[GenreName]', N'Name', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017071908_changeGenereTableName'
)
BEGIN
    ALTER TABLE [tb_geners] ADD CONSTRAINT [PK_tb_geners] PRIMARY KEY ([GenreId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017071908_changeGenereTableName'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017071908_changeGenereTableName', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017072207_ChangeGenereIdName'
)
BEGIN
    EXEC sp_rename N'[tb_geners].[GenreId]', N'Genre_Id', 'COLUMN';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017072207_ChangeGenereIdName'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[tb_geners]') AND [c].[name] = N'Name');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [tb_geners] DROP CONSTRAINT [' + @var4 + '];');
    EXEC(N'UPDATE [tb_geners] SET [Name] = N'''' WHERE [Name] IS NULL');
    ALTER TABLE [tb_geners] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
    ALTER TABLE [tb_geners] ADD DEFAULT N'' FOR [Name];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017072207_ChangeGenereIdName'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017072207_ChangeGenereIdName', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017072722_RenameGenereToCategory'
)
BEGIN
    DROP TABLE [tb_geners];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017072722_RenameGenereToCategory'
)
BEGIN
    CREATE TABLE [Categories] (
        [CategoryId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [DisplayOrder] int NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017072722_RenameGenereToCategory'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017072722_RenameGenereToCategory', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017073052_ChangeBookAddColumnNotMapped'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Books]') AND [c].[name] = N'ISBN');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Books] DROP CONSTRAINT [' + @var5 + '];');
    EXEC(N'UPDATE [Books] SET [ISBN] = N'''' WHERE [ISBN] IS NULL');
    ALTER TABLE [Books] ALTER COLUMN [ISBN] nvarchar(20) NOT NULL;
    ALTER TABLE [Books] ADD DEFAULT N'' FOR [ISBN];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017073052_ChangeBookAddColumnNotMapped'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017073052_ChangeBookAddColumnNotMapped', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017075122_AuthorPublisherAndSubCategoryTableAdd'
)
BEGIN
    CREATE TABLE [Authors] (
        [Author_Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [BirthDate] datetime2 NOT NULL,
        [Location] nvarchar(max) NULL,
        CONSTRAINT [PK_Authors] PRIMARY KEY ([Author_Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017075122_AuthorPublisherAndSubCategoryTableAdd'
)
BEGIN
    CREATE TABLE [Publishers] (
        [Publisher_Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Location] nvarchar(max) NULL,
        CONSTRAINT [PK_Publishers] PRIMARY KEY ([Publisher_Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017075122_AuthorPublisherAndSubCategoryTableAdd'
)
BEGIN
    CREATE TABLE [SubCategories] (
        [SubCategory_Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_SubCategories] PRIMARY KEY ([SubCategory_Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017075122_AuthorPublisherAndSubCategoryTableAdd'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017075122_AuthorPublisherAndSubCategoryTableAdd', N'9.0.10');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017080627_AddBookDetailsTable'
)
BEGIN
    CREATE TABLE [BookDetails] (
        [BookDetail_Id] int NOT NULL IDENTITY,
        [NumberOfChapters] int NOT NULL,
        [NumberOfPages] int NOT NULL,
        [Weight] nvarchar(max) NULL,
        CONSTRAINT [PK_BookDetails] PRIMARY KEY ([BookDetail_Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251017080627_AddBookDetailsTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251017080627_AddBookDetailsTable', N'9.0.10');
END;

COMMIT;
GO