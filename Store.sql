USE [master]
GO
/****** Object:  Database [Store]    Script Date: 10.07.2017 20:16:51 ******/
CREATE DATABASE [Store] 
GO
USE [Store]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1.09.2017 19:03:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 1.09.2017 19:03:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Audit] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 1.09.2017 19:03:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Details] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[StockQuantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1.09.2017 19:03:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 1.09.2017 19:03:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 1.09.2017 19:03:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (1, N'Beverages', N'Soft drinks, coffees, teas, beers, and ales')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (2, N'Condiments', N'Sweet and savory sauces, relishes, spreads, and seasonings')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (3, N'Confections', N'Desserts, candies, and sweet breads')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (4, N'Dairy Products', N'Cheeses')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (5, N'Grains/Cereals', N'Breads, crackers, pasta, and cereal')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (6, N'Meat/Poultry', N'Prepared meats')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (7, N'Produce', N'Dried fruit and bean curd')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (8, N'Seafood', N'Seaweed and fish')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON 

GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (1, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T16:25:35.897' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (2, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T17:54:31.207' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (3, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T17:55:29.577' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (4, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T17:56:03.137' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (5, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T17:58:46.810' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (6, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:00:04.400' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (7, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:03:45.257' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (8, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:05:37.417' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (9, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:06:14.770' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (10, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:12:55.073' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (11, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:14:09.977' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (12, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:14:53.280' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (13, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:18:52.667' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (14, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:20:43.460' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (15, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T18:21:51.917' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (16, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T19:25:31.513' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (17, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T19:25:56.940' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (18, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-28T19:27:06.043' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (19, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T14:26:06.847' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (20, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T15:02:19.587' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (21, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T15:03:11.310' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (22, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T15:37:54.870' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (23, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T15:50:55.343' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (24, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T15:52:39.737' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (25, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T17:26:31.200' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (26, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T17:28:46.727' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (27, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T17:49:58.310' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (28, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T19:33:30.367' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (29, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T19:34:31.700' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (30, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T19:35:04.430' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (31, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T19:48:24.313' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (32, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T20:53:40.263' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (33, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T20:54:36.453' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (34, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T20:57:59.747' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (35, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T21:14:01.853' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (36, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T21:19:39.993' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (37, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T21:27:51.567' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (38, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T21:50:30.737' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (39, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T21:52:02.543' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (40, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T21:54:06.517' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (41, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T21:56:55.557' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (42, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T22:06:48.163' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (43, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T22:23:01.863' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (44, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T22:27:57.980' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (45, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T22:32:55.547' AS DateTime), N'INFO')
GO
INSERT [dbo].[Logs] ([Id], [Detail], [Date], [Audit]) VALUES (46, N'{
  "UserName": "DESKTOP-FDQK07P\\DEVELOPER",
  "MessageObject": {
    "FullName": "ProductService",
    "MethodName": "GetAll",
    "Parameters": [
      {
        "Name": "predicate",
        "Type": "Expression`1",
        "Value": null
      }
    ]
  }
}
', CAST(N'2017-08-31T22:33:25.903' AS DateTime), N'INFO')
GO
SET IDENTITY_INSERT [dbo].[Logs] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (2, 1, N'Chai', N'Chai', CAST(18.00 AS Decimal(18, 2)), 39)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (3, 1, N'Chang', N'Chang', CAST(19.00 AS Decimal(18, 2)), 17)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (4, 2, N'Aniseed Syrup', N'Aniseed Syrup', CAST(10.00 AS Decimal(18, 2)), 13)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (5, 2, N'Chef Anton''s Cajun Seasoning', N'Chef Anton''s Cajun Seasoning', CAST(22.00 AS Decimal(18, 2)), 53)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (6, 2, N'Chef Anton''s Gumbo Mix', N'Chef Anton''s Gumbo Mix', CAST(21.35 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (7, 2, N'Grandma''s Boysenberry Spread', N'Grandma''s Boysenberry Spread', CAST(25.00 AS Decimal(18, 2)), 120)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (8, 7, N'Uncle Bob''s Organic Dried Pears', N'Uncle Bob''s Organic Dried Pears', CAST(30.00 AS Decimal(18, 2)), 15)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (9, 2, N'Northwoods Cranberry Sauce', N'Northwoods Cranberry Sauce', CAST(40.00 AS Decimal(18, 2)), 6)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (10, 6, N'Mishi Kobe Niku', N'Mishi Kobe Niku', CAST(97.00 AS Decimal(18, 2)), 29)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (11, 8, N'Ikura', N'Ikura', CAST(31.00 AS Decimal(18, 2)), 31)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (12, 4, N'Queso Cabrales', N'Queso Cabrales', CAST(21.00 AS Decimal(18, 2)), 22)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (13, 4, N'Queso Manchego La Pastora', N'Queso Manchego La Pastora', CAST(38.00 AS Decimal(18, 2)), 86)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (14, 8, N'Konbu', N'Konbu', CAST(6.00 AS Decimal(18, 2)), 24)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (15, 7, N'Tofu', N'Tofu', CAST(23.25 AS Decimal(18, 2)), 35)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (16, 2, N'Genen Shouyu', N'Genen Shouyu', CAST(15.50 AS Decimal(18, 2)), 39)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (17, 3, N'Pavlova', N'Pavlova', CAST(17.45 AS Decimal(18, 2)), 29)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (18, 6, N'Alice Mutton', N'Alice Mutton', CAST(39.00 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (19, 8, N'Carnarvon Tigers', N'Carnarvon Tigers', CAST(62.50 AS Decimal(18, 2)), 42)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (20, 3, N'Teatime Chocolate Biscuits', N'Teatime Chocolate Biscuits', CAST(9.20 AS Decimal(18, 2)), 25)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (21, 3, N'Sir Rodney''s Marmalade', N'Sir Rodney''s Marmalade', CAST(81.00 AS Decimal(18, 2)), 40)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (22, 3, N'Sir Rodney''s Scones', N'Sir Rodney''s Scones', CAST(10.00 AS Decimal(18, 2)), 3)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (23, 5, N'Gustaf''s Knäckebröd', N'Gustaf''s Knäckebröd', CAST(21.00 AS Decimal(18, 2)), 104)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (24, 5, N'Tunnbröd', N'Tunnbröd', CAST(9.00 AS Decimal(18, 2)), 61)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (25, 1, N'Guaraná Fantástica', N'Guaraná Fantástica', CAST(4.50 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (26, 3, N'NuNuCa Nuß-Nougat-Creme', N'NuNuCa Nuß-Nougat-Creme', CAST(14.00 AS Decimal(18, 2)), 76)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (27, 3, N'Gumbär Gummibärchen', N'Gumbär Gummibärchen', CAST(31.23 AS Decimal(18, 2)), 15)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (28, 3, N'Schoggi Schokolade', N'Schoggi Schokolade', CAST(43.90 AS Decimal(18, 2)), 49)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (29, 7, N'Rössle Sauerkraut', N'Rössle Sauerkraut', CAST(45.60 AS Decimal(18, 2)), 26)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (30, 6, N'Thüringer Rostbratwurst', N'Thüringer Rostbratwurst', CAST(123.79 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (31, 8, N'Nord-Ost Matjeshering', N'Nord-Ost Matjeshering', CAST(25.89 AS Decimal(18, 2)), 10)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (32, 4, N'Gorgonzola Telino', N'Gorgonzola Telino', CAST(12.50 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (33, 4, N'Mascarpone Fabioli', N'Mascarpone Fabioli', CAST(32.00 AS Decimal(18, 2)), 9)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (34, 4, N'Geitost', N'Geitost', CAST(2.50 AS Decimal(18, 2)), 112)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (35, 1, N'Sasquatch Ale', N'Sasquatch Ale', CAST(14.00 AS Decimal(18, 2)), 111)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (36, 1, N'Steeleye Stout', N'Steeleye Stout', CAST(18.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (37, 8, N'Inlagd Sill', N'Inlagd Sill', CAST(19.00 AS Decimal(18, 2)), 112)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (38, 8, N'Gravad lax', N'Gravad lax', CAST(26.00 AS Decimal(18, 2)), 11)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (39, 1, N'Côte de Blaye', N'Côte de Blaye', CAST(263.50 AS Decimal(18, 2)), 17)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (40, 1, N'Chartreuse verte', N'Chartreuse verte', CAST(18.00 AS Decimal(18, 2)), 69)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (41, 8, N'Boston Crab Meat', N'Boston Crab Meat', CAST(18.40 AS Decimal(18, 2)), 123)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (42, 8, N'Jack''s New England Clam Chowder', N'Jack''s New England Clam Chowder', CAST(9.65 AS Decimal(18, 2)), 85)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (43, 5, N'Singaporean Hokkien Fried Mee', N'Singaporean Hokkien Fried Mee', CAST(14.00 AS Decimal(18, 2)), 26)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (44, 1, N'Ipoh Coffee', N'Ipoh Coffee', CAST(46.00 AS Decimal(18, 2)), 17)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (45, 2, N'Gula Malacca', N'Gula Malacca', CAST(19.45 AS Decimal(18, 2)), 27)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (46, 8, N'Rogede sild', N'Rogede sild', CAST(9.50 AS Decimal(18, 2)), 5)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (47, 8, N'Spegesild', N'Spegesild', CAST(12.00 AS Decimal(18, 2)), 95)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (48, 3, N'Zaanse koeken', N'Zaanse koeken', CAST(9.50 AS Decimal(18, 2)), 36)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (49, 3, N'Chocolade', N'Chocolade', CAST(12.75 AS Decimal(18, 2)), 15)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (50, 3, N'Maxilaku', N'Maxilaku', CAST(20.00 AS Decimal(18, 2)), 10)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (51, 3, N'Valkoinen suklaa', N'Valkoinen suklaa', CAST(16.25 AS Decimal(18, 2)), 65)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (52, 7, N'Manjimup Dried Apples', N'Manjimup Dried Apples', CAST(53.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (53, 5, N'Filo Mix', N'Filo Mix', CAST(7.00 AS Decimal(18, 2)), 38)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (54, 6, N'Perth Pasties', N'Perth Pasties', CAST(32.80 AS Decimal(18, 2)), 0)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (55, 6, N'Tourtière', N'Tourtière', CAST(7.45 AS Decimal(18, 2)), 21)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (56, 6, N'Pâté chinois', N'Pâté chinois', CAST(24.00 AS Decimal(18, 2)), 115)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (57, 5, N'Gnocchi di nonna Alice', N'Gnocchi di nonna Alice', CAST(38.00 AS Decimal(18, 2)), 21)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (58, 5, N'Ravioli Angelo', N'Ravioli Angelo', CAST(19.50 AS Decimal(18, 2)), 36)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (59, 8, N'Escargots de Bourgogne', N'Escargots de Bourgogne', CAST(13.25 AS Decimal(18, 2)), 62)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (60, 4, N'Raclette Courdavault', N'Raclette Courdavault', CAST(55.00 AS Decimal(18, 2)), 79)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (61, 4, N'Camembert Pierrot', N'Camembert Pierrot', CAST(34.00 AS Decimal(18, 2)), 19)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (62, 2, N'Sirop d''érable', N'Sirop d''érable', CAST(28.50 AS Decimal(18, 2)), 113)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (63, 3, N'Tarte au sucre', N'Tarte au sucre', CAST(49.30 AS Decimal(18, 2)), 17)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (64, 2, N'Vegie-spread', N'Vegie-spread', CAST(43.90 AS Decimal(18, 2)), 24)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (65, 5, N'Wimmers gute Semmelknödel', N'Wimmers gute Semmelknödel', CAST(33.25 AS Decimal(18, 2)), 22)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (66, 2, N'Louisiana Fiery Hot Pepper Sauce', N'Louisiana Fiery Hot Pepper Sauce', CAST(21.05 AS Decimal(18, 2)), 76)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (67, 2, N'Louisiana Hot Spiced Okra', N'Louisiana Hot Spiced Okra', CAST(17.00 AS Decimal(18, 2)), 4)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (68, 1, N'Laughing Lumberjack Lager', N'Laughing Lumberjack Lager', CAST(14.00 AS Decimal(18, 2)), 52)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (69, 3, N'Scottish Longbreads', N'Scottish Longbreads', CAST(12.50 AS Decimal(18, 2)), 6)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (70, 4, N'Gudbrandsdalsost', N'Gudbrandsdalsost', CAST(36.00 AS Decimal(18, 2)), 26)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (71, 1, N'Outback Lager', N'Outback Lager', CAST(15.00 AS Decimal(18, 2)), 15)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (72, 4, N'Flotemysost', N'Flotemysost', CAST(21.50 AS Decimal(18, 2)), 26)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (73, 4, N'Mozzarella di Giovanni', N'Mozzarella di Giovanni', CAST(34.80 AS Decimal(18, 2)), 14)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (74, 8, N'Röd Kaviar', N'Röd Kaviar', CAST(15.00 AS Decimal(18, 2)), 101)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (75, 7, N'Longlife Tofu', N'Longlife Tofu', CAST(10.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (76, 1, N'Rhönbräu Klosterbier', N'Rhönbräu Klosterbier', CAST(7.75 AS Decimal(18, 2)), 125)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (77, 1, N'Lakkalikööri', N'Lakkalikööri', CAST(18.00 AS Decimal(18, 2)), 57)
GO
INSERT [dbo].[Products] ([Id], [CategoryId], [Name], [Details], [Price], [StockQuantity]) VALUES (78, 4, N'Original Frankfurter grüne Soße', N'Original Frankfurter grüne Soße', CAST(13.00 AS Decimal(18, 2)), 32)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

GO
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([UserId], [FullName], [Password], [Email]) VALUES (1, N'Admin', N'123456', N'admin@admin.com')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
