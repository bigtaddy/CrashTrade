
/****** Object:  Database [CrashT]    Script Date: 08.11.15 22:34:29 ******/
CREATE DATABASE [CrashT]
 CONTAINMENT = NONE
USE [CrashT]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/*INSERT Manufactures*/
SET IDENTITY_INSERT [dbo].[Manufactures] ON
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (1, N'Audi', N'Audi')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (2, N'Bmw', N'Bmw')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (3, N'Alfa Romeo', N'Alfa Romeo')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (4, N'AC', N'AC')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (5, N'Acura', N'Acura')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (6, N'Aston Martin', N'Aston Martin')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (7, N'Bentley', N'Bentley')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (8, N'Brilliance', N'Brilliance')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (9, N'Buick', N'Buick')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (10, N'Cadillac', N'Cadillac')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (11, N'Chery', N'Chery')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (12, N'Chrysler', N'Chrysler')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (13, N'Cizeta', N'Cizeta')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (14, N'Citroen', N'Citroen')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (15, N'Dacia', N'Dacia')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (16, N'Daewoo', N'Daewoo')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (17, N'Daihatsu', N'Daihatsu')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (18, N'Daimler', N'Daimler')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (19, N'Dodge', N'Dodge')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (20, N'Ferrari', N'Ferrari')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (21, N'Fiat', N'Fiat')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (22, N'Ford', N'Ford')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (23, N'Geely', N'Geely')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (24, N'GMC', N'GMC')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (25, N'Great Wall', N'Great Wall')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (26, N'Honda', N'Honda')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (27, N'Hummer', N'Hummer')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (28, N'Hyundai', N'Hyundai')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (29, N'Infiniti', N'Infiniti')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (30, N'Isuzu', N'Isuzu')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (31, N'Jaguar', N'Jaguar')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (32, N'Jeep', N'Jeep')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (33, N'Kia', N'Kia')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (34, N'Lancia', N'Lancia')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (35, N'Land Rover', N'Land Rover')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (36, N'Lexus', N'Lexus')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (37, N'Lifan', N'Lifan')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (38, N'Lincoln', N'Lincoln')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (39, N'Mazda', N'Mazda')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (40, N'Mercedes', N'Mercedes')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (41, N'Mini', N'Mini')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (42, N'Mitsubishi', N'Mitsubishi')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (43, N'Nissan', N'Nissan')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (44, N'Oldsmobile', N'Oldsmobile')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (45, N'Opel', N'Opel')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (46, N'Peugeot', N'Peugeot')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (47, N'Plymouth', N'Plymouth')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (48, N'Pontiac', N'Pontiac')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (49, N'Porsche', N'Porsche')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (50, N'Porsche', N'Porsche')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (51, N'Rover', N'Rover')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (52, N'Saab', N'Saab')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (53, N'Scion', N'Scion')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (54, N'Seat', N'Seat')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (55, N'Skoda', N'Skoda')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (56, N'Smart', N'Smart')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (57, N'SsangYong', N'SsangYong')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (58, N'Subaru', N'Subaru')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (59, N'Suzuki', N'Suzuki')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (60, N'Toyota', N'Toyota')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (61, N'Volkswagen', N'Volkswagen')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (62, N'Volvo', N'Volvo')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (63, N'ВАЗ', N'ВАЗ')
INSERT [dbo].[Manufactures] ([Id], [Name], [Description]) VALUES (64, N'Chevrolet', N'Chevrolet')
SET IDENTITY_INSERT [dbo].[Manufactures] OFF
/*INSERT Manufactures*/


/****** Object:  Table [dbo].[Adverts]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adverts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleType] [bit] NOT NULL,
	[CoachworkRepairType] [bit] NOT NULL,
	[MechanicalRepairType] [bit] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ManufactureId] [int] NOT NULL,
	[CarModelId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[SweptVolume] [int] NULL,
	[Price] [int] NULL,
	[Contacts] [nvarchar](max) NULL,
	[FuelType] [int] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[TransmissionType] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Adverts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[RoleId] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[JoinDate] [datetime] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarModels]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ManufactureId] [int] NULL,
 CONSTRAINT [PK_dbo.CarModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/* INSERT [CarModels]*/
