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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    ALTER TABLE [Employee] DROP CONSTRAINT [FK_Employee_Designation_DesignationId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    ALTER TABLE [Employee] DROP CONSTRAINT [FK_Employee_Merchant_MerchantId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    ALTER TABLE [Employee] DROP CONSTRAINT [PK_Employee];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Merchant].[Phone]', N'phone', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Merchant].[OrganizationName]', N'organizationName', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Merchant].[Name]', N'name', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Merchant].[Address]', N'address', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Merchant].[MerchantId]', N'merchantId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[Username]', N'username', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[Salary]', N'salary', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[Phone]', N'phone', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[Password]', N'password', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[Name]', N'name', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[MerchantId]', N'merchantId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[Email]', N'email', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[DesignationId]', N'designationId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[Dateofjoining]', N'dateofjoining', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[EmployeeId]', N'employeeId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[IX_Employee_MerchantId]', N'IX_Employee_merchantId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Employee].[IX_Employee_DesignationId]', N'IX_Employee_designationId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Designation].[Name]', N'name', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    EXEC sp_rename N'[Designation].[DesignationId]', N'designationId', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Merchant]') AND [c].[name] = N'phone');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Merchant] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Merchant] ALTER COLUMN [phone] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Merchant]') AND [c].[name] = N'organizationName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Merchant] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Merchant] ALTER COLUMN [organizationName] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Merchant]') AND [c].[name] = N'name');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Merchant] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Merchant] ALTER COLUMN [name] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Merchant]') AND [c].[name] = N'address');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Merchant] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Merchant] ALTER COLUMN [address] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'username');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Employee] ALTER COLUMN [username] nvarchar(50) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'phone');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Employee] ALTER COLUMN [phone] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'password');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Employee] ALTER COLUMN [password] nvarchar(50) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'name');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Employee] ALTER COLUMN [name] nvarchar(50) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'email');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Employee] ALTER COLUMN [email] nvarchar(50) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employee]') AND [c].[name] = N'dateofjoining');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Employee] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Employee] ALTER COLUMN [dateofjoining] datetime NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Designation]') AND [c].[name] = N'name');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Designation] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Designation] ALTER COLUMN [name] nvarchar(50) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    ALTER TABLE [Employee] ADD CONSTRAINT [PK_Employee] PRIMARY KEY ([employeeId], [merchantId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE TABLE [Category] (
        [categoryId] int NOT NULL IDENTITY,
        [merchantId] int NOT NULL,
        [name] nvarchar(50) NULL,
        [description] nvarchar(max) NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([categoryId], [merchantId]),
        CONSTRAINT [FK_Category_Merchant] FOREIGN KEY ([merchantId]) REFERENCES [Merchant] ([merchantId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE TABLE [Customer] (
        [customerId] int NOT NULL IDENTITY,
        [merchantId] int NOT NULL,
        [mail] nvarchar(50) NULL,
        [phone] nvarchar(50) NULL,
        [points] int NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([customerId], [merchantId]),
        CONSTRAINT [FK_Customer_Merchant] FOREIGN KEY ([merchantId]) REFERENCES [Merchant] ([merchantId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE TABLE [Product] (
        [productId] int NOT NULL IDENTITY,
        [merchantId] int NOT NULL,
        [name] nvarchar(50) NOT NULL,
        [unitcost] float NOT NULL,
        [categoryId] int NULL,
        [sellingprice] float NOT NULL,
        [comission] float NULL,
        [rating] int NULL,
        [createdDate] datetime NULL,
        [modifiedDate] datetime NULL,
        [modifiedUserName] nvarchar(50) NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([productId], [merchantId]),
        CONSTRAINT [FK_Product_Merchant] FOREIGN KEY ([merchantId]) REFERENCES [Merchant] ([merchantId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Product_Category] FOREIGN KEY ([categoryId], [merchantId]) REFERENCES [Category] ([categoryId], [merchantId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE TABLE [Quantity] (
        [productId] int NOT NULL,
        [merchantId] int NOT NULL,
        [quantityInStock] int NULL,
        [quantitySold] int NULL,
        [quantityRemaining] int NULL,
        [depletionQuantity] int NULL,
        CONSTRAINT [PK_Quantity] PRIMARY KEY ([productId], [merchantId]),
        CONSTRAINT [AK_Quantity_merchantId_productId] UNIQUE ([merchantId], [productId]),
        CONSTRAINT [FK_Quantity_Product] FOREIGN KEY ([productId], [merchantId]) REFERENCES [Product] ([productId], [merchantId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE INDEX [IX_Category_merchantId] ON [Category] ([merchantId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE INDEX [IX_Customer_merchantId] ON [Customer] ([merchantId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE INDEX [IX_Product_merchantId] ON [Product] ([merchantId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    CREATE INDEX [IX_Product_categoryId_merchantId] ON [Product] ([categoryId], [merchantId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    ALTER TABLE [Employee] ADD CONSTRAINT [FK_Employee_Designation] FOREIGN KEY ([designationId]) REFERENCES [Designation] ([designationId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    ALTER TABLE [Employee] ADD CONSTRAINT [FK_Employee_Merchant] FOREIGN KEY ([merchantId]) REFERENCES [Merchant] ([merchantId]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190616094551_Migration1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190616094551_Migration1', N'2.2.4-servicing-10062');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190617062651_SomeMigration')
BEGIN
    CREATE TABLE [Ticket] (
        [ticketId] bigint NOT NULL IDENTITY,
        [merchantid] int NOT NULL,
        [employeeId] int NOT NULL,
        [customerId] int NULL,
        [totalCost] float NOT NULL,
        [orderDate] datetime NOT NULL,
        CONSTRAINT [PK_Ticket] PRIMARY KEY ([ticketId], [merchantid])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190617062651_SomeMigration')
BEGIN
    CREATE TABLE [TicketLineProduct] (
        [ticketId] bigint NOT NULL,
        [productId] int NOT NULL,
        [merchantId] int NOT NULL,
        [quantity] int NOT NULL,
        [price] float NOT NULL,
        [totalPrice] float NOT NULL,
        [commission] float NULL,
        CONSTRAINT [PK_TicketLineProduct] PRIMARY KEY ([ticketId], [productId], [merchantId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190617062651_SomeMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190617062651_SomeMigration', N'2.2.4-servicing-10062');
END;

GO

