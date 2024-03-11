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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [Brands] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [AddedOn] datetime2 NOT NULL,
        [ModifiedOn] datetime2 NOT NULL,
        [AddeddBy] uniqueidentifier NOT NULL,
        [ModifiedBy] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [Categories] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [AddedOn] datetime2 NOT NULL,
        [ModifiedOn] datetime2 NOT NULL,
        [AddeddBy] uniqueidentifier NOT NULL,
        [ModifiedBy] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [Colors] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [AddedOn] datetime2 NOT NULL,
        [ModifiedOn] datetime2 NOT NULL,
        [AddeddBy] int NOT NULL,
        [ModifiedBy] int NOT NULL,
        CONSTRAINT [PK_Colors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [Orders] (
        [Id] uniqueidentifier NOT NULL,
        [TotalPrice] decimal(18,2) NOT NULL,
        [AddedOn] datetime2 NOT NULL,
        [ModifiedOn] datetime2 NOT NULL,
        [AddeddBy] uniqueidentifier NOT NULL,
        [ModifiedBy] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [Sizes] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [AddedOn] datetime2 NOT NULL,
        [ModifiedOn] datetime2 NOT NULL,
        [AddeddBy] uniqueidentifier NOT NULL,
        [ModifiedBy] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Sizes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [BillingAddress] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [IsAdmin] bit NOT NULL,
        [AddedOn] datetime2 NOT NULL,
        [ModifiedOn] datetime2 NOT NULL,
        [AddeddBy] uniqueidentifier NOT NULL,
        [ModifiedBy] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [Products] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Quantity] int NOT NULL,
        [AddedOn] datetime2 NOT NULL,
        [ModifiedOn] datetime2 NOT NULL,
        [AddeddBy] uniqueidentifier NOT NULL,
        [ModifiedBy] uniqueidentifier NOT NULL,
        [BrandId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [BrandCategory] (
        [BrandsId] uniqueidentifier NOT NULL,
        [CategoriesId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_BrandCategory] PRIMARY KEY ([BrandsId], [CategoriesId]),
        CONSTRAINT [FK_BrandCategory_Brands_BrandsId] FOREIGN KEY ([BrandsId]) REFERENCES [Brands] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BrandCategory_Categories_CategoriesId] FOREIGN KEY ([CategoriesId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [CategoryProduct] (
        [CategoriesId] uniqueidentifier NOT NULL,
        [ProductsId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_CategoryProduct] PRIMARY KEY ([CategoriesId], [ProductsId]),
        CONSTRAINT [FK_CategoryProduct_Categories_CategoriesId] FOREIGN KEY ([CategoriesId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CategoryProduct_Products_ProductsId] FOREIGN KEY ([ProductsId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE TABLE [OrderProduct] (
        [OrdersId] uniqueidentifier NOT NULL,
        [ProductsId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_OrderProduct] PRIMARY KEY ([OrdersId], [ProductsId]),
        CONSTRAINT [FK_OrderProduct_Orders_OrdersId] FOREIGN KEY ([OrdersId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderProduct_Products_ProductsId] FOREIGN KEY ([ProductsId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE INDEX [IX_BrandCategory_CategoriesId] ON [BrandCategory] ([CategoriesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE INDEX [IX_CategoryProduct_ProductsId] ON [CategoryProduct] ([ProductsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE INDEX [IX_OrderProduct_ProductsId] ON [OrderProduct] ([ProductsId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    CREATE INDEX [IX_Products_BrandId] ON [Products] ([BrandId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922121843_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230922121843_Initial', N'7.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922135203_Properties Added to Product')
BEGIN
    ALTER TABLE [Products] ADD [ImageUrl] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922135203_Properties Added to Product')
BEGIN
    ALTER TABLE [Products] ADD [Rating] float NOT NULL DEFAULT 0.0E0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922135203_Properties Added to Product')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230922135203_Properties Added to Product', N'7.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922143425_Description property on Brand Entity made nullable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230922143425_Description property on Brand Entity made nullable', N'7.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922144215_Description on Brand Entity made nullable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Brands]') AND [c].[name] = N'Description');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Brands] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Brands] ALTER COLUMN [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922144215_Description on Brand Entity made nullable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230922144215_Description on Brand Entity made nullable', N'7.0.11');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922144338_Description on Category Entity made nullable')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'Description');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Categories] ALTER COLUMN [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230922144338_Description on Category Entity made nullable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230922144338_Description on Category Entity made nullable', N'7.0.11');
END;
GO

COMMIT;
GO