SET IDENTITY_INSERT [dbo].[CarModels] ON
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (1, N'A8', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (2, N'100', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (3, N'CL', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (4, N'CSX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (5, N'EL', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (6, N'Integra (RSX)', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (7, N'Integra Coupe (RSX Coupe)', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (8, N'MDX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (9, N'NSX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (10, N'NSX-T', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (11, N'RDX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (12, N'RL', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (13, N'RSX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (14, N'SLX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (15, N'TL', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (16, N'TSX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (17, N'ZDX', 5)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (18, N'145', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (19, N'146', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (20, N'147', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (21, N'155', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (22, N'156', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (23, N'159', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (24, N'164', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (25, N'166', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (26, N'Brera', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (27, N'GT Coupe', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (28, N'GTV', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (29, N'Spider', 3)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (30, N'A2', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (31, N'A3', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (32, N'A4', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (33, N'A5', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (34, N'A6', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (35, N'A8', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (36, N'Coupe', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (37, N'Q7', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (38, N'R8', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (39, N'TT', 1)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (40, N'1xx series', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (41, N'3xx series', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (42, N'5xx series', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (43, N'6xx series', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (44, N'Z8', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (45, N'7xx series', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (46, N'8xx series', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (47, N'X3', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (48, N'X5', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (49, N'Z1', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (50, N'Z3', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (51, N'Z4', 2)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (52, N'M1', 8)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (53, N'M2', 8)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (54, N'Arnage', 7)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (55, N'Azure', 7)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (56, N'Brooklands', 7)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (57, N'Continental', 7)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (58, N'Mulsanne', 7)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (59, N'Turbo R', 7)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (60, N'Century', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (61, N'LaCrosse', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (62, N'Lucerne', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (63, N'Skylark Coupe', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (64, N'Park Avenue', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (65, N'Rainer', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (66, N'Regal', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (67, N'Terraza', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (68, N'Rivera', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (69, N'Roadmaster', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (70, N'Skylark', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (71, N'Sedan', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (72, N'Allante', 9)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (73, N'Aveo', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (74, N'Blazer', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (75, N'Camaro', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (76, N'Captiva', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (77, N'Cobalt', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (78, N'Corvette', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (79, N'Cruze', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (80, N'Epica', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (81, N'Evanda', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (82, N'Express', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (83, N'Lacetti', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (84, N'Lanos', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (85, N'Niva', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (86, N'Orlando', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (87, N'Rezzo', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (88, N'Silverado', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (89, N'Spark', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (90, N'Tahoe', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (91, N'Tracker', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (92, N'TrailBlazer', 64)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (93, N'Amulet (A15)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (94, N'Arrizo 7', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (95, N'Bonus 3 (E3/A19)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (96, N'Bonus (A13)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (97, N'Fora (A21)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (98, N'IndiS (S18D)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (99, N'Kimo (A1)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (100, N'M11 (A3)', 11)
GO
print 'Processed 100 total records'
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (101, N'QQ6 (S21)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (102, N'Tiggo 5', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (103, N'Tiggo (T11)', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (104, N'Very', 11)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (105, N'200', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (106, N'300C', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (107, N'300C SRT8', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (108, N'300M', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (109, N'Cirrus', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (110, N'Concorde', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (111, N'Crossfire', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (112, N'Fifth Avenue', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (113, N'Intrepid', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (114, N'Le Baron', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (115, N'LHS', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (116, N'Neon', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (117, N'NEW Yorker', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (118, N'Pacifica', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (119, N'Prowler', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (120, N'PT Cruiser', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (121, N'Sebring', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (122, N'Stratus', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (123, N'Town & Country', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (124, N'Voyager', 12)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (125, N'Berlingo', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (126, N'C1', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (127, N'C2', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (128, N'C3', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (129, N'C4', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (130, N'C5', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (131, N'C8', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (132, N'Evasion', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (133, N'Saxo', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (134, N'Xantia', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (135, N'XM', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (136, N'Jumpy', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (137, N'C-Elysee', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (138, N'Jumper', 14)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (139, N'Matiz', 16)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (140, N'Nexia', 16)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (141, N'Avenger', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (142, N'Caravan', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (143, N'Intrepid', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (144, N'Nitro', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (145, N'Viper', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (146, N'Caliber', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (147, N'Charger', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (148, N'Magnum', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (149, N'Ram', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (150, N'Caliber', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (151, N'Durango', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (152, N'Neon', 19)
INSERT [dbo].[CarModels] ([Id], [Name], [ManufactureId]) VALUES (153, N'Stratus', 19)
SET IDENTITY_INSERT [dbo].[CarModels] OFF
/* INSERT [CarModels]*/


/****** Object:  Table [dbo].[ImageInfoes]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageInfoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[AdvertId] [int] NOT NULL,
	[SparePartAdvert_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ImageInfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufactures]    Script Date: 08.11.15 22:34:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufactures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Manufactures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
/****** Object:  Table [dbo].[SparePartAdverts]    Script Date: 05.01.16 22:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SparePartAdverts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ManufactureId] [int] NOT NULL,
	[CarModelId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[VIN] [nvarchar](max) NULL,
	[Contacts] [nvarchar](max) NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.SparePartAdverts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201511081930378_AutomaticMigration', N'ResourceMetadata.Data.Migrations.Configuration', 0x1F8B0800000000000400ED5D596FE4B8117E0F90FF20F4531278BB7D641713C3BD0BAF8FC4C9F8C0B467903C0D68896E0BABA357C78C8D20BF2C0FF949F90B2175F196488952B79DC100C6348F62A9EA63912C92C5FFFEFB3F273F3D8781F30526A91F47CBD9C17C7FE6C0C88D3D3F5A2F6779F6F8DDBBD94F3FFEF63727175EF8EC7CAACB1DE172A866942E674F59B6395E2C52F70986209D87BE9BC469FC98CDDD385C002F5E1CEEEFFF697170B08088C40CD1729C930F7994F9212C7EA09F6771E4C24D9683E03AF6609056E928675550756E4008D30D70E172F601A6719EB8F01A66C00319989FA33F33E734F00162660583C79903A228CE4086583DFE98C25596C4D17AB5410920B87FD94054EE110429AC3EE19814D7FD9AFD43FC350B52B126E5E669168786040F8E2AF12CF8EABD843C6BC487047881049DBDE0AF2E84B89C9D7A48DBD9CCE19B3A3E0B125C4C22E15229F3B2E69EA3C8DF6BE0815084FFED39677990E5095C4630CF1210EC3977F943E0BB7F832FF7F12F305A467910D0DC227E511E938092EE9278831A7EF9001FAB6FB8F266CE82ADB7E02B36D5A83AE5F75D45D9D1E1CCB9418D8387003660A064B1CAE204FE1946300119F4EE4096C124C23460214EA175AEAD1508206EAB6EF1E7380E2088246DB6D3398B81FBF4354E7EF90037C04F6C90BC86EE13887C1704F668DEFB59D01041BD0DD98E99730D9EDFC3689D3DA136C1F3CCB9F49FA157A754643F2246107696B32CC93B5B3987A99BF89BB25B8CDCD65902B1E26F9B96909181F7C86299CB1B44F923707137E84660075320297ADA503AFF8020194661F51559EB4F7190879023D45EEF2EF15DB31A6864C890F4D2D1357E99C380EE0B78209993444301A15127216A92307D70F84E8BE9AE766FC0177F5DD82C055866C85C074581F4C9DF54DF555AF2CFA4CC6512871FE2A0191E9AACCFABC2D4A32F89E5F9F72059C34C9FAFAB10ACE155F418A752CE9AECCFF5384558E3F39AB66BDE840235F3BACC519DB54D6E4C31417454AE4A7A741153016268B53157E60B5CE164153B459E8C8F9305993EB44E2A0892CCA71575DD6F138BEE8905FE3BBA296C1BB26CF5A4C67E28FA922C5F80AFB4D0201C33DC984399AAFE0DCD3B82E651A78D9DC3AF7C94EB857E7EB46BED22BDD0DF8C9F7DB0DF54FE86FC6EE45F22D293A0BF1CE18D570C4A5CD7B3B2A15337DE942BE776BD807CBAD92014150C96D3A11ECE0E96C4EB07F5888B101EDC7E926693A0FB3D98A8A1BFC67E845D0083DD011721F083D1D92D5A414BE7473F09618380BEEE9D3B90A65FE3C4FB0B489F46677D05DD3C41BD79958170337A6B774F71046FF2F0012653B6654D35F75FE34B34F2C7C945846B0DA6F73E767F89F3EC22F230C23F66AE08784D0256D839755D98A69708CCD03B8BF3281BE6B6C2867C1C73D1315ECA67811A0B767ECE275BCC6B4F4903E0870A4ED8C1EE735D94624A5A427428C88B99FA38DEC76B3FD263B52EAA66B52CD1C96A55CC94554C4C8FD3AAA49AD1A240279F65A941D3A37A968AE9151A6A9B205D375B4DA7E9E60666F3BAF6BCA47B99209A788F622E90DD73B42B9369D4A1EE34EAE8E0E1F1E8DDF73F00EFE8873FC2A3EFDFE23AA1D38F6C69BB036B8BF17E8FDAD22710E4B69BEA05FEA2CFDB077F4176F7C15F836BD15DB4F82294FCC5F7F060A551A32E8C3831EF62936D9FC8C61DF2995337CFC86CDCC67B75173CF4D8EF2D98EAEE7716CCA5666791F7AB6ED4D74D4C0DBB697A9B31E2ECA3ED7520EDB5B879265E4961942AF68C29F57EAE8A51AE472157743E8A45CCE6D77948E1971C1AB84A2F03B026A7CDCCBD90352DEBEE47A40534D0042F486BF45C96D5C535C4CE8A7A70825912A38AC5E40D814AD01C53FADC872924A50F45499632A3134FD33476FD4232DC2E0AB34FC2B67A11798ECE962139D441F6AAAF91A47CBCBA424A5DCEFE207C5107ED66714E6833FB392CF9FDF95C9419EAF530C1E003D85D97227DF951269A083F72FD0D083498E1EA6A1A18AC91A6153EE71C6E60847B88869C759AE7B697454E9A063923D825AC930585A07660F10760547A579E86212AAF373BF4C1A43A42A381D1035EC227B7D1390C60069D53B73C6F7A06521778A261455DCEB3003E05F313E04EA10B9D96E993735BC19BB037A6C2867AA38C8083DAA6D5079DFAF0541794B78F3915EF13804EA50F9DA6C9DEEB366D9CCED0D97672CD82A5EB3F686E1F7BEA4F98CEE4BDE68156BEB3A0044CC7360305467E8B5F63B6D5D98E049C125F792BFE07C8A6DACAD0E599DFD7184B36DCC6884236952B752CD9949B27BA2C733B29634986DD8A5108A6746358930BB567D86175D913BF16CC38BB23A92DD49DB1E134FFD3196F5A0D3AAD2ABDF293CC5345578A7242D9E257117B82AC1774F4B616AFCC085DAD74ED14D74DFCA87163345E1710A179203EB791C167D9E539D47CE5CC492BC716FF5998FC0A66FCB900E252E2BAA72017960075C0542041568F1D44A819828C0E3331EB2045DFEB1008512B960E3295FB4E940A6F63BAD8E1876D295BE2D86E40B63E79D04AB61A160DC856C7045AA99640EF20DA45484A84EA1D22D6D8E3CA54D1B663CDBC19D374D8355FC3405D308A9A2E3A8A1A8B797EC061BF5F4336C2552A512CADCE262D7713C57E63385A44A17230E9C8B48708C483BFA20CDA1D207A2E108A7DDADAB40842E9F4E816687F28747492AE65B9EEC2BC1F2626EE1C8A736512A968AC134D568AD43755434A9B6CDA578334EE24C38A7529D5034BB794642B469335E3202971EB428594EA8FB12EA56A78EB169264E968B0781C24227681A89050F521B6CC4F393D52DA1D71E5D8B976EC676998D5629714FB8C3A925D5FC9B8D3B1A0D15DD2501F20D597EECAC51206EAADE866BDD2E49D2CCA902955C2C942115BE5E41A6C367EB4A662AD5429CEAA0CB472F6DDCA3CFC4858D258B88C9CF9D555D35216276884E672F1AD7F0F16B748706C970780F7CECFBC5028A6589D29A6C575A3EC024CD4623D5DAECBE3FF73AB413AF4CC5C3EA121F2BC449F1862B740711654E84C62450787BD01014824873CCE70D08548ED9F50D7263149681A24559F92342A094D545A409FBE3C4409DD80BC847E0B55C0129A6495A44F83B9574A5362320CA44A428E30B224C90612643DFF8CE8DA37055AF8A3F65019065BF656D5D4CA1824349D32C500CF740C1206D274863EBD2A36094DA94A32E91975B412B63BD4A9FA94C821229A1249D5A754FB13693A2A1F231E2F38AB257821050329B86C597BAB658DC97274B83D56ADB3352CB2BAEA3836B93C4247D72F53A6E9E95BD235B3C61CAEEE9685B486C65B6BEFAAD2FB0E3D5B5238E5AC19AE6EE24A3657764BDD71544DAEF9B356BC4ED5A744CE92D094D4274CB6A66CD51ACB7856CD39FC7B4CAFBB288CA47372FB9D513A49D6A745EEB7D3A448AA3E2572819DA64452F5295537D869325592210DEA12B4408CCA3398C131F7D499891C936330C7642FA333B34C36CB804BFACA39C3249DD18B9E42A2F21206AB25E19239B37012720DF02D5E3767802E66F7A02DE199CF33B0C3E28D74C6208BD9663375B1B793D49DB1F1122FB885815DD88CED31C077D318C7E89B2DB294CB47720D97593F9264435AD5455B815895BE938052EE690C0154B90D3F0C500A1AE34282BB91CA1AB1D63BB96A9ACC3553D6DFA1BCB3BB23E050EDE50CC146710E621834E42454F2AFEF79D2A2575D2FB585AF2DE9CEB6BE06EACA4C4F532DF3C7D60DBB8BC46D832876E80D97674D3DE311196F9BF173ACD6AD7D517C5ACAE389CA8F5852CCF4E65379C2B437C85AF942537ACF2F8E705EA5F8066F73DBD4ECEBF9CDC6C148AA37FE4D9154D7331E8A3534C41E7FD85D24B1472B34F9341C10AC4F376C4E365E25E2AB4D7C53C057D54CE7171A30624EB2EC2EDA9953329A6C9ACDA1867798570148D991189399555DC70214D547697A8F8B14410B20549FD179B308EC106137FC8453477C9166265BA534BF9B5347D5899FEE679E842340659199538F1BCBD9EA25CD6058C278F56B7016F8103BDCEA02D720F21F619A95512F6687FB0787DC3351BBF364D3224D3D66D759F96E13ABB20902CAF858A69D61EC4C1F90E11E487AF0339B8F23F521D7F630521F7AF7F4A348D1179020F2C9EF42F0FC7B9A54CF08F683E8098F1BA1D10066D61E372A00235C90BA8A3CF8BC9CFDB3A879EC5CFDFD335379CFB94D509F3D76F69D7F59781849970752731003F48B4A45D3C3DF53E2C8680518A65F57EA519F7F6B6910C8F8F794FA88850D4C56B3A3A5D8B22AAB543E24969D70658A1832AFD532974E2A0B0018DF360C0802AA0E8AF17FAFB761A34D8FB746DE86FCF9173D06E9807FB543B7DBD4F50C06B3DE6F6A4CAE3662FF8D0CB94455FCFB148374C5BF41318818FFCE44EF9919F3CEC42096E46F49F49911CBDE9118C49AF4AD88411425EF41D8A2674584AAF71EFAD052BEF520039D564F90BEFDD08735E5BB0F7D67913D3BE88088FA6F635493CFC0FBAD3AF918F3C3A93171E4870DB812E76C8F5587484677056235A07D0FEC29BD8E62D1ADC682B7360990867AB746FD4E8CE46E8DF65BC1AAB893B0A391D8AD696E2428EF2020640315B7F9D083438EC68478ED8BD51D59F1589EFE0C0CD4CD044851859B320A1546A2EF48A3607545BAEB1554AEFDDE990E149C3E51B75F4FE44FCD10DB46BAB31A4B900F59D12B4AE2A008EED385217C6361B2B515361260A88076746435FDC0DC03E2584E1AF6FA8D05BAEE31F4BC119333F1706500D59D18AC0685A9B618625812925212BA91CA1DC7D0745EBEB56F7134AE7F492C8FD6E9C42D00C82C96F74800AA828F2A00A413B1FB95024875DDEB1501C828E0F948F82923C42AE0A3116CF995A24771C96897C1A31315BE3F64DEC814680BB0329806A9CFFDEE6EDC77DBA1DEB769743AAE18EE86C5D138056F1D2DDC99EFE6B0201FA291576E757D803DBEAC8E775F9EEF5ECEBC07BCA82E5D92AAD8CC3C71E22E12C8932C5903EA30D87C13CC0A516885C99535D41A58996F8BF223082D5179B2769A6C8D6604AB2FEA862F215552F18AAA3CACABF065E20246FC42B14C7BB38A40CC6D6D5773DFD6B6AB32ED6D2BC21BB7B55DDAB0D6A6CB22ED2DCB43C6AA1AEE68B4AB417963533E1620E97F420037D11ACADCCC5465E543195B7E07C08859E99C8AAAA7785064EB71FEB55955795EE91B6ACA074676228CFF50F08EA9D5E962F4B3FCB73FE8D2E51453DC4E94BFE2B2CB21F9AD088519CE14B7E5ED0B65AC08FC5644420F78F24BACD62C45C957EF88FB963E7E54CB3F6EAC7DA99E643A9A44DB06B1F5C5DBAC689D9547F8F06CF9EB1CA6FE9A90C0F77423E8322BACA60C1EBEEA151FC7515D44B8B258DEE43E4D321F0F23281B9F9BF5A375F3F0FA45F800BDABE836CF3679863E19860F0173080F2F18DBDA2F1E1060793EB92D6E87A4363E01B1E9E3F3C6B7D1CFB91F780DDF97929B0A0A1278255A1D79C5BACCF0D1D7F54B43E9268E340955E26B16D0F730DC0488587A1BADC017D8873704BFF7700DDC1772D25045A45B11ACD84FCE7DB04E40985634487DF41361D80B9F7FFC1FF969D1B6E1A70000, N'6.1.3-40302')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2caad033-66b6-45e0-88b7-7ee99ae8b7a0', N'Member')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3a6b9f36-66b6-41a5-8e0f-488c51b9f8e0', N'PremiumMember')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3a6b9f36-5ae6-41a5-8e0f-488c51b9f8e1', N'Admin')
INSERT [dbo].[AspNetUserRoles] ([RoleId], [UserId], [ApplicationUser_Id], [IdentityRole_Id]) VALUES (N'3a6b9f36-5ae6-41a5-8e0f-488c51b9f8e1', N'd07812ed-c538-47df-800e-1ed8fdfdb41c', NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [JoinDate], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd07812ed-c538-47df-800e-1ed8fdfdb41c', N'Admin', N'Admin', CAST(0x0000A54A00000000 AS DateTime), N'admin@admin.com', 1, N'ADhuM+V0nkib75E3VzNckif8ejWvNzPdDrpbiJWqPIxCs8zNyw2nglxcJZACo0hwQw==', N'58170240-9e77-43e6-941a-425fff404f5b', NULL, 0, 0, NULL, 0, 0, N'admin@admin.com')
/****** Object:  Index [IX_CarModelId]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_CarModelId] ON [dbo].[Adverts]
(
	[CarModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManufactureId]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_ManufactureId] ON [dbo].[Adverts]
(
	[ManufactureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Adverts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[AspNetUserClaims]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[AspNetUserLogins]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[AspNetUserRoles]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityRole_Id]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_IdentityRole_Id] ON [dbo].[AspNetUserRoles]
(
	[IdentityRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManufactureId]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_ManufactureId] ON [dbo].[CarModels]
(
	[ManufactureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AdvertId]    Script Date: 08.11.15 22:34:29 ******/
CREATE NONCLUSTERED INDEX [IX_AdvertId] ON [dbo].[ImageInfoes]
(
	[AdvertId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
/****** Object:  Index [IX_SparePartAdvert_Id]    Script Date: 05.01.16 22:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_SparePartAdvert_Id] ON [dbo].[ImageInfoes]
(
	[SparePartAdvert_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CarModelId]    Script Date: 05.01.16 22:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_CarModelId] ON [dbo].[SparePartAdverts]
(
	[CarModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ManufactureId]    Script Date: 05.01.16 22:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_ManufactureId] ON [dbo].[SparePartAdverts]
(
	[ManufactureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 05.01.16 22:47:35 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[SparePartAdverts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


GO
ALTER TABLE [dbo].[Adverts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Adverts_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Adverts] CHECK CONSTRAINT [FK_dbo.Adverts_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Adverts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Adverts_dbo.CarModels_CarModelId] FOREIGN KEY([CarModelId])
REFERENCES [dbo].[CarModels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Adverts] CHECK CONSTRAINT [FK_dbo.Adverts_dbo.CarModels_CarModelId]
GO
ALTER TABLE [dbo].[Adverts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Adverts_dbo.Manufactures_ManufactureId] FOREIGN KEY([ManufactureId])
REFERENCES [dbo].[Manufactures] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Adverts] CHECK CONSTRAINT [FK_dbo.Adverts_dbo.Manufactures_ManufactureId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_IdentityRole_Id]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[CarModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CarModels_dbo.Manufactures_ManufactureId] FOREIGN KEY([ManufactureId])
REFERENCES [dbo].[Manufactures] ([Id])
GO
ALTER TABLE [dbo].[CarModels] CHECK CONSTRAINT [FK_dbo.CarModels_dbo.Manufactures_ManufactureId]
GO
ALTER TABLE [dbo].[ImageInfoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageInfoes_dbo.Adverts_AdvertId] FOREIGN KEY([AdvertId])
REFERENCES [dbo].[Adverts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageInfoes] CHECK CONSTRAINT [FK_dbo.ImageInfoes_dbo.Adverts_AdvertId]

ALTER TABLE [dbo].[ImageInfoes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageInfoes_dbo.SparePartAdverts_SparePartAdvert_Id] FOREIGN KEY([SparePartAdvert_Id])
REFERENCES [dbo].[SparePartAdverts] ([Id])
GO
ALTER TABLE [dbo].[ImageInfoes] CHECK CONSTRAINT [FK_dbo.ImageInfoes_dbo.SparePartAdverts_SparePartAdvert_Id]
GO
ALTER TABLE [dbo].[SparePartAdverts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SparePartAdverts_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SparePartAdverts] CHECK CONSTRAINT [FK_dbo.SparePartAdverts_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[SparePartAdverts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SparePartAdverts_dbo.CarModels_CarModelId] FOREIGN KEY([CarModelId])
REFERENCES [dbo].[CarModels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SparePartAdverts] CHECK CONSTRAINT [FK_dbo.SparePartAdverts_dbo.CarModels_CarModelId]
GO
ALTER TABLE [dbo].[SparePartAdverts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SparePartAdverts_dbo.Manufactures_ManufactureId] FOREIGN KEY([ManufactureId])
REFERENCES [dbo].[Manufactures] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SparePartAdverts] CHECK CONSTRAINT [FK_dbo.SparePartAdverts_dbo.Manufactures_ManufactureId]

GO
USE [master]
GO
ALTER DATABASE [CrashT] SET  READ_WRITE 
GO
