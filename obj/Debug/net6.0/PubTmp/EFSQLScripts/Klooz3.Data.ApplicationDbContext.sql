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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [categories] (
        [categoriesId] int NOT NULL IDENTITY,
        [name] nvarchar(max) NULL,
        CONSTRAINT [PK_categories] PRIMARY KEY ([categoriesId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [partners] (
        [partnerId] int NOT NULL IDENTITY,
        [partnerName] nvarchar(max) NULL,
        [partnerImage] varbinary(max) NULL,
        [partnerLink] nvarchar(max) NULL,
        [partnerDisplayOrder] int NULL,
        CONSTRAINT [PK_partners] PRIMARY KEY ([partnerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [teamregies] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Emailadress] nvarchar(max) NULL,
        CONSTRAINT [PK_teamregies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE TABLE [experiments] (
        [experimentId] int NOT NULL IDENTITY,
        [experimentImage] varbinary(max) NULL,
        [experimentName] nvarchar(max) NULL,
        [experimentCardFrontText] nvarchar(max) NULL,
        [experimentCardBackText] nvarchar(max) NULL,
        [categoriesId] int NULL,
        [experimentShortText] nvarchar(max) NULL,
        [experimentPartners] nvarchar(max) NULL,
        [experimentKickOffDate] datetime2 NULL,
        [experimentwickedProblemsToSmartSolutions] nvarchar(max) NULL,
        [experimenttargetAndImpact] nvarchar(max) NULL,
        [experimentTouchstone] nvarchar(max) NULL,
        [experimentPhotos] varbinary(max) NULL,
        [experimentPublished] bit NULL,
        CONSTRAINT [PK_experiments] PRIMARY KEY ([experimentId]),
        CONSTRAINT [FK_experiments_categories_categoriesId] FOREIGN KEY ([categoriesId]) REFERENCES [categories] ([categoriesId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    CREATE INDEX [IX_experiments_categoriesId] ON [experiments] ([categoriesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717112320_newest-initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230717112320_newest-initial', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230718081749_empty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230718081749_empty', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230718081832_partnerAlt')
BEGIN
    ALTER TABLE [partners] ADD [partnerAlt] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230718081832_partnerAlt')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230718081832_partnerAlt', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentPartners');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentPartners];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD [experimentCreatedDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD [experimentEndDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD [experimentLastModified] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD [experimentLastModifiedByuserId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD [experimentOwneruserId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD [experimentPartnerspartnerId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD [experimentStatus] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    CREATE TABLE [User] (
        [userId] int NOT NULL IDENTITY,
        [userEmail] nvarchar(max) NULL,
        [userVoornaam] nvarchar(max) NULL,
        [userAchternaam] nvarchar(max) NULL,
        [userAdressLine1] nvarchar(max) NULL,
        [userPostcode] nvarchar(max) NULL,
        [userGemeente] nvarchar(max) NULL,
        [userPhoneNumber] nvarchar(max) NULL,
        [userJoined] datetime2 NULL,
        [userIsAccountActive] bit NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([userId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    CREATE INDEX [IX_experiments_experimentLastModifiedByuserId] ON [experiments] ([experimentLastModifiedByuserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    CREATE INDEX [IX_experiments_experimentOwneruserId] ON [experiments] ([experimentOwneruserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    CREATE INDEX [IX_experiments_experimentPartnerspartnerId] ON [experiments] ([experimentPartnerspartnerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD CONSTRAINT [FK_experiments_partners_experimentPartnerspartnerId] FOREIGN KEY ([experimentPartnerspartnerId]) REFERENCES [partners] ([partnerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD CONSTRAINT [FK_experiments_User_experimentLastModifiedByuserId] FOREIGN KEY ([experimentLastModifiedByuserId]) REFERENCES [User] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    ALTER TABLE [experiments] ADD CONSTRAINT [FK_experiments_User_experimentOwneruserId] FOREIGN KEY ([experimentOwneruserId]) REFERENCES [User] ([userId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230801072903_test001')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230801072903_test001', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    ALTER TABLE [experiments] DROP CONSTRAINT [FK_experiments_User_experimentLastModifiedByuserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    ALTER TABLE [experiments] DROP CONSTRAINT [FK_experiments_User_experimentOwneruserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    DROP TABLE [User];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    DROP INDEX [IX_experiments_experimentLastModifiedByuserId] ON [experiments];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    DROP INDEX [IX_experiments_experimentOwneruserId] ON [experiments];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentLastModifiedByuserId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentLastModifiedByuserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentOwneruserId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentOwneruserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231017092707_UsersRemoved')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231017092707_UsersRemoved', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    ALTER TABLE [experiments] DROP CONSTRAINT [FK_experiments_categories_categoriesId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    ALTER TABLE [experiments] DROP CONSTRAINT [FK_experiments_partners_experimentPartnerspartnerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DROP INDEX [IX_experiments_categoriesId] ON [experiments];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DROP INDEX [IX_experiments_experimentPartnerspartnerId] ON [experiments];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'categoriesId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [experiments] DROP COLUMN [categoriesId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCardFrontText');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentCardFrontText];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCreatedDate');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentCreatedDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentEndDate');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentEndDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentKickOffDate');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentKickOffDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentLastModified');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentLastModified];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentPartnerspartnerId');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentPartnerspartnerId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentStatus');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentStatus];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentTouchstone');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentTouchstone];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimenttargetAndImpact');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimenttargetAndImpact];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentwickedProblemsToSmartSolutions');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentwickedProblemsToSmartSolutions];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023080117_updatetExperimentModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231023080117_updatetExperimentModel', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231023125724_boolPublishedStandardValueFalse')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231023125724_boolPublishedStandardValueFalse', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113090305_addedviewmodeluserexperiment')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231113090305_addedviewmodeluserexperiment', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113092042_tableAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231113092042_tableAdded', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113093051_addedtableperhaps')
BEGIN
    CREATE TABLE [userexperimenten] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ExperimentId] int NOT NULL,
        CONSTRAINT [PK_userexperimenten] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_userexperimenten_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_userexperimenten_experiments_ExperimentId] FOREIGN KEY ([ExperimentId]) REFERENCES [experiments] ([experimentId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113093051_addedtableperhaps')
BEGIN
    CREATE INDEX [IX_userexperimenten_ExperimentId] ON [userexperimenten] ([ExperimentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113093051_addedtableperhaps')
BEGIN
    CREATE INDEX [IX_userexperimenten_UserId] ON [userexperimenten] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113093051_addedtableperhaps')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231113093051_addedtableperhaps', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113105437_removedPhotos')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentPhotos');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [experiments] DROP COLUMN [experimentPhotos];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231113105437_removedPhotos')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231113105437_removedPhotos', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121082559_UpdatetFields')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231121082559_UpdatetFields', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121090605_AppUserIn')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121090605_AppUserIn')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Firstname] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121090605_AppUserIn')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Lastname] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121090605_AppUserIn')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Organization] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231121090605_AppUserIn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231121090605_AppUserIn', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[teamregies]') AND [c].[name] = N'Name');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [teamregies] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [teamregies] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
    ALTER TABLE [teamregies] ADD DEFAULT N'' FOR [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[teamregies]') AND [c].[name] = N'Emailadress');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [teamregies] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [teamregies] ALTER COLUMN [Emailadress] nvarchar(max) NOT NULL;
    ALTER TABLE [teamregies] ADD DEFAULT N'' FOR [Emailadress];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[partners]') AND [c].[name] = N'partnerName');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [partners] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [partners] ALTER COLUMN [partnerName] nvarchar(max) NOT NULL;
    ALTER TABLE [partners] ADD DEFAULT N'' FOR [partnerName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[partners]') AND [c].[name] = N'partnerLink');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [partners] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [partners] ALTER COLUMN [partnerLink] nvarchar(max) NOT NULL;
    ALTER TABLE [partners] ADD DEFAULT N'' FOR [partnerLink];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[partners]') AND [c].[name] = N'partnerImage');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [partners] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [partners] ALTER COLUMN [partnerImage] varbinary(max) NOT NULL;
    ALTER TABLE [partners] ADD DEFAULT 0x FOR [partnerImage];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[partners]') AND [c].[name] = N'partnerAlt');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [partners] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [partners] ALTER COLUMN [partnerAlt] nvarchar(max) NOT NULL;
    ALTER TABLE [partners] ADD DEFAULT N'' FOR [partnerAlt];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentShortText');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentShortText] nvarchar(max) NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT N'' FOR [experimentShortText];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentPublished');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentPublished] bit NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT CAST(0 AS bit) FOR [experimentPublished];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentName');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentName] nvarchar(max) NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT N'' FOR [experimentName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCardBackText');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentCardBackText] nvarchar(max) NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT N'' FOR [experimentCardBackText];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[categories]') AND [c].[name] = N'name');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [categories] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [categories] ALTER COLUMN [name] nvarchar(max) NOT NULL;
    ALTER TABLE [categories] ADD DEFAULT N'' FOR [name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231127132846_changedIdentityUserToAppUserInUserExperimenten')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231127132846_changedIdentityUserToAppUserInUserExperimenten', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[teamregies]') AND [c].[name] = N'Name');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [teamregies] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [teamregies] ALTER COLUMN [Name] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[teamregies]') AND [c].[name] = N'Emailadress');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [teamregies] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [teamregies] ALTER COLUMN [Emailadress] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[partners]') AND [c].[name] = N'partnerName');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [partners] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [partners] ALTER COLUMN [partnerName] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[partners]') AND [c].[name] = N'partnerLink');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [partners] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [partners] ALTER COLUMN [partnerLink] nvarchar(100) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[partners]') AND [c].[name] = N'partnerAlt');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [partners] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [partners] ALTER COLUMN [partnerAlt] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentName');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentName] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCardBackText');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentCardBackText] nvarchar(200) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Lastname');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [Lastname] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Firstname');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [Firstname] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128082624_updatededModelValidation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128082624_updatededModelValidation', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128083643_test1')
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentName');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentName] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128083643_test1')
BEGIN
    DECLARE @var36 sysname;
    SELECT @var36 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCardBackText');
    IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var36 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentCardBackText] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128083643_test1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128083643_test1', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128083822_test2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128083822_test2', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084153_test3')
BEGIN
    DECLARE @var37 sysname;
    SELECT @var37 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentShortText');
    IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var37 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentShortText] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084153_test3')
BEGIN
    DECLARE @var38 sysname;
    SELECT @var38 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentName');
    IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var38 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084153_test3')
BEGIN
    DECLARE @var39 sysname;
    SELECT @var39 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCardBackText');
    IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var39 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentCardBackText] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084153_test3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128084153_test3', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084426_test4')
