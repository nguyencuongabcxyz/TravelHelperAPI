IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
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
        [Discriminator] nvarchar(max) NOT NULL,
        [FullName] nvarchar(150) NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317053541_FirstVersion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190317053541_FirstVersion', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [UserId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Country] (
        [CountryId] int NOT NULL IDENTITY,
        [Name] int NOT NULL,
        CONSTRAINT [PK_Country] PRIMARY KEY ([CountryId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Gender] bit NOT NULL,
        [Birthday] datetime2 NOT NULL,
        [Occupation] nvarchar(max) NULL,
        [FluentLanguage] nvarchar(max) NULL,
        [LearningLanguage] nvarchar(max) NULL,
        [About] nvarchar(max) NULL,
        [Interest] nvarchar(max) NULL,
        [Status] bit NULL,
        [IsActive] bit NULL,
        [IsDeleted] bit NULL,
        [CreateDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Cities] (
        [CityId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [CountryId] int NOT NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([CityId]),
        CONSTRAINT [FK_Cities_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Contacts] (
        [ContactId] int NOT NULL IDENTITY,
        [Facebook] nvarchar(max) NULL,
        [Skype] nvarchar(max) NULL,
        [Twitter] nvarchar(max) NULL,
        [WhatsApp] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Other] nvarchar(max) NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([ContactId]),
        CONSTRAINT [FK_Contacts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [FriendRequests] (
        [FriendRequestId] int NOT NULL IDENTITY,
        [CreateDate] datetime2 NOT NULL,
        [Message] nvarchar(max) NULL,
        [IsAccepted] bit NULL,
        [SenderUserId] int NULL,
        [ReceiverUserId] int NULL,
        CONSTRAINT [PK_FriendRequests] PRIMARY KEY ([FriendRequestId]),
        CONSTRAINT [FK_FriendRequests_Users_ReceiverUserId] FOREIGN KEY ([ReceiverUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_FriendRequests_Users_SenderUserId] FOREIGN KEY ([SenderUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Friends] (
        [FriendId] int NOT NULL IDENTITY,
        [IsDeleted] bit NULL,
        [CreateDate] datetime2 NOT NULL,
        [User1UserId] int NULL,
        [User2UserId] int NULL,
        CONSTRAINT [PK_Friends] PRIMARY KEY ([FriendId]),
        CONSTRAINT [FK_Friends_Users_User1UserId] FOREIGN KEY ([User1UserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Friends_Users_User2UserId] FOREIGN KEY ([User2UserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Homes] (
        [HomeId] int NOT NULL IDENTITY,
        [MaxGuest] int NULL,
        [PreferedGender] nvarchar(max) NULL,
        [SleepingArrangement] nvarchar(max) NULL,
        [SleepingDescription] nvarchar(max) NULL,
        [TransportationAccess] nvarchar(max) NULL,
        [AllowedThing] nvarchar(max) NULL,
        [Stuff] nvarchar(max) NULL,
        [AdditionInfo] nvarchar(max) NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Homes] PRIMARY KEY ([HomeId]),
        CONSTRAINT [FK_Homes_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [HostOffers] (
        [HostOfferId] int NOT NULL IDENTITY,
        [ArrivalTime] datetime2 NOT NULL,
        [DepartureTime] datetime2 NOT NULL,
        [TravelerNumber] int NULL,
        [Message] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [IsAccepted] bit NULL,
        [IsDeleted] bit NULL,
        [HostUserId] int NULL,
        [TravelerUserId] int NULL,
        CONSTRAINT [PK_HostOffers] PRIMARY KEY ([HostOfferId]),
        CONSTRAINT [FK_HostOffers_Users_HostUserId] FOREIGN KEY ([HostUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_HostOffers_Users_TravelerUserId] FOREIGN KEY ([TravelerUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Messages] (
        [MessageId] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [SenderUserId] int NULL,
        [ReceiverUserId] int NULL,
        CONSTRAINT [PK_Messages] PRIMARY KEY ([MessageId]),
        CONSTRAINT [FK_Messages_Users_ReceiverUserId] FOREIGN KEY ([ReceiverUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Messages_Users_SenderUserId] FOREIGN KEY ([SenderUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Photos] (
        [PhotoId] int NOT NULL IDENTITY,
        [Location] nvarchar(max) NULL,
        [Descripton] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [IsDeleted] bit NULL,
        [IsAvatar] bit NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_Photos] PRIMARY KEY ([PhotoId]),
        CONSTRAINT [FK_Photos_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [PublicTrips] (
        [PublicTripId] int NOT NULL IDENTITY,
        [ArrivalDate] datetime2 NOT NULL,
        [Destination] nvarchar(max) NULL,
        [DepartureDate] datetime2 NOT NULL,
        [TravelerNumber] int NULL,
        [Description] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [IsDeleted] bit NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_PublicTrips] PRIMARY KEY ([PublicTripId]),
        CONSTRAINT [FK_PublicTrips_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [References] (
        [ReferenceId] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NULL,
        [Status] bit NULL,
        [CreateDate] datetime2 NOT NULL,
        [IsDeleted] bit NULL,
        [SenderUserId] int NULL,
        [ReceiverUserId] int NULL,
        CONSTRAINT [PK_References] PRIMARY KEY ([ReferenceId]),
        CONSTRAINT [FK_References_Users_ReceiverUserId] FOREIGN KEY ([ReceiverUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_References_Users_SenderUserId] FOREIGN KEY ([SenderUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [Reports] (
        [ReportId] int NOT NULL IDENTITY,
        [CreateDate] datetime2 NOT NULL,
        [Type] nvarchar(max) NULL,
        [Message] nvarchar(max) NULL,
        [IsDeleted] bit NULL,
        [IsSolved] bit NULL,
        [ReporterUserId] int NULL,
        [ViolatorUserId] int NULL,
        CONSTRAINT [PK_Reports] PRIMARY KEY ([ReportId]),
        CONSTRAINT [FK_Reports_Users_ReporterUserId] FOREIGN KEY ([ReporterUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Reports_Users_ViolatorUserId] FOREIGN KEY ([ViolatorUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE TABLE [TravelRequests] (
        [TravelRequestId] int NOT NULL IDENTITY,
        [ArrivalTime] datetime2 NOT NULL,
        [DepartureTime] datetime2 NOT NULL,
        [TravelerNumber] int NOT NULL,
        [Message] nvarchar(max) NULL,
        [CreateDate] datetime2 NOT NULL,
        [IsAccepted] bit NULL,
        [IsDeleted] bit NULL,
        [HostUserId] int NULL,
        [TravelerUserId] int NULL,
        CONSTRAINT [PK_TravelRequests] PRIMARY KEY ([TravelRequestId]),
        CONSTRAINT [FK_TravelRequests_Users_HostUserId] FOREIGN KEY ([HostUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_TravelRequests_Users_TravelerUserId] FOREIGN KEY ([TravelerUserId]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE UNIQUE INDEX [IX_AspNetUsers_UserId] ON [AspNetUsers] ([UserId]) WHERE [UserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Cities_CountryId] ON [Cities] ([CountryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE UNIQUE INDEX [IX_Contacts_UserId] ON [Contacts] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_FriendRequests_ReceiverUserId] ON [FriendRequests] ([ReceiverUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_FriendRequests_SenderUserId] ON [FriendRequests] ([SenderUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Friends_User1UserId] ON [Friends] ([User1UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Friends_User2UserId] ON [Friends] ([User2UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE UNIQUE INDEX [IX_Homes_UserId] ON [Homes] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_HostOffers_HostUserId] ON [HostOffers] ([HostUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_HostOffers_TravelerUserId] ON [HostOffers] ([TravelerUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Messages_ReceiverUserId] ON [Messages] ([ReceiverUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Messages_SenderUserId] ON [Messages] ([SenderUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Photos_UserId] ON [Photos] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_PublicTrips_UserId] ON [PublicTrips] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_References_ReceiverUserId] ON [References] ([ReceiverUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_References_SenderUserId] ON [References] ([SenderUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Reports_ReporterUserId] ON [Reports] ([ReporterUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_Reports_ViolatorUserId] ON [Reports] ([ViolatorUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_TravelRequests_HostUserId] ON [TravelRequests] ([HostUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    CREATE INDEX [IX_TravelRequests_TravelerUserId] ON [TravelRequests] ([TravelerUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317153713_2thVersion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190317153713_2thVersion', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317161331_TestMigration')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317161331_TestMigration')
BEGIN
    DROP INDEX [IX_AspNetUsers_UserId] ON [AspNetUsers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317161331_TestMigration')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'UserId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317161331_TestMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190317161331_TestMigration', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Contacts] DROP CONSTRAINT [FK_Contacts_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [FriendRequests] DROP CONSTRAINT [FK_FriendRequests_Users_ReceiverUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [FriendRequests] DROP CONSTRAINT [FK_FriendRequests_Users_SenderUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Friends] DROP CONSTRAINT [FK_Friends_Users_User1UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Friends] DROP CONSTRAINT [FK_Friends_Users_User2UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Homes] DROP CONSTRAINT [FK_Homes_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [HostOffers] DROP CONSTRAINT [FK_HostOffers_Users_HostUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [HostOffers] DROP CONSTRAINT [FK_HostOffers_Users_TravelerUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Messages] DROP CONSTRAINT [FK_Messages_Users_ReceiverUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Messages] DROP CONSTRAINT [FK_Messages_Users_SenderUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Photos] DROP CONSTRAINT [FK_Photos_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [PublicTrips] DROP CONSTRAINT [FK_PublicTrips_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [References] DROP CONSTRAINT [FK_References_Users_ReceiverUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [References] DROP CONSTRAINT [FK_References_Users_SenderUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Reports] DROP CONSTRAINT [FK_Reports_Users_ReporterUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Reports] DROP CONSTRAINT [FK_Reports_Users_ViolatorUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [TravelRequests] DROP CONSTRAINT [FK_TravelRequests_Users_HostUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [TravelRequests] DROP CONSTRAINT [FK_TravelRequests_Users_TravelerUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP TABLE [Users];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_TravelRequests_HostUserId] ON [TravelRequests];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_TravelRequests_TravelerUserId] ON [TravelRequests];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Reports_ReporterUserId] ON [Reports];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Reports_ViolatorUserId] ON [Reports];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_References_ReceiverUserId] ON [References];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_References_SenderUserId] ON [References];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_PublicTrips_UserId] ON [PublicTrips];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Photos_UserId] ON [Photos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Messages_ReceiverUserId] ON [Messages];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Messages_SenderUserId] ON [Messages];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_HostOffers_HostUserId] ON [HostOffers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_HostOffers_TravelerUserId] ON [HostOffers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Homes_UserId] ON [Homes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Friends_User1UserId] ON [Friends];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Friends_User2UserId] ON [Friends];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_FriendRequests_ReceiverUserId] ON [FriendRequests];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_FriendRequests_SenderUserId] ON [FriendRequests];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DROP INDEX [IX_Contacts_UserId] ON [Contacts];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TravelRequests]') AND [c].[name] = N'HostUserId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TravelRequests] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [TravelRequests] DROP COLUMN [HostUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TravelRequests]') AND [c].[name] = N'TravelerUserId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [TravelRequests] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [TravelRequests] DROP COLUMN [TravelerUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reports]') AND [c].[name] = N'ReporterUserId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Reports] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Reports] DROP COLUMN [ReporterUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reports]') AND [c].[name] = N'ViolatorUserId');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Reports] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Reports] DROP COLUMN [ViolatorUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[References]') AND [c].[name] = N'ReceiverUserId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [References] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [References] DROP COLUMN [ReceiverUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[References]') AND [c].[name] = N'SenderUserId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [References] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [References] DROP COLUMN [SenderUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicTrips]') AND [c].[name] = N'UserId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [PublicTrips] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [PublicTrips] DROP COLUMN [UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Photos]') AND [c].[name] = N'UserId');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Photos] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Photos] DROP COLUMN [UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Messages]') AND [c].[name] = N'ReceiverUserId');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Messages] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Messages] DROP COLUMN [ReceiverUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Messages]') AND [c].[name] = N'SenderUserId');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Messages] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Messages] DROP COLUMN [SenderUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HostOffers]') AND [c].[name] = N'HostUserId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [HostOffers] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [HostOffers] DROP COLUMN [HostUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HostOffers]') AND [c].[name] = N'TravelerUserId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [HostOffers] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [HostOffers] DROP COLUMN [TravelerUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Homes]') AND [c].[name] = N'UserId');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Homes] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Homes] DROP COLUMN [UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Friends]') AND [c].[name] = N'User1UserId');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Friends] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Friends] DROP COLUMN [User1UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Friends]') AND [c].[name] = N'User2UserId');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Friends] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Friends] DROP COLUMN [User2UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[FriendRequests]') AND [c].[name] = N'ReceiverUserId');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [FriendRequests] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [FriendRequests] DROP COLUMN [ReceiverUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[FriendRequests]') AND [c].[name] = N'SenderUserId');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [FriendRequests] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [FriendRequests] DROP COLUMN [SenderUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'UserId');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Contacts] DROP COLUMN [UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [TravelRequests] ADD [HostId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [TravelRequests] ADD [TravelerId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Reports] ADD [ReporterId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Reports] ADD [ViolatorId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [References] ADD [ReceiverId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [References] ADD [SenderId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [PublicTrips] ADD [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Photos] ADD [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Messages] ADD [ReceiverId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Messages] ADD [SenderId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [HostOffers] ADD [HostId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [HostOffers] ADD [TravelerId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Homes] ADD [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Friends] ADD [ApplicationUser1Id] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Friends] ADD [ApplicationUser2Id] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [FriendRequests] ADD [ReceiverId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [FriendRequests] ADD [SenderId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Contacts] ADD [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE TABLE [UserProfiles] (
        [UserProfileId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Gender] bit NOT NULL,
        [Birthday] datetime2 NOT NULL,
        [Occupation] nvarchar(max) NULL,
        [FluentLanguage] nvarchar(max) NULL,
        [LearningLanguage] nvarchar(max) NULL,
        [About] nvarchar(max) NULL,
        [Interest] nvarchar(max) NULL,
        [Status] bit NULL,
        [IsActive] bit NULL,
        [IsDeleted] bit NULL,
        [CreateDate] datetime2 NOT NULL,
        [ApplicationUserId] nvarchar(450) NULL,
        CONSTRAINT [PK_UserProfiles] PRIMARY KEY ([UserProfileId]),
        CONSTRAINT [FK_UserProfiles_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_TravelRequests_HostId] ON [TravelRequests] ([HostId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_TravelRequests_TravelerId] ON [TravelRequests] ([TravelerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_Reports_ReporterId] ON [Reports] ([ReporterId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_Reports_ViolatorId] ON [Reports] ([ViolatorId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_References_ReceiverId] ON [References] ([ReceiverId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_References_SenderId] ON [References] ([SenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_PublicTrips_ApplicationUserId] ON [PublicTrips] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_Photos_ApplicationUserId] ON [Photos] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_Messages_ReceiverId] ON [Messages] ([ReceiverId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_Messages_SenderId] ON [Messages] ([SenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_HostOffers_HostId] ON [HostOffers] ([HostId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_HostOffers_TravelerId] ON [HostOffers] ([TravelerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE UNIQUE INDEX [IX_Homes_ApplicationUserId] ON [Homes] ([ApplicationUserId]) WHERE [ApplicationUserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_Friends_ApplicationUser1Id] ON [Friends] ([ApplicationUser1Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_Friends_ApplicationUser2Id] ON [Friends] ([ApplicationUser2Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_FriendRequests_ReceiverId] ON [FriendRequests] ([ReceiverId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE INDEX [IX_FriendRequests_SenderId] ON [FriendRequests] ([SenderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE UNIQUE INDEX [IX_Contacts_ApplicationUserId] ON [Contacts] ([ApplicationUserId]) WHERE [ApplicationUserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    CREATE UNIQUE INDEX [IX_UserProfiles_ApplicationUserId] ON [UserProfiles] ([ApplicationUserId]) WHERE [ApplicationUserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Contacts] ADD CONSTRAINT [FK_Contacts_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [FriendRequests] ADD CONSTRAINT [FK_FriendRequests_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [FriendRequests] ADD CONSTRAINT [FK_FriendRequests_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Friends] ADD CONSTRAINT [FK_Friends_AspNetUsers_ApplicationUser1Id] FOREIGN KEY ([ApplicationUser1Id]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Friends] ADD CONSTRAINT [FK_Friends_AspNetUsers_ApplicationUser2Id] FOREIGN KEY ([ApplicationUser2Id]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Homes] ADD CONSTRAINT [FK_Homes_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [HostOffers] ADD CONSTRAINT [FK_HostOffers_AspNetUsers_HostId] FOREIGN KEY ([HostId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [HostOffers] ADD CONSTRAINT [FK_HostOffers_AspNetUsers_TravelerId] FOREIGN KEY ([TravelerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Messages] ADD CONSTRAINT [FK_Messages_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Messages] ADD CONSTRAINT [FK_Messages_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Photos] ADD CONSTRAINT [FK_Photos_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [PublicTrips] ADD CONSTRAINT [FK_PublicTrips_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [References] ADD CONSTRAINT [FK_References_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [References] ADD CONSTRAINT [FK_References_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Reports] ADD CONSTRAINT [FK_Reports_AspNetUsers_ReporterId] FOREIGN KEY ([ReporterId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [Reports] ADD CONSTRAINT [FK_Reports_AspNetUsers_ViolatorId] FOREIGN KEY ([ViolatorId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [TravelRequests] ADD CONSTRAINT [FK_TravelRequests_AspNetUsers_HostId] FOREIGN KEY ([HostId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    ALTER TABLE [TravelRequests] ADD CONSTRAINT [FK_TravelRequests_AspNetUsers_TravelerId] FOREIGN KEY ([TravelerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317163943_3thVersion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190317163943_3thVersion', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317164733_4thVersion')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserProfiles]') AND [c].[name] = N'CreateDate');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [UserProfiles] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [UserProfiles] DROP COLUMN [CreateDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317164733_4thVersion')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserProfiles]') AND [c].[name] = N'IsActive');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [UserProfiles] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [UserProfiles] DROP COLUMN [IsActive];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317164733_4thVersion')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserProfiles]') AND [c].[name] = N'IsDeleted');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [UserProfiles] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [UserProfiles] DROP COLUMN [IsDeleted];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317164733_4thVersion')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317164733_4thVersion')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [IsActive] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317164733_4thVersion')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [IsDeleted] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317164733_4thVersion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190317164733_4thVersion', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [Contacts] DROP CONSTRAINT [FK_Contacts_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [Homes] DROP CONSTRAINT [FK_Homes_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [Photos] DROP CONSTRAINT [FK_Photos_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [PublicTrips] DROP CONSTRAINT [FK_PublicTrips_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [UserProfiles] DROP CONSTRAINT [FK_UserProfiles_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DROP INDEX [IX_UserProfiles_ApplicationUserId] ON [UserProfiles];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DROP INDEX [IX_Homes_ApplicationUserId] ON [Homes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DROP INDEX [IX_Contacts_ApplicationUserId] ON [Contacts];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserProfiles]') AND [c].[name] = N'ApplicationUserId');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [UserProfiles] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [UserProfiles] ALTER COLUMN [ApplicationUserId] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DROP INDEX [IX_PublicTrips_ApplicationUserId] ON [PublicTrips];
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicTrips]') AND [c].[name] = N'ApplicationUserId');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [PublicTrips] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [PublicTrips] ALTER COLUMN [ApplicationUserId] nvarchar(450) NOT NULL;
    CREATE INDEX [IX_PublicTrips_ApplicationUserId] ON [PublicTrips] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DROP INDEX [IX_Photos_ApplicationUserId] ON [Photos];
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Photos]') AND [c].[name] = N'ApplicationUserId');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Photos] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Photos] ALTER COLUMN [ApplicationUserId] nvarchar(450) NOT NULL;
    CREATE INDEX [IX_Photos_ApplicationUserId] ON [Photos] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Homes]') AND [c].[name] = N'ApplicationUserId');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Homes] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Homes] ALTER COLUMN [ApplicationUserId] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'ApplicationUserId');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Contacts] ALTER COLUMN [ApplicationUserId] nvarchar(450) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    CREATE UNIQUE INDEX [IX_UserProfiles_ApplicationUserId] ON [UserProfiles] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    CREATE UNIQUE INDEX [IX_Homes_ApplicationUserId] ON [Homes] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    CREATE UNIQUE INDEX [IX_Contacts_ApplicationUserId] ON [Contacts] ([ApplicationUserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [Contacts] ADD CONSTRAINT [FK_Contacts_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [Homes] ADD CONSTRAINT [FK_Homes_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [Photos] ADD CONSTRAINT [FK_Photos_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [PublicTrips] ADD CONSTRAINT [FK_PublicTrips_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    ALTER TABLE [UserProfiles] ADD CONSTRAINT [FK_UserProfiles_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190317170249_AddRequireApplicationUserId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190317170249_AddRequireApplicationUserId', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318024919_5thVersion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190318024919_5thVersion', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318032542_RemoveRequired')
BEGIN
    ALTER TABLE [UserProfiles] DROP CONSTRAINT [FK_UserProfiles_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318032542_RemoveRequired')
BEGIN
    DROP INDEX [IX_UserProfiles_ApplicationUserId] ON [UserProfiles];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318032542_RemoveRequired')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserProfiles]') AND [c].[name] = N'ApplicationUserId');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [UserProfiles] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [UserProfiles] ALTER COLUMN [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318032542_RemoveRequired')
BEGIN
    CREATE UNIQUE INDEX [IX_UserProfiles_ApplicationUserId] ON [UserProfiles] ([ApplicationUserId]) WHERE [ApplicationUserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318032542_RemoveRequired')
BEGIN
    ALTER TABLE [UserProfiles] ADD CONSTRAINT [FK_UserProfiles_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318032542_RemoveRequired')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190318032542_RemoveRequired', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [Contacts] DROP CONSTRAINT [FK_Contacts_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [Homes] DROP CONSTRAINT [FK_Homes_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [Photos] DROP CONSTRAINT [FK_Photos_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [PublicTrips] DROP CONSTRAINT [FK_PublicTrips_AspNetUsers_ApplicationUserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DROP TABLE [UserProfiles];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DROP INDEX [IX_Homes_ApplicationUserId] ON [Homes];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DROP INDEX [IX_Contacts_ApplicationUserId] ON [Contacts];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TravelRequests]') AND [c].[name] = N'TravelerNumber');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [TravelRequests] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [TravelRequests] ALTER COLUMN [TravelerNumber] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TravelRequests]') AND [c].[name] = N'DepartureTime');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [TravelRequests] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [TravelRequests] ALTER COLUMN [DepartureTime] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TravelRequests]') AND [c].[name] = N'CreateDate');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [TravelRequests] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [TravelRequests] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TravelRequests]') AND [c].[name] = N'ArrivalTime');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [TravelRequests] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [TravelRequests] ALTER COLUMN [ArrivalTime] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reports]') AND [c].[name] = N'CreateDate');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Reports] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [Reports] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[References]') AND [c].[name] = N'CreateDate');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [References] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [References] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicTrips]') AND [c].[name] = N'DepartureDate');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [PublicTrips] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [PublicTrips] ALTER COLUMN [DepartureDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicTrips]') AND [c].[name] = N'CreateDate');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [PublicTrips] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [PublicTrips] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var36 sysname;
    SELECT @var36 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicTrips]') AND [c].[name] = N'ArrivalDate');
    IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [PublicTrips] DROP CONSTRAINT [' + @var36 + '];');
    ALTER TABLE [PublicTrips] ALTER COLUMN [ArrivalDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var37 sysname;
    SELECT @var37 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PublicTrips]') AND [c].[name] = N'ApplicationUserId');
    IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [PublicTrips] DROP CONSTRAINT [' + @var37 + '];');
    ALTER TABLE [PublicTrips] ALTER COLUMN [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var38 sysname;
    SELECT @var38 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Photos]') AND [c].[name] = N'CreateDate');
    IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [Photos] DROP CONSTRAINT [' + @var38 + '];');
    ALTER TABLE [Photos] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var39 sysname;
    SELECT @var39 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Photos]') AND [c].[name] = N'ApplicationUserId');
    IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [Photos] DROP CONSTRAINT [' + @var39 + '];');
    ALTER TABLE [Photos] ALTER COLUMN [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var40 sysname;
    SELECT @var40 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Messages]') AND [c].[name] = N'CreateDate');
    IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [Messages] DROP CONSTRAINT [' + @var40 + '];');
    ALTER TABLE [Messages] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var41 sysname;
    SELECT @var41 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HostOffers]') AND [c].[name] = N'CreateDate');
    IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [HostOffers] DROP CONSTRAINT [' + @var41 + '];');
    ALTER TABLE [HostOffers] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var42 sysname;
    SELECT @var42 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Homes]') AND [c].[name] = N'ApplicationUserId');
    IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [Homes] DROP CONSTRAINT [' + @var42 + '];');
    ALTER TABLE [Homes] ALTER COLUMN [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var43 sysname;
    SELECT @var43 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Friends]') AND [c].[name] = N'CreateDate');
    IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [Friends] DROP CONSTRAINT [' + @var43 + '];');
    ALTER TABLE [Friends] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var44 sysname;
    SELECT @var44 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[FriendRequests]') AND [c].[name] = N'CreateDate');
    IF @var44 IS NOT NULL EXEC(N'ALTER TABLE [FriendRequests] DROP CONSTRAINT [' + @var44 + '];');
    ALTER TABLE [FriendRequests] ALTER COLUMN [CreateDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    DECLARE @var45 sysname;
    SELECT @var45 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'ApplicationUserId');
    IF @var45 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var45 + '];');
    ALTER TABLE [Contacts] ALTER COLUMN [ApplicationUserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [About] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Address] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Birthday] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FluentLanguage] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Gender] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Interest] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LearningLanguage] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Occupation] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Status] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    CREATE UNIQUE INDEX [IX_Homes_ApplicationUserId] ON [Homes] ([ApplicationUserId]) WHERE [ApplicationUserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    CREATE UNIQUE INDEX [IX_Contacts_ApplicationUserId] ON [Contacts] ([ApplicationUserId]) WHERE [ApplicationUserId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [Contacts] ADD CONSTRAINT [FK_Contacts_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [Homes] ADD CONSTRAINT [FK_Homes_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [Photos] ADD CONSTRAINT [FK_Photos_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    ALTER TABLE [PublicTrips] ADD CONSTRAINT [FK_PublicTrips_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318073145_RemoveUserProfile')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190318073145_RemoveUserProfile', N'2.2.3-servicing-35854');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190319080803_ChangeDataTypeOfCountryName')
BEGIN
    DECLARE @var46 sysname;
    SELECT @var46 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Country]') AND [c].[name] = N'Name');
    IF @var46 IS NOT NULL EXEC(N'ALTER TABLE [Country] DROP CONSTRAINT [' + @var46 + '];');
    ALTER TABLE [Country] ALTER COLUMN [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190319080803_ChangeDataTypeOfCountryName')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190319080803_ChangeDataTypeOfCountryName', N'2.2.3-servicing-35854');
END;

GO

