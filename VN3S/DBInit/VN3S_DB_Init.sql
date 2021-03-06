USE [bh_test]
GO
/****** Object:  Table [bh_test].[3s_Banner]    Script Date: 10/19/2019 9:31:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bh_test].[3s_Banner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Url] [nvarchar](1000) NOT NULL,
	[IsActive] [bigint] NOT NULL,
 CONSTRAINT [PK_3s_Banner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [bh_test].[3s_DieuKienVay]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bh_test].[3s_DieuKienVay](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](500) NOT NULL,
	[DangHoatDong] [bit] NOT NULL,
	[DaXoa] [bit] NOT NULL,
 CONSTRAINT [PK_3s_DieuKienVay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [bh_test].[3s_KhanhHang]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bh_test].[3s_KhanhHang](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nvarchar](15) NOT NULL,
	[SoCMND] [nvarchar](20) NOT NULL,
	[TinhThanhId] [int] NOT NULL,
	[DieuKienVayId] [int] NOT NULL,
	[NgayDangKy] [datetime] NOT NULL,
	[DaXuatRaExcel] [bit] NOT NULL,
 CONSTRAINT [PK_3s_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [bh_test].[3s_TinhThanh]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bh_test].[3s_TinhThanh](
	[Id] [bigint] NOT NULL,
	[Ten] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_3s_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [bh_test].[3s_UngCuVien]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bh_test].[3s_UngCuVien](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nvarchar](15) NOT NULL,
	[SoCMND] [nvarchar](20) NOT NULL,
	[TinhThanhId] [int] NOT NULL,
	[NgayDangKy] [datetime] NOT NULL,
	[ViTriId] [int] NOT NULL,
	[DaXuatRaExcel] [bit] NOT NULL,
 CONSTRAINT [PK_3s_Candidator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [bh_test].[3s_Banner] ADD  CONSTRAINT [DF_3s_Banner_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_Banner_AddUpdate]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_Banner_AddUpdate]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Description nvarchar(500) = null,
	@Url nvarchar(1000),
	@IsActive bit = 1
AS
BEGIN
	
	SET NOCOUNT ON;

	Declare @Result int = 0

	Begin try
		MERGE [3s_Banner] AS t  
			USING (SELECT	@Id 
							,@Description
							,@Url
							,@IsActive
					) AS s (	Id 
								,[Description] 
								,[Url]
								,IsActive 
							)
			ON (t.Id = s.Id)  
		WHEN MATCHED THEN 
				UPDATE 
				SET	[Description] = s.[Description]
					,[Url] = s.[Url]
					,IsActive = s.IsActive
		WHEN NOT MATCHED THEN 
			INSERT
				([Description]
				,[Url]
				,IsActive
				)
			VALUES
				(s.[Description]
				,s.Url
				,s.IsActive
				);
		Set @Result = 1
	End try
	Begin catch
		Set @Result = 0
	End catch

	Select @Result as Result
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_Banner_Get]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_Banner_Get]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	
	SET NOCOUNT ON;

	Select top 1 * From [3s_Banner] Where Id = @Id
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_Banner_Gets]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_Banner_Gets]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	Select * From [3s_Banner] Where IsActive = 1
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_CandidatorRegister]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_CandidatorRegister]
	@HoTen NVARCHAR(50),
	@SoDienThoai nvarchar(15),
	@SoCMND nvarchar(20),
	@TinhThanhId INT,
	@VitriId INT
AS
BEGIN
	
	SET NOCOUNT ON;

	Declare @Result BIT = 0,
			@Message NVARCHAR(1000)

	BEGIN TRAN
	Begin try
	INSERT INTO [3s_UngCuVien]
           ([HoTen]
           ,[SoDienThoai]
           ,[SoCMND]
           ,[TinhThanhId]
           ,[NgayDangKy]
           ,[ViTriId]
           ,[DaXuatRaExcel])
     VALUES
           (@HoTen
           ,@SoDienThoai
           ,@SoCMND
           ,@TinhThanhId
           ,GETDATE()
           ,@VitriId
           ,0)

		COMMIT TRAN
		Set @Result = 1
		SET @Message = N'Bạn đã đăng ký ứng tuyển thành công. Chúng tôi sẽ liên lạc với bạn trong thời gian sớm nhất.'
	End try
	Begin catch
		Set @Result = 0
		SET @Message = N'Bạn không thể đăng ký ứng tuyển, vui lòng liên hệ hotline để biết thêm thông tin chi tiết.'
	End catch

	Select @Result as Success, @Message AS [Message]
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_CustomerRegister]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_CustomerRegister]
	@HoTen NVARCHAR(50),
	@SoDienThoai nvarchar(15),
	@SoCMND nvarchar(20),
	@TinhThanhId INT,
	@DieuKienVayId INT
AS
BEGIN
	
	SET NOCOUNT ON;

	Declare @Result BIT = 0,
			@Message NVARCHAR(1000)
	BEGIN TRAN
	Begin try
		INSERT INTO [3s_KhanhHang]
			   ([HoTen]
			   ,[SoDienThoai]
			   ,[SoCMND]
			   ,[TinhThanhId]
			   ,[DieuKienVayId]
			   ,[NgayDangKy]
			   ,[DaXuatRaExcel])
		 VALUES
			   (@HoTen
			   ,@SoDienThoai
			   ,@SoCMND
			   ,@TinhThanhId
			   ,@DieuKienVayId
			   ,GETDATE()
			   ,0)
		COMMIT TRAN
		Set @Result = 1
		SET @Message = N'Bạn đã đăng ký thành công.'
	End try
	Begin catch
		Set @Result = 0
		SET @Message = N'Bạn không thể đăng ký, vui lòng liên hệ hotline để biết thêm thông tin chi tiết.'
	End catch

	Select @Result as Success, @Message AS [Message]
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_DieuKienVaySave]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_DieuKienVaySave]
	@DieuKienVayId INT = 0,
	@Ten NVARCHAR(500) = NULL
AS
BEGIN
	DECLARE @Result INT = 0,
			@Message NVARCHAR(500) = NULL
	SET NOCOUNT ON;
	IF(ISNULL(@DieuKienVayId, 0 ) = 0)
	BEGIN
		INSERT INTO [3s_DieuKienVay]
			   ([Ten]
			   ,[DangHoatDong]
			   ,[DaXoa])
		 VALUES
			   (@Ten
			   ,1
			   ,0)
		SET @Result = 1
		SET @Message = N'Đã thêm điều kiện vay thành công.'
	END
	ELSE
	BEGIN
		UPDATE [3s_DieuKienVay]
		   SET [Ten] = @Ten
		WHERE Id = @DieuKienVayId

		SET @Result = 1
		SET @Message = N'Đã cập nhật điều kiện vay thành công.'
	END

	SELECT @Result AS [Result], @Message AS [Message]
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_GetCandidators]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_GetCandidators]
	@DaXuatRaExcel BIT = 0
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [Id]
		  ,[HoTen]
		  ,[SoDienThoai]
		  ,[SoCMND]
		  ,[TinhThanhId]
		  ,(SELECT TOP(1) Ten FROM [3s_TinhThanh] WHERE Id = TinhThanhId) AS 'TinhThanh'
		  ,FORMAT([NgayDangKy], 'dd/MM/yyyy') AS [NgayDangKy]
		  ,[ViTriId]
		  ,(CASE WHEN ViTriId = 1 THEN N'Nhân viên kinh doanh' ELSE N'Giám sát phát triển kinh doanh' END) AS 'ViTri'
		  ,[DaXuatRaExcel]
	FROM [bh_test].[3s_UngCuVien]
	ORDER BY [Id] DESC


END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_GetCustomers]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
/*
[proc_3s_GetCustomers] 1,'2019-10-9','2019-10-9',0
*/
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_GetCustomers]
	@DaXuatRaExcel BIT = null,
	@TuNgay datetime = null,
	@DenNgay datetime = null,
	@UpdateExcel bit = 0
