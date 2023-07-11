# PracticalExerciseBNR

1. Pentru a adauga toate using-urile intr-un fisier global, nu uita sa prefixezi fiecare using din globals.cs cu cuvantul cheie "global"; Se pot scoate celelalte using-uri din fisierele folosite in proiect.

Procesul de scaffolding 
1. se instaleaza EF: dotnet tool install --global dotnet-ef
2. se adauga package-urile: 
 - dotnet add package Microsoft.EntityFrameworkCore.Design
 - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
 - dotnet add package Microsoft.EntityFrameworkCore.Tools
 Comanda pentru crearea modelelor:
 - dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=testscursnetcore;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer (--force)
 - dotnet new install Microsoft.EntityFrameworkCore.Templates
 - dotnet new ef-templates
 
 
 3. db script: schema and data -> DB_script.sql.bak
 
 -------------------------------SQL script ----------------------------------
 USE [testscursnetcore]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 7/11/2023 1:34:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[IDBank] [int] IDENTITY(1,1) NOT NULL,
	[NameBank] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[IDBank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/11/2023 1:34:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IDCustomer] [int] IDENTITY(1,1) NOT NULL,
	[NameCustomer] [nvarchar](100) NOT NULL,
	[IDBank] [int] NOT NULL,
	[CurrentAmount] [int] NOT NULL,
	[CreditAmount] [int] NULL,
	[DepositAmount] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[IDCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (1, N'BCR')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (2, N'Banca Transilvania')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (3, N'BRD')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (4, N'OTP Bank')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (5, N'Reiffeisen')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (6, N'Alpha Bank')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (7, N'Banca Romaneasca')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (8, N'CEC Bank')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (9, N'Libra Bank')
INSERT [dbo].[Bank] ([IDBank], [NameBank]) VALUES (10, N'ING Bank')
SET IDENTITY_INSERT [dbo].[Bank] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([IDCustomer], [NameCustomer], [IDBank], [CurrentAmount], [CreditAmount], [DepositAmount]) VALUES (2, N'Customer1', 2, 54000, 12000, 500)
INSERT [dbo].[Customer] ([IDCustomer], [NameCustomer], [IDBank], [CurrentAmount], [CreditAmount], [DepositAmount]) VALUES (3, N'Customer1', 10, 0, 5000, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [NameCustomer], [IDBank], [CurrentAmount], [CreditAmount], [DepositAmount]) VALUES (4, N'Customer2', 10, 98, 25000, 54000)
INSERT [dbo].[Customer] ([IDCustomer], [NameCustomer], [IDBank], [CurrentAmount], [CreditAmount], [DepositAmount]) VALUES (5, N'Customer 3', 5, 100, 120, 150)
INSERT [dbo].[Customer] ([IDCustomer], [NameCustomer], [IDBank], [CurrentAmount], [CreditAmount], [DepositAmount]) VALUES (7, N'Customer4', 1, 500, 500, 234)
INSERT [dbo].[Customer] ([IDCustomer], [NameCustomer], [IDBank], [CurrentAmount], [CreditAmount], [DepositAmount]) VALUES (8, N'Customer5', 5, 1234, 1560, 2340)
INSERT [dbo].[Customer] ([IDCustomer], [NameCustomer], [IDBank], [CurrentAmount], [CreditAmount], [DepositAmount]) VALUES (9, N'Customer5', 3, 500, 560, 900)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Bank] FOREIGN KEY([IDBank])
REFERENCES [dbo].[Bank] ([IDBank])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Bank]
GO
