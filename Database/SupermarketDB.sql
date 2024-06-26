USE [master]
GO
/****** Object:  Database [SupermarketDB]    Script Date: 21.05.2024 21:33:46 ******/
CREATE DATABASE [SupermarketDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SupermarketDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER03\MSSQL\DATA\SupermarketDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SupermarketDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER03\MSSQL\DATA\SupermarketDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SupermarketDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SupermarketDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SupermarketDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SupermarketDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SupermarketDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SupermarketDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SupermarketDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SupermarketDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SupermarketDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SupermarketDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SupermarketDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SupermarketDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SupermarketDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SupermarketDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SupermarketDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SupermarketDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SupermarketDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SupermarketDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SupermarketDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SupermarketDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SupermarketDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SupermarketDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SupermarketDB] SET  MULTI_USER 
GO
ALTER DATABASE [SupermarketDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SupermarketDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SupermarketDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SupermarketDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SupermarketDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SupermarketDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SupermarketDB', N'ON'
GO
ALTER DATABASE [SupermarketDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [SupermarketDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SupermarketDB]
GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[ManufacturerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CountryOfOrigin] [nvarchar](100) NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ManufacturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Markups]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Markups](
	[MarkupID] [int] IDENTITY(1,1) NOT NULL,
	[MarkupPercentage] [int] NULL,
	[MarkupCategory] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MarkupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[OfferID] [int] IDENTITY(1,1) NOT NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[ProductID] [int] NOT NULL,
	[DiscountPercentage] [float] NOT NULL,
	[ValidFromDay] [int] NOT NULL,
	[ValidFromMonth] [int] NOT NULL,
	[ValidFromYear] [int] NOT NULL,
	[ValidToDay] [int] NOT NULL,
	[ValidToMonth] [int] NOT NULL,
	[ValidToYear] [int] NOT NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OfferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Barcode] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ManufacturerID] [int] NOT NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStock](
	[ProductStockID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitOfMeasure] [nvarchar](max) NOT NULL,
	[MonthOfSupply] [int] NOT NULL,
	[DayOfSupply] [int] NOT NULL,
	[YearOfSupply] [int] NOT NULL,
	[MonthOfExpiration] [int] NOT NULL,
	[DayOfExpiration] [int] NOT NULL,
	[YearOfExpiration] [int] NOT NULL,
	[PurchasePrice] [decimal](18, 2) NOT NULL,
	[SalePrice] [decimal](18, 2) NOT NULL,
	[PricePerProduct] [decimal](18, 2) NOT NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductStockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ReceiptID] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptProductId] [int] NOT NULL,
	[MonthOfIssuing] [int] NOT NULL,
	[DayOfIssuing] [int] NOT NULL,
	[YearOfIssuing] [int] NOT NULL,
	[CashierName] [nvarchar](max) NOT NULL,
	[AmountReceived] [decimal](18, 2) NOT NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceiptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt_Product]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK__Users__1788CCACB3C56BD5] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [UserType], [Deleted]) VALUES (3, N'Iulian', N'vCUnxZcXxnzSpwaDYuB7Egd3VF9U2A/A4FNdQ9y5nqI=', N'Admin', 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [UserType], [Deleted]) VALUES (4, N'Iulian', N'hdwV15H8+Y/vEArKrZM+ad/yQrgfGDTqFfLjA2LtDoU=', N'Admin', 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [UserType], [Deleted]) VALUES (5, N'Iulian', N'hdwV15H8+Y/vEArKrZM+ad/yQrgfGDTqFfLjA2LtDoU=', N'Admin', 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [UserType], [Deleted]) VALUES (6, N'Vlascu', N'hdwV15H8+Y/vEArKrZM+ad/yQrgfGDTqFfLjA2LtDoU=', N'Admin', 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [UserType], [Deleted]) VALUES (7, N'Damian', N'vCUnxZcXxnzSpwaDYuB7Egd3VF9U2A/A4FNdQ9y5nqI=', N'Cashier', 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [UserType], [Deleted]) VALUES (8, N'Vlascu', N'hdwV15H8+Y/vEArKrZM+ad/yQrgfGDTqFfLjA2LtDoU=', N'Admin', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Manufacturers] ADD  CONSTRAINT [DF_Manufacturers_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Offers] ADD  CONSTRAINT [DF_Offers_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[ProductCategories] ADD  CONSTRAINT [DF_ProductCategories_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[ProductStock] ADD  CONSTRAINT [DF_ProductStock_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Receipt] ADD  CONSTRAINT [DF_Receipt_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Receipt_Product] ADD  CONSTRAINT [DF_Receipt_Product_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offer_Product]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ProductCategories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[Manufacturers] ([ManufacturerID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
ALTER TABLE [dbo].[ProductStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductStock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductStock] CHECK CONSTRAINT [FK_ProductStock_Product]
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD  CONSTRAINT [FK_Receipt_Product] FOREIGN KEY([ReceiptProductId])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Receipt] CHECK CONSTRAINT [FK_Receipt_Product]
GO
ALTER TABLE [dbo].[Receipt_Product]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Receipt_Product] CHECK CONSTRAINT [FK_ReceiptProduct_Product]
GO
ALTER TABLE [dbo].[Receipt_Product]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptProduct_Receipt] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipt] ([ReceiptID])
GO
ALTER TABLE [dbo].[Receipt_Product] CHECK CONSTRAINT [FK_ReceiptProduct_Receipt]
GO
/****** Object:  StoredProcedure [dbo].[AddManufacturer]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddManufacturer]
    @name NVARCHAR(100),
    @country_of_origin NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Manufacturers (Name, CountryOfOrigin, Deleted)
    VALUES (@name, @country_of_origin, 0);
END
GO
/****** Object:  StoredProcedure [dbo].[AddMarkup]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddMarkup]
    @markup_percentage INT,
    @markup_category INT,
    @markup_id INT OUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Markups (MarkupPercentage, MarkupCategory)
    VALUES (@markup_percentage, @markup_category);

    SET @markup_id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddOffer]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddOffer]
    @reason NVARCHAR(MAX),
    @product_id INT,
    @discount_percentage FLOAT,
    @valid_from_day INT,
    @valid_from_month INT,
    @valid_from_year INT,
    @valid_to_day INT,
    @valid_to_month INT,
    @valid_to_year INT
AS
BEGIN
    INSERT INTO Offers(Reason, ProductID, DiscountPercentage, ValidFromDay, ValidFromMonth, ValidFromYear, ValidToDay, ValidToMonth, ValidToYear, Deleted)
    VALUES (@reason, @product_id, @discount_percentage, @valid_from_day, @valid_from_month, @valid_from_year, @valid_to_day, @valid_to_month, @valid_to_year, 0);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
    @product_name NVARCHAR(100),
    @barcode INT,
    @category_id INT,
    @manufacturer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Products (ProductName, Barcode, CategoryID, ManufacturerID, Deleted)
    VALUES (@product_name, @barcode, @category_id, @manufacturer_id, 0);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProductCategory]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProductCategory]
    @category_name NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ProductCategories (CategoryName, Deleted)
    VALUES (@category_name, 0);
END
GO
/****** Object:  StoredProcedure [dbo].[AddProductStock]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProductStock]
    @product_id INT,
    @quantity INT,
    @price_per_product DECIMAL(18, 2),
    @unit_of_measure NVARCHAR(50),
    @supply_day INT,
    @supply_month INT,
    @supply_year INT,
    @expiration_day INT,
    @expiration_month INT,
    @expiration_year INT,
    @purchase_price DECIMAL(18, 2),
    @sale_price DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ProductStock(ProductID, Quantity, PricePerProduct, UnitOfMeasure, 
                                DayOfSupply, MonthOfSupply, YearOfSupply, 
                                DayOfExpiration, MonthOfExpiration, YearOfExpiration, 
                                PurchasePrice, SalePrice, Deleted)
    VALUES (@product_id, @quantity, @price_per_product, @unit_of_measure, 
            @supply_day, @supply_month, @supply_year, 
            @expiration_day, @expiration_month, @expiration_year, 
            @purchase_price, @sale_price, 0);
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
    @username NVARCHAR(50),
    @password NVARCHAR(50),
    @user_type NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Users(Username, Password, UserType, Deleted)
    VALUES (@username, @password, @user_type, 0);

    SELECT SCOPE_IDENTITY() AS UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[CheckManufacturerExistsById]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckManufacturerExistsById]
    @manufacturer_id INT
AS
BEGIN
    -- Declare a variable to hold the count of matching rows
    DECLARE @Count INT;

    -- Check if the manufacturer exists by counting the matching rows
    SELECT @Count = COUNT(*)
    FROM Manufacturers
    WHERE ManufacturerID = @manufacturer_id AND Deleted = 0;

    -- Return 1 if the manufacturer exists, otherwise return 0
    IF @Count > 0
    BEGIN
        SELECT 1 AS ManufacturerExists;
    END
    ELSE
    BEGIN
        SELECT 0 AS ManufacturerExists;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CheckProductCategoryExistsById]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckProductCategoryExistsById]
    @category_id INT
AS
BEGIN
    -- Declare a variable to hold the count of matching rows
    DECLARE @Count INT;

    -- Check if the product category exists by counting the matching rows
    SELECT @Count = COUNT(*)
    FROM ProductCategories
    WHERE CategoryID = @category_id AND Deleted = 0;

    -- Return 1 if the product category exists, otherwise return 0
    IF @Count > 0
    BEGIN
        SELECT 1 AS CategoryExists;
    END
    ELSE
    BEGIN
        SELECT 0 AS CategoryExists;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CheckSimilarOfferExists]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckSimilarOfferExists]
    @reason NVARCHAR(MAX),
    @product_id INT,
    @discount_percentage FLOAT,
    @valid_from_day INT,
    @valid_from_month INT,
    @valid_from_year INT,
    @valid_to_day INT,
    @valid_to_month INT,
    @valid_to_year INT
AS
BEGIN
    SELECT 1
    FROM Offers
    WHERE Reason = @reason
      AND ProductID = @product_id
      AND DiscountPercentage = @discount_percentage
      AND ValidFromDay = @valid_from_day
      AND ValidFromMonth = @valid_from_month
      AND ValidFromYear = @valid_from_year
      AND ValidToDay = @valid_to_day
      AND ValidToMonth = @valid_to_month
      AND ValidToYear = @valid_to_year;
END
GO
/****** Object:  StoredProcedure [dbo].[CheckUserExists]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckUserExists]
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @userCount INT;

    -- Count the number of users with the given username and password
    SELECT @userCount = COUNT(*)
    FROM Users
    WHERE Username = @username AND Deleted = 0
    
    -- Return 1 if user exists, 0 if not
    IF @userCount > 0
    BEGIN
        SELECT 1 AS UserExists;
    END
    ELSE
    BEGIN
        SELECT 0 AS UserExists;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[DailyRevenueByCashierAndMonth]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyRevenueByCashierAndMonth]
    @cashier_name NVARCHAR(100),
    @month INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DayOfIssuing AS DayNumber, SUM(AmountReceived) AS TotalAmount
    FROM Receipt
    WHERE CashierName = @cashier_name
    AND MonthOfIssuing = @month
    GROUP BY DayOfIssuing;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMarkup]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteMarkup]
    @markup_id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Markups
    WHERE MarkupID = @markup_id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteOffer]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteOffer]
    @offer_id INT
AS
BEGIN
    UPDATE Offers
	SET Deleted = 1
	WHERE OfferID = @offer_id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
    @product_id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
	SET Deleted = 1
	WHERE ProductID = @product_id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductCategory]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProductCategory]
    @category_name NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ProductCategories
	SET Deleted = 1
	WHERE CategoryName = @category_name;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductStock]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProductStock]
    @product_stock_id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ProductStock
	SET Deleted = 1
	WHERE ProductStockID = @product_stock_id;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
	SET Deleted = 1
	WHERE Username = @username;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllManufacturers]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllManufacturers]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ManufacturerID, Name, CountryOfOrigin
    FROM Manufacturers WHERE Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMarkups]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllMarkups]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MarkupID, MarkupPercentage, MarkupCategory
    FROM Markups;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductCategories]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductCategories]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CategoryID, CategoryName
    FROM ProductCategories WHERE Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducts]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductName, ProductID, Barcode, CategoryID, ManufacturerID
    FROM Products WHERE Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductStocks]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProductStocks]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductStockID, ProductID, Quantity, UnitOfMeasure, 
           DayOfSupply, MonthOfSupply, YearOfSupply, 
           DayOfExpiration, MonthOfExpiration, YearOfExpiration, 
           PurchasePrice, SalePrice
    FROM ProductStock WHERE Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Username,
        Password,
        UserType
    FROM Users WHERE Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryId]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryId]
    @category_name NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CategoryID
    FROM ProductCategories
    WHERE CategoryName = @category_name AND Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetManufacturerId]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetManufacturerId]
    @manufacturer_name NVARCHAR(100),
    @manufacturer_country NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ManufacturerID
    FROM Manufacturers
    WHERE Name = @manufacturer_name
    AND CountryOfOrigin = @manufacturer_country AND Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetMarkupsByCategory]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMarkupsByCategory]
    @category_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MarkupPercentage
    FROM Markups
    WHERE MarkupCategory = @category_id;
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByManufacturer]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsByManufacturer]
    @manufacturer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductName, ProductID, Barcode, CategoryID, ManufacturerID
    FROM Products
    WHERE ManufacturerID = @manufacturer_id AND Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStockId]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStockId]
    @quantity INT,
    @unit_of_measure NVARCHAR(50),
    @supply_day INT,
    @supply_month INT,
    @supply_year INT,
    @expiration_day INT,
    @expiration_month INT,
    @expiration_year INT,
    @purchase_price DECIMAL(18, 2),
    @sale_price DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductStockID
    FROM ProductStock
    WHERE 
        Quantity = @quantity
        AND UnitOfMeasure = @unit_of_measure
        AND DayOfSupply = @supply_day
        AND MonthOfSupply = @supply_month
        AND YearOfSupply = @supply_year
        AND DayOfExpiration = @expiration_day
        AND MonthOfExpiration = @expiration_month
        AND YearOfExpiration = @expiration_year
        AND PurchasePrice = @purchase_price
        AND SalePrice = @sale_price
		AND Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStockPurchasePrice]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStockPurchasePrice]
    @stock_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PurchasePrice
    FROM ProductStock
    WHERE ProductStockID = @stock_id AND Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetTotalSalePrice]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTotalSalePrice]
    @category_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT SUM(s.SalePrice) AS total_sale_price
    FROM Products p
    JOIN ProductStock s ON p.ProductID = s.ProductID
    WHERE p.CategoryID= @category_id AND s.Deleted = 0 AND p.Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserType]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserType]
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UserType
    FROM Users
    WHERE Username = @username AND Password = @password AND Deleted = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[HighestReceipt]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HighestReceipt]
    @day INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 *
    FROM Receipt
    WHERE DayOfIssuing = @day AND Deleted = 0
    ORDER BY AmountReceived DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[ProductFromReceipt]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductFromReceipt]
    @receiptId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT p.*
    FROM Receipt_Product rp
    JOIN Products p ON rp.ProductId = p.ProductId
    WHERE rp.ReceiptId = @receiptId AND p.Deleted = 0 AND rp.Deleted = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateManufacturer]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateManufacturer]
    @manufacturer_id INT,
    @name NVARCHAR(100),
    @country_of_origin NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Manufacturers
    SET Name = @name,
        CountryOfOrigin = @country_of_origin
    WHERE ManufacturerID = @manufacturer_id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateMarkup]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateMarkup]
    @markup_id INT,
    @markup_percentage INT,
    @markup_category INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Markups
    SET MarkupPercentage = @markup_percentage,
        MarkupCategory = @markup_category
    WHERE MarkupID = @markup_id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateOffer]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateOffer]
    @offer_id INT,
    @reason NVARCHAR(MAX),
    @product_id INT,
    @discount_percentage FLOAT,
    @valid_from_day INT,
    @valid_from_month INT,
    @valid_from_year INT,
    @valid_to_day INT,
    @valid_to_month INT,
    @valid_to_year INT
AS
BEGIN
    UPDATE Offers
    SET Reason = @reason,
        ProductID = @product_id,
        DiscountPercentage = @discount_percentage,
        ValidFromDay = @valid_from_day,
        ValidFromMonth = @valid_from_month,
        ValidFromYear = @valid_from_year,
        ValidToDay = @valid_to_day,
        ValidToMonth = @valid_to_month,
        ValidToYear = @valid_to_year
    WHERE OfferID = @offer_id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct]
    @product_id INT,
    @product_name NVARCHAR(100),
    @barcode INT,
    @category_id INT,
    @manufacturer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET ProductName = @product_name,
        Barcode = @barcode,
        CategoryID = @category_id,
        ManufacturerID = @manufacturer_id
    WHERE ProductID = @product_id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductStock]    Script Date: 21.05.2024 21:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProductStock]
    @product_id INT,
    @quantity INT,
    @unit_of_measure NVARCHAR(50),
    @supply_day INT,
    @supply_month INT,
    @supply_year INT,
    @expiration_day INT,
    @expiration_month INT,
    @expiration_year INT,
    @purchase_price DECIMAL(18, 2),
    @sale_price DECIMAL(18, 2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ProductStock
    SET 
        Quantity = @quantity,
        UnitOfMeasure = @unit_of_measure,
        DayOfSupply = @supply_day,
        MonthOfSupply = @supply_month,
        YearOfSupply = @supply_year,
        DayOfExpiration = @expiration_day,
        MonthOfExpiration = @expiration_month,
        YearOfExpiration = @expiration_year,
        PurchasePrice = @purchase_price,
        SalePrice = @sale_price
    WHERE ProductID = @product_id;
END
GO
USE [master]
GO
ALTER DATABASE [SupermarketDB] SET  READ_WRITE 
GO