AS
BEGIN
	
	SET NOCOUNT ON;

	Declare @daXuatExcelString nvarchar(1000) = '0,1'

	if (@DaXuatRaExcel = 1)
		Set @daXuatExcelString = '1'
	else if (@DaXuatRaExcel = 0)
		Set @daXuatExcelString = '0'

	if (@TuNgay is null or @DenNgay is null)
	Begin
		SELECT [Id]
			  ,[HoTen]
			  ,[SoDienThoai]
			  ,[SoCMND]
			  ,[TinhThanhId]
			  ,(SELECT TOP(1) Ten FROM [3s_TinhThanh] WHERE Id = TinhThanhId) AS 'TinhThanh'
			  ,FORMAT([NgayDangKy], 'dd/MM/yyyy') AS [NgayDangKy]
			  ,DieuKienVayId
			  ,(SELECT TOP(1) Ten FROM [bh_test].[3s_DieuKienVay] WHERE Id = DieuKienVayId) AS 'DieuKienVay'
			  ,[DaXuatRaExcel]
		Into #tmp
		FROM [3s_KhanhHang]
		Where DaXuatRaExcel in (Select item From dbo.SplitReturnBool(@daXuatExcelString,','))
		ORDER BY Id DESC

		Select * From #tmp ORDER BY Id DESC
		
		If (@UpdateExcel = 1)
			Update [3s_KhanhHang] Set DaXuatRaExcel = 1 Where Id in (Select Id From #tmp)
	End
	Else
	Begin
		SELECT [Id]
			  ,[HoTen]
			  ,[SoDienThoai]
			  ,[SoCMND]
			  ,[TinhThanhId]
			  ,(SELECT TOP(1) Ten FROM [3s_TinhThanh] WHERE Id = TinhThanhId) AS 'TinhThanh'
			  ,FORMAT([NgayDangKy], 'dd/MM/yyyy') AS [NgayDangKy]
			  ,DieuKienVayId
			  ,(SELECT TOP(1) Ten FROM [bh_test].[3s_DieuKienVay] WHERE Id = DieuKienVayId) AS 'DieuKienVay'
			  ,[DaXuatRaExcel]
		Into #tmp1
		FROM [3s_KhanhHang]
		Where DaXuatRaExcel in (Select item From dbo.SplitReturnBool(@daXuatExcelString,',')) and Convert(date,NgayDangKy) >= @TuNgay and Convert(date,NgayDangKy) <= @DenNgay
		ORDER BY Id DESC

		Select * From #tmp1  ORDER BY Id DESC
		
		If (@UpdateExcel = 1)
			Update [3s_KhanhHang] Set DaXuatRaExcel = 1 Where Id in (Select Id From #tmp1)
	End
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_GetDieuKienVay]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_GetDieuKienVay]
	@DieuKienVayId INT = 0