BEGIN
    DECLARE @var40 sysname;
    SELECT @var40 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentShortText');
    IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var40 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentShortText] nvarchar(max) NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT N'' FOR [experimentShortText];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084426_test4')
BEGIN
    DECLARE @var41 sysname;
    SELECT @var41 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentName');
    IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var41 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentName] nvarchar(max) NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT N'' FOR [experimentName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084426_test4')
BEGIN
    DECLARE @var42 sysname;
    SELECT @var42 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentImage');
    IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var42 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentImage] varbinary(max) NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT 0x FOR [experimentImage];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084426_test4')
BEGIN
    DECLARE @var43 sysname;
    SELECT @var43 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCardBackText');
    IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var43 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentCardBackText] nvarchar(max) NOT NULL;
    ALTER TABLE [experiments] ADD DEFAULT N'' FOR [experimentCardBackText];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128084426_test4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128084426_test4', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128085314_test5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128085314_test5', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128085815_test6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128085815_test6', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128094531_test7')
BEGIN
    DECLARE @var44 sysname;
    SELECT @var44 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentName');
    IF @var44 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var44 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentName] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128094531_test7')
BEGIN
    DECLARE @var45 sysname;
    SELECT @var45 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[experiments]') AND [c].[name] = N'experimentCardBackText');
    IF @var45 IS NOT NULL EXEC(N'ALTER TABLE [experiments] DROP CONSTRAINT [' + @var45 + '];');
    ALTER TABLE [experiments] ALTER COLUMN [experimentCardBackText] nvarchar(200) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231128094531_test7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231128094531_test7', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204090425_test8')
