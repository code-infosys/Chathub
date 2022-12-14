USE [chatstar]
GO
/****** Object:  Table [dbo].[msgstar]    Script Date: 05/01/2015 22:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msgstar](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[email_id] [nvarchar](50) NULL,
	[frnd_user_id] [bigint] NULL,
	[crtd_date] [datetime] NULL,
	[chat_desc] [nvarchar](3000) NULL,
	[active] [bit] NULL,
	[seen] [bit] NULL,
	[del] [nchar](10) NULL,
 CONSTRAINT [PK_msgstar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[msgstar] ON
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (1, 1, N'sonustar', NULL, CAST(0x0000A1B50100769B AS DateTime), N'hellowwwwwwwwww', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (2, 1, N'sonustar', NULL, CAST(0x0000A1B50101AAB5 AS DateTime), N'im using star chat', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (3, 2, N'davinder', NULL, CAST(0x0000A1B50103F860 AS DateTime), N'am alos ', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (4, 2, N'davinder', NULL, CAST(0x0000A1B50104067F AS DateTime), N'ki hal e', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (5, 1, N'sonustar', NULL, CAST(0x0000A1B5010411D8 AS DateTime), N'mai thek a tu suna', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (6, 1, N'sonustar', NULL, CAST(0x0000A1B50104CE62 AS DateTime), N'fine', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (7, 2, N'davinder', NULL, CAST(0x0000A1B501058E24 AS DateTime), N'ok hor suna', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (8, 1, N'sonustar', NULL, CAST(0x0000A1B50105ABD2 AS DateTime), N'mai thek a', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (9, 1, N'sonustar', NULL, CAST(0x0000A1B501061EB1 AS DateTime), N'hor', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (10, 1, N'sonustar', NULL, CAST(0x0000A1B501068EFE AS DateTime), N'hanji', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (11, 1, N'sonustar', NULL, CAST(0x0000A1B501093A27 AS DateTime), N'sdfsf', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (12, 1, N'sonustar', NULL, CAST(0x0000A1B5010967D5 AS DateTime), N'hanji', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (13, 1, N'sonustar', NULL, CAST(0x0000A1B501099C7B AS DateTime), N'how', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (14, 2, N'davinder', NULL, CAST(0x0000A1B50109D2CF AS DateTime), N'fine a bus', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (15, 3, N'puneet', NULL, CAST(0x0000A1B50165F970 AS DateTime), N'hello ji', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (16, 1, N'sonustar', NULL, CAST(0x0000A1B5016B43F5 AS DateTime), N'am using now windows application', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (17, 1, N'sonustar', NULL, CAST(0x0000A1B60153C141 AS DateTime), N'asha', 1, 0, N'N         ')
INSERT [dbo].[msgstar] ([id], [user_id], [email_id], [frnd_user_id], [crtd_date], [chat_desc], [active], [seen], [del]) VALUES (18, 1, N'sonustar', NULL, CAST(0x0000A1D701738713 AS DateTime), N'hello', 1, 0, N'N         ')
SET IDENTITY_INSERT [dbo].[msgstar] OFF
/****** Object:  Table [dbo].[star_user]    Script Date: 05/01/2015 22:40:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[star_user](
	[user_id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NULL,
	[mobileno] [bigint] NULL,
	[crtd_date] [datetime] NULL,
	[mail_id] [nvarchar](50) NULL,
	[user_online] [bit] NULL,
	[password] [nvarchar](50) NULL,
	[active] [bit] NULL,
	[img_name] [nvarchar](600) NULL,
	[sex] [char](1) NULL,
	[del] [nchar](10) NULL,
 CONSTRAINT [PK_star_user_1] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[star_user] ON
INSERT [dbo].[star_user] ([user_id], [username], [mobileno], [crtd_date], [mail_id], [user_online], [password], [active], [img_name], [sex], [del]) VALUES (CAST(1 AS Numeric(18, 0)), N'sonustar', 123, CAST(0x0000A1B500E7173A AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[star_user] ([user_id], [username], [mobileno], [crtd_date], [mail_id], [user_online], [password], [active], [img_name], [sex], [del]) VALUES (CAST(2 AS Numeric(18, 0)), N'davinder', 12345, CAST(0x0000A1B500E87788 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[star_user] ([user_id], [username], [mobileno], [crtd_date], [mail_id], [user_online], [password], [active], [img_name], [sex], [del]) VALUES (CAST(3 AS Numeric(18, 0)), N'puneet', 99999, CAST(0x0000A1B50165E141 AS DateTime), NULL, NULL, NULL, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[star_user] OFF
/****** Object:  StoredProcedure [dbo].[sp_star_userRegister]    Script Date: 05/01/2015 22:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_star_userRegister]
	-- Add the parameters for the stored procedure here
 
 
@username nvarchar(100),
@mobileno bigint,
@crtd_date datetime,
@active bit

 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 insert into star_user (username,mobileno,crtd_date,active) values(@username,@mobileno,@crtd_date,@active)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_star_userLogin]    Script Date: 05/01/2015 22:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_star_userLogin]
	-- Add the parameters for the stored procedure here
	@mobileno bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 select * from star_user where mobileno=@mobileno and active=1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_msgstarSelect]    Script Date: 05/01/2015 22:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_msgstarSelect]
	-- Add the parameters for the stored procedure here
 @active bit =1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select  * from msgstar where active=@active order by crtd_date asc
END
GO
/****** Object:  StoredProcedure [dbo].[sp_msgstar]    Script Date: 05/01/2015 22:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_msgstar]
	-- Add the parameters for the stored procedure here
	 

@user_id	bigint,
@email_id varchar(50),
@crtd_date	datetime,
@chat_desc	nvarchar(3000),
@active	bit=1,
@seen	bit=0,
@del	nchar(10)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 insert into msgstar (user_id,email_id,crtd_date,chat_desc,active,seen,del) values(@user_id,@email_id,@crtd_date,@chat_desc,@active,@seen,@del)
END
GO