AS
BEGIN
	
	SET NOCOUNT ON;

	IF(ISNULL(@DieuKienVayId,0) = 0)
	BEGIN
		SELECT [Id]
			  ,[Ten]
			  ,[DangHoatDong]
		FROM [3s_DieuKienVay]
		WHERE DaXoa = 0 AND DangHoatDong = 1
	END
	ELSE
	BEGIN
		SELECT [Id]
			  ,[Ten]
			  ,[DangHoatDong]
		FROM [3s_DieuKienVay]
		WHERE DaXoa = 0 AND DangHoatDong = 1 AND Id = @DieuKienVayId
	END
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_KichHoatDieuKienVay]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_KichHoatDieuKienVay]
	@Id INT = 0
AS
BEGIN
	DECLARE @Result INT = 0,
			@Message NVARCHAR(500) = NULL,
			@DangHoatDong BIT

	SET NOCOUNT ON;
	
	BEGIN TRY
		SET @DangHoatDong = (SELECT TOP(1) DangHoatDong FROM [3s_DieuKienVay] WHERE Id = @Id)

		UPDATE [3s_DieuKienVay]
		   SET [DangHoatDong] = (1 - @DangHoatDong)
		WHERE Id = @Id

		SET @Result = 1
		IF(@DangHoatDong = 0)
			SET @Message = N'Đã kích hoạt điều kiện vay thành công.'
		ELSE
			SET @Message = N'Điều kiện vay đã được cập nhật thành ngưng hoạt động.'
	END TRY
	BEGIN CATCH
	END CATCH

	SELECT @Result AS [Success], @Message AS [Message]
END
GO
/****** Object:  StoredProcedure [bh_test].[proc_3s_XoaDieuKienVay]    Script Date: 10/19/2019 9:31:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [bh_test].[proc_3s_XoaDieuKienVay]
	@DieuKienVayId INT = 0
AS
BEGIN
	DECLARE @Success INT = 0,
			@Message NVARCHAR(500) = NULL
	SET NOCOUNT ON;
	
	BEGIN TRY
		UPDATE [3s_DieuKienVay]
		   SET [DaXoa] = 1
		WHERE Id = @DieuKienVayId

		SET @Success = 1
		SET @Message = N'Đã xóa thành công.'
	END TRY
	BEGIN CATCH
	END CATCH

	SELECT @Success AS Success, @Message AS [Message]
END
GO
