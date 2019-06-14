IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605042811_InitialMigration')
BEGIN
    CREATE TABLE [Employees] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Department] nvarchar(max) NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605042811_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190605042811_InitialMigration', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190605052247_NewMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190605052247_NewMigration', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613230751_FinalMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190613230751_FinalMigration', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employees] DROP CONSTRAINT [PK_Employees];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    EXEC sp_rename N'[Employees]', N'Employee';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    EXEC sp_rename N'[Employee].[Department]', N'Username', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    EXEC sp_rename N'[Employee].[Id]', N'EmployeeId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD [Dateofjoining] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD [DesignationId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD [MerchantId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD [Password] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD [Phone] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD [Salary] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    CREATE TABLE [Designation] (
        [DesignationId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Designation] PRIMARY KEY ([DesignationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    CREATE TABLE [Merchant] (
        [MerchantId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [OrganizationName] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        CONSTRAINT [PK_Merchant] PRIMARY KEY ([MerchantId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    CREATE INDEX [IX_Employee_DesignationId] ON [Employee] ([DesignationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    CREATE INDEX [IX_Employee_MerchantId] ON [Employee] ([MerchantId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD CONSTRAINT [FK_Employee_Designation_DesignationId] FOREIGN KEY ([DesignationId]) REFERENCES [Designation] ([DesignationId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    ALTER TABLE [Employee] ADD CONSTRAINT [FK_Employee_Merchant_MerchantId] FOREIGN KEY ([MerchantId]) REFERENCES [Merchant] ([MerchantId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190614140434_AddedMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190614140434_AddedMigration', N'2.2.4-servicing-10062');
END;

GO