BEGIN
    ALTER TABLE [userexperimenten] DROP CONSTRAINT [FK_userexperimenten_AspNetUsers_UserId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204090425_test8')
BEGIN
    ALTER TABLE [userexperimenten] DROP CONSTRAINT [FK_userexperimenten_experiments_ExperimentId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204090425_test8')
BEGIN
    DECLARE @var46 sysname;
    SELECT @var46 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[userexperimenten]') AND [c].[name] = N'UserId');
    IF @var46 IS NOT NULL EXEC(N'ALTER TABLE [userexperimenten] DROP CONSTRAINT [' + @var46 + '];');
    ALTER TABLE [userexperimenten] ALTER COLUMN [UserId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204090425_test8')
BEGIN
    DECLARE @var47 sysname;
    SELECT @var47 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[userexperimenten]') AND [c].[name] = N'ExperimentId');
    IF @var47 IS NOT NULL EXEC(N'ALTER TABLE [userexperimenten] DROP CONSTRAINT [' + @var47 + '];');
    ALTER TABLE [userexperimenten] ALTER COLUMN [ExperimentId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204090425_test8')
BEGIN
    ALTER TABLE [userexperimenten] ADD CONSTRAINT [FK_userexperimenten_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204090425_test8')
BEGIN
    ALTER TABLE [userexperimenten] ADD CONSTRAINT [FK_userexperimenten_experiments_ExperimentId] FOREIGN KEY ([ExperimentId]) REFERENCES [experiments] ([experimentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204090425_test8')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231204090425_test8', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204121802_test9')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231204121802_test9', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204131422_addedcascadedelete')
BEGIN
    ALTER TABLE [userexperimenten] DROP CONSTRAINT [FK_userexperimenten_experiments_ExperimentId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204131422_addedcascadedelete')
BEGIN
    ALTER TABLE [userexperimenten] ADD CONSTRAINT [FK_userexperimenten_experiments_ExperimentId] FOREIGN KEY ([ExperimentId]) REFERENCES [experiments] ([experimentId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231204131422_addedcascadedelete')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231204131422_addedcascadedelete', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231211083641_changedpartnerstuff')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231211083641_changedpartnerstuff', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231219135609_goingonline')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231219135609_goingonline', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240212140847_test')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240212140847_test', N'6.0.23');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240213101610_test002')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240213101610_test002', N'6.0.23');
END;
GO

COMMIT;
GO

