USE [master]
GO
/****** Object:  Database [featherDB]    Script Date: 6/12/2019 6:33:45 PM ******/
CREATE DATABASE [featherDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'featherDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\featherDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'featherDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\featherDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [featherDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [featherDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [featherDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [featherDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [featherDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [featherDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [featherDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [featherDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [featherDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [featherDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [featherDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [featherDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [featherDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [featherDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [featherDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [featherDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [featherDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [featherDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [featherDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [featherDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [featherDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [featherDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [featherDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [featherDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [featherDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [featherDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [featherDB] SET  MULTI_USER 
GO
ALTER DATABASE [featherDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [featherDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [featherDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [featherDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [featherDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[categoryId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](max) NULL,
	[merchantId] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC,
	[merchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerId] [int] IDENTITY(1,1) NOT NULL,
	[mail] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[points] [int] NULL,
	[merchantId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC,
	[merchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designation]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[designationId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[designationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employeeId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[dateofjoining] [datetime] NULL,
	[phone] [nvarchar](50) NULL,
	[email] [nvarchar](50) NOT NULL,
	[designationId] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[salary] [float] NULL,
	[merchantId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC,
	[merchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Merchant]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Merchant](
	[merchantId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[organizationName] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Merchant] PRIMARY KEY CLUSTERED 
(
	[merchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[productId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[unitcost] [float] NOT NULL,
	[categoryId] [int] NULL,
	[sellingprice] [float] NOT NULL,
	[comission] [float] NULL,
	[rating] [int] NULL,
	[createdDate] [datetime] NULL,
	[modifiedDate] [datetime] NULL,
	[merchantId] [int] NOT NULL,
	[modifiedUserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[productId] ASC,
	[merchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quantity]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quantity](
	[productId] [int] NOT NULL,
	[quantityInStock] [int] NULL,
	[quantitySold] [int] NULL,
	[quantityRemaining] [int] NULL,
	[depletionQuantity] [int] NULL,
	[merchantId] [int] NOT NULL,
 CONSTRAINT [PK_Quantity] PRIMARY KEY CLUSTERED 
(
	[productId] ASC,
	[merchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ticketId] [bigint] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[customerId] [int] NULL,
	[totalCost] [float] NOT NULL,
	[orderDate] [datetime] NOT NULL,
	[merchantid] [int] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ticketId] ASC,
	[merchantid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TicketLineProduct]    Script Date: 6/12/2019 6:33:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketLineProduct](
	[ticketId] [bigint] NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
	[totalPrice] [float] NOT NULL,
	[commission] [float] NULL,
	[merchantId] [int] NOT NULL,
 CONSTRAINT [PK_TicketLineProduct] PRIMARY KEY CLUSTERED 
(
	[ticketId] ASC,
	[productId] ASC,
	[merchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Merchant] FOREIGN KEY([merchantId])
REFERENCES [dbo].[Merchant] ([merchantId])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Merchant]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Merchant] FOREIGN KEY([merchantId])
REFERENCES [dbo].[Merchant] ([merchantId])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Merchant]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Designation] FOREIGN KEY([designationId])
REFERENCES [dbo].[Designation] ([designationId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Designation]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Merchant] FOREIGN KEY([merchantId])
REFERENCES [dbo].[Merchant] ([merchantId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Merchant]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([categoryId], [merchantId])
REFERENCES [dbo].[Category] ([categoryId], [merchantId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Merchant] FOREIGN KEY([merchantId])
REFERENCES [dbo].[Merchant] ([merchantId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Merchant]
GO
ALTER TABLE [dbo].[Quantity]  WITH CHECK ADD  CONSTRAINT [FK_Quantity_Product] FOREIGN KEY([productId], [merchantId])
REFERENCES [dbo].[Product] ([productId], [merchantId])
GO
ALTER TABLE [dbo].[Quantity] CHECK CONSTRAINT [FK_Quantity_Product]
GO
USE [master]
GO
ALTER DATABASE [featherDB] SET  READ_WRITE 
GO
