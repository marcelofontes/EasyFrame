CREATE TABLE [dbo].[C](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
 CONSTRAINT [PK_C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CS]    Script Date: 23/03/2018 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
	[R] [int] NOT NULL,
 CONSTRAINT [PK_CS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CVS]    Script Date: 23/03/2018 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CVS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
	[R] [int] NOT NULL,
 CONSTRAINT [PK_CVS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CX]    Script Date: 23/03/2018 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CX](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
 CONSTRAINT [PK_CX] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PS]    Script Date: 23/03/2018 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
	[R] [int] NOT NULL,
 CONSTRAINT [PK_PS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSa]    Script Date: 23/03/2018 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bfs] [int] NOT NULL,
	[bfi] [int] NOT NULL,
	[tfs] [float] NOT NULL,
	[tfi] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wxs] [float] NOT NULL,
	[Wxi] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
	[R] [int] NOT NULL,
 CONSTRAINT [PK_PSa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T]    Script Date: 23/03/2018 17:27:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
 CONSTRAINT [PK_T] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TQ]    Script Date: 23/03/2018 17:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TQ](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
 CONSTRAINT [PK_TQ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TR]    Script Date: 23/03/2018 17:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
 CONSTRAINT [PK_TR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TW]    Script Date: 23/03/2018 17:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TW](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
 CONSTRAINT [PK_TW] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VS]    Script Date: 23/03/2018 17:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
	[R] [int] NOT NULL,
 CONSTRAINT [PK_VS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VSM]    Script Date: 23/03/2018 17:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VSM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bfs] [int] NOT NULL,
	[bfi] [int] NOT NULL,
	[tfs] [float] NOT NULL,
	[tfi] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wxs] [float] NOT NULL,
	[Wxi] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
	[R] [int] NOT NULL,
 CONSTRAINT [PK_VSM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[W]    Script Date: 23/03/2018 17:27:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[W](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[peso] [float] NOT NULL,
	[A] [float] NOT NULL,
	[d] [int] NOT NULL,
	[tw] [float] NOT NULL,
	[bf] [int] NOT NULL,
	[tf] [float] NOT NULL,
	[Ix] [float] NOT NULL,
	[Wx] [float] NOT NULL,
	[rx] [float] NOT NULL,
	[Zx] [float] NOT NULL,
	[Iy] [float] NOT NULL,
	[Wy] [float] NOT NULL,
	[ry] [float] NOT NULL,
	[Zy] [float] NOT NULL,
	[rT] [float] NOT NULL,
	[IT] [float] NOT NULL,
	[Cw] [float] NOT NULL,
	[ProfCode] [int] NOT NULL,
	[Fabrication] [int] NOT NULL,
	[R] [int] NOT NULL,
 CONSTRAINT [PK_W] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CS] ON 

INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (1, N'CS200 x 34', 34.2, 43.6, 200, 6.3, 200, 8, 3278, 328, 8.67, 361, 1067, 107, 4.95, 162, 5.45, 8, 98304, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (2, N'CS200 x 39', 38.8, 49.4, 200, 6.3, 200, 9.5, 3762, 376, 8.73, 414, 1267, 127, 5.06, 192, 5.51, 13, 114919, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (3, N'CS200 x 41', 41.2, 52.5, 200, 8, 200, 9.5, 3846, 385, 8.56, 427, 1267, 127, 4.91, 193, 5.44, 15, 114919, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (4, N'CS200 x 50', 50.2, 64, 200, 8, 200, 12.5, 4758, 476, 8.62, 530, 1667, 167, 5.1, 253, 5.52, 29, 146484, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (5, N'CS200 x 61', 60.8, 77.4, 200, 8, 200, 16, 5747, 575, 8.62, 645, 2134, 213, 5.25, 323, 5.58, 58, 180565, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (6, N'CS250 x 43', 42.9, 54.7, 250, 6.3, 250, 8, 6531, 522, 10.93, 570, 2084, 167, 6.17, 252, 6.81, 11, 305021, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (7, N'CS250 x 49', 48.7, 62.1, 250, 6.3, 250, 9.5, 7519, 602, 11, 655, 2474, 198, 6.31, 299, 6.87, 16, 357736, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (8, N'CS250 x 52', 51.8, 66, 250, 8, 250, 9.5, 7694, 616, 10.8, 678, 2475, 198, 6.12, 301, 6.79, 18, 357736, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (9, N'CS250 x 63', 63.2, 80.5, 250, 8, 250, 12.5, 9581, 766, 10.91, 843, 3256, 260, 6.36, 394, 6.89, 37, 459035, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (10, N'CS250 x 66', 65.9, 83.9, 250, 9.5, 250, 12.5, 9723, 778, 10.77, 862, 3257, 261, 6.23, 396, 6.84, 39, 459035, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (11, N'CS250 x 76', 76.5, 97.4, 250, 8, 250, 16, 11659, 933, 10.94, 1031, 4168, 333, 6.54, 503, 6.97, 72, 570375, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (12, N'CS250 x 79', 79, 100.7, 250, 9.5, 250, 16, 11788, 943, 10.82, 1049, 4168, 333, 6.43, 505, 6.92, 75, 570375, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (13, N'CS250 x 84', 84.2, 107.3, 250, 12.5, 250, 16, 12047, 964, 10.6, 1085, 4170, 334, 6.23, 509, 6.84, 84, 570375, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (14, N'CS250 x 90', 90.4, 115.1, 250, 9.5, 250, 19, 13456, 1076, 10.81, 1204, 4949, 396, 6.56, 599, 6.98, 121, 660064, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (15, N'CS250 x 95', 95.4, 121.5, 250, 12.5, 250, 19, 13694, 1096, 10.62, 1238, 4951, 396, 6.38, 602, 6.9, 129, 660064, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (16, N'CS250 x 108', 108, 137.6, 250, 12.5, 250, 22.4, 15501, 1240, 10.61, 1406, 5837, 467, 6.51, 708, 6.96, 202, 755442, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (17, N'CS300 x 62', 62.4, 79.5, 300, 8, 300, 9.5, 13509, 901, 13.04, 986, 4276, 285, 7.33, 432, 8.14, 22, 901921, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (18, N'CS300 x 76', 76.1, 97, 300, 8, 300, 12.5, 16894, 1126, 13.2, 1229, 5626, 375, 7.62, 567, 8.27, 44, 1162354, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (19, N'CS300 x 92', 92.2, 117.4, 300, 8, 300, 16, 20661, 1377, 13.27, 1507, 7201, 480, 7.83, 724, 8.36, 87, 1451808, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (20, N'CS300 x 95', 95.4, 121.5, 300, 9.5, 300, 16, 20902, 1393, 13.12, 1534, 7202, 480, 7.7, 726, 8.3, 90, 1451808, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (21, N'CS300 x 102', 101.7, 129.5, 300, 12.5, 300, 16, 21383, 1426, 12.85, 1588, 7204, 480, 7.46, 730, 8.2, 100, 1451808, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (22, N'CS300 x 109', 109, 138.9, 300, 9.5, 300, 19, 23962, 1597, 13.13, 1765, 8552, 570, 7.85, 861, 8.36, 145, 1687791, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (23, N'CS300 x 115', 115.2, 146.8, 300, 12.5, 300, 19, 24412, 1627, 12.9, 1816, 8554, 570, 7.63, 865, 8.27, 156, 1687791, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (24, N'CS300 x 122', 122.4, 155.9, 300, 16, 300, 19, 24936, 1662, 12.65, 1876, 8559, 571, 7.41, 872, 8.18, 176, 1687791, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (25, N'CS300 x 131', 130.5, 166.3, 300, 12.5, 300, 22.4, 27774, 1852, 12.92, 2069, 10084, 672, 7.79, 1018, 8.34, 243, 1941956, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (26, N'CS300 x 138', 137.5, 175.2, 300, 16, 300, 22.4, 28257, 1884, 12.7, 2126, 10089, 673, 7.59, 1024, 8.25, 263, 1941956, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (27, N'CS300 x 149', 149.2, 190, 300, 16, 300, 25, 30521, 2035, 12.67, 2313, 11259, 751, 7.7, 1141, 8.3, 350, 2126953, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (28, N'CS350 x 89', 89.1, 113.5, 350, 8, 350, 12.5, 27217, 1555, 15.49, 1688, 8934, 511, 8.87, 771, 9.64, 51, 2543610, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (29, N'CS350 x 93', 92.9, 118.4, 350, 9.5, 350, 12.5, 27646, 1580, 15.28, 1727, 8935, 511, 8.69, 773, 9.56, 55, 2543610, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (30, N'CS350 x 108', 107.9, 137.4, 350, 8, 350, 16, 33403, 1909, 15.59, 2073, 11435, 653, 9.12, 985, 9.74, 101, 3188642, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (31, N'CS350 x 112', 111.6, 142.2, 350, 9.5, 350, 16, 33805, 1932, 15.42, 2111, 11436, 653, 8.97, 987, 9.68, 105, 3188642, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (32, N'CS350 x 119', 119.2, 151.8, 350, 12.5, 350, 16, 34609, 1978, 15.1, 2186, 11439, 654, 8.68, 992, 9.55, 117, 3188642, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (33, N'CS350 x 128', 127.6, 162.6, 350, 9.5, 350, 19, 38873, 2221, 15.46, 2432, 13579, 776, 9.14, 1171, 9.75, 170, 3718797, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (34, N'CS350 x 135', 135, 172, 350, 12.5, 350, 19, 39633, 2265, 15.18, 2505, 13582, 776, 8.89, 1176, 9.64, 182, 3718797, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (35, N'CS350 x 144', 143.6, 182.9, 350, 16, 350, 19, 40519, 2315, 14.88, 2591, 13588, 776, 8.62, 1184, 9.53, 205, 3718797, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (36, N'CS350 x 153', 153, 194.9, 350, 12.5, 350, 22.4, 45254, 2586, 15.24, 2859, 16012, 915, 9.06, 1384, 9.72, 284, 4294659, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (37, N'CS350 x 161', 161.4, 205.6, 350, 16, 350, 22.4, 46082, 2633, 14.97, 2940, 16017, 915, 8.83, 1392, 9.62, 307, 4294659, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (38, N'CS350 x 175', 175.1, 223, 350, 16, 350, 25, 49902, 2852, 14.96, 3204, 17875, 1021, 8.95, 1550, 9.67, 409, 4717367, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (39, N'CS350 x 182', 182.1, 232, 350, 19, 350, 25, 50577, 2890, 14.76, 3271, 17882, 1022, 8.78, 1558, 9.6, 439, 4717367, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (40, N'CS350 x 216', 215.9, 275, 350, 19, 350, 31.5, 59845, 3420, 14.75, 3903, 22526, 1287, 9.05, 1955, 9.71, 802, 5708504, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (41, N'CS400 x 106', 106.4, 135.6, 400, 9.5, 400, 12.5, 41727, 2086, 17.54, 2271, 13336, 667, 9.92, 1008, 10.92, 63, 5005208, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (42, N'CS400 x 128', 128, 163, 400, 9.5, 400, 16, 51159, 2558, 17.72, 2779, 17069, 853, 10.23, 1288, 11.06, 120, 6291456, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (43, N'CS400 x 137', 136.6, 174, 400, 12.5, 400, 16, 52404, 2620, 17.35, 2881, 17073, 854, 9.91, 1294, 10.91, 134, 6291456, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (44, N'CS400 x 146', 146.3, 186.4, 400, 9.5, 400, 19, 58962, 2948, 17.79, 3207, 20269, 1013, 10.43, 1528, 11.14, 194, 7354824, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (45, N'CS400 x 155', 154.9, 197.3, 400, 12.5, 400, 19, 60148, 3007, 17.46, 3305, 20273, 1014, 10.14, 1534, 11.01, 208, 7354824, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (46, N'CS400 x 165', 164.8, 209.9, 400, 16, 400, 19, 61532, 3077, 17.12, 3420, 20279, 1014, 9.83, 1543, 10.88, 235, 7354824, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (47, N'CS400 x 176', 175.5, 223.6, 400, 12.5, 400, 22.4, 68864, 3443, 17.55, 3777, 23899, 1195, 10.34, 1806, 11.1, 324, 8516884, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (48, N'CS400 x 185', 185.3, 236, 400, 16, 400, 22.4, 70169, 3508, 17.24, 3887, 23905, 1195, 10.06, 1815, 10.98, 351, 8516884, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (49, N'CS400 x 201', 201, 256, 400, 16, 400, 25, 76133, 3807, 17.25, 4240, 26679, 1334, 10.21, 2022, 11.04, 468, 9375000, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (50, N'CS400 x 209', 209.2, 266.5, 400, 19, 400, 25, 77205, 3860, 17.02, 4332, 26687, 1334, 10.01, 2032, 10.96, 502, 9375000, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (51, N'CS400 x 248', 248.1, 316, 400, 19, 400, 31.5, 91817, 4591, 17.05, 5183, 33619, 1681, 10.31, 2550, 11.09, 918, 11406549, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (52, N'CS450 x 144', 144.2, 183.7, 450, 9.5, 450, 16, 73621, 3272, 20.02, 3540, 24303, 1080, 11.5, 1629, 12.43, 135, 11442627, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (53, N'CS450 x 154', 154.1, 196.3, 450, 12.5, 450, 16, 75447, 3353, 19.6, 3671, 24307, 1080, 11.13, 1636, 12.27, 151, 11442627, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (54, N'CS450 x 165', 164.9, 210.1, 450, 9.5, 450, 19, 85001, 3778, 20.11, 4088, 28859, 1283, 11.72, 1933, 12.52, 218, 13400915, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (55, N'CS450 x 175', 174.7, 222.5, 450, 12.5, 450, 19, 86749, 3856, 19.75, 4216, 28863, 1283, 11.39, 1940, 12.38, 234, 13400915, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (56, N'CS450 x 188', 188.5, 240.1, 450, 9.5, 450, 22.4, 97865, 4350, 20.19, 4700, 34023, 1512, 11.9, 2277, 12.6, 349, 15550692, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (57, N'CS450 x 198', 198, 252.2, 450, 12.5, 450, 22.4, 99526, 4423, 19.87, 4823, 34027, 1512, 11.62, 2284, 12.48, 365, 15550692, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (58, N'CS450 x 209', 209.1, 266.4, 450, 16, 450, 22.4, 101463, 4509, 19.52, 4966, 34034, 1513, 11.3, 2294, 12.35, 396, 15550692, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (59, N'CS450 x 216', 215.9, 275, 450, 12.5, 450, 25, 108385, 4817, 19.85, 5281, 37975, 1688, 11.75, 2547, 12.53, 496, 17145264, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (60, N'CS450 x 227', 226.9, 289, 450, 16, 450, 25, 110252, 4900, 19.53, 5421, 37982, 1688, 11.46, 2557, 12.42, 527, 17145264, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (61, N'CS450 x 236', 236.3, 301, 450, 19, 450, 25, 111852, 4971, 19.28, 5541, 37992, 1689, 11.23, 2567, 12.32, 566, 17145264, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (62, N'CS450 x 280', 280.2, 357, 450, 19, 450, 31.5, 133544, 5935, 19.34, 6644, 47863, 2127, 11.58, 3224, 12.46, 1033, 20947287, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (63, N'CS450 x 291', 290.6, 370.2, 450, 22.4, 450, 31.5, 135186, 6008, 19.11, 6771, 47877, 2128, 11.37, 3238, 12.38, 1095, 20947287, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (64, N'CS450 x 321', 320.9, 408.8, 450, 19, 450, 37.5, 152314, 6770, 19.3, 7629, 56975, 2532, 11.81, 3831, 12.56, 1676, 24227325, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (65, N'CS450 x 331', 330.9, 421.5, 450, 22.4, 450, 37.5, 153809, 6836, 19.1, 7748, 56988, 2533, 11.63, 3844, 12.48, 1737, 24227325, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (66, N'CS500 x 172', 171.5, 218.5, 500, 12.5, 500, 16, 104414, 4177, 21.86, 4556, 33341, 1334, 12.35, 2018, 13.63, 168, 19521333, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (67, N'CS500 x 195', 194.5, 247.8, 500, 12.5, 500, 19, 120226, 4809, 22.03, 5237, 39591, 1584, 12.64, 2393, 13.75, 260, 22895099, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (68, N'CS500 x 207', 207.2, 263.9, 500, 16, 500, 19, 123102, 4924, 21.6, 5423, 39599, 1584, 12.25, 2405, 13.58, 294, 22895099, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (69, N'CS500 x 221', 220.5, 280.9, 500, 12.5, 500, 22.4, 138161, 5526, 22.18, 5996, 46674, 1867, 12.89, 2818, 13.86, 406, 26611872, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (70, N'CS500 x 233', 233, 296.8, 500, 16, 500, 22.4, 140908, 5636, 21.79, 6177, 46682, 1867, 12.54, 2829, 13.71, 440, 26611872, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (71, N'CS500 x 253', 252.8, 322, 500, 16, 500, 25, 153296, 6132, 21.82, 6748, 52099, 2084, 12.72, 3154, 13.79, 586, 29378255, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (72, N'CS500 x 263', 263.4, 335.5, 500, 19, 500, 25, 155574, 6223, 21.53, 6899, 52109, 2084, 12.46, 3166, 13.68, 629, 29378255, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (73, N'CS500 x 312', 312.4, 398, 500, 19, 500, 31.5, 186324, 7453, 21.64, 8286, 65650, 2626, 12.84, 3977, 13.84, 1149, 36010447, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (74, N'CS500 x 324', 324.1, 412.9, 500, 22.4, 500, 31.5, 188689, 7548, 21.38, 8448, 65666, 2627, 12.61, 3992, 13.74, 1217, 36010447, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (75, N'CS500 x 333', 333.1, 424.3, 500, 25, 500, 31.5, 190497, 7620, 21.19, 8572, 65682, 2627, 12.44, 4006, 13.67, 1286, 36010447, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (76, N'CS500 x 369', 369.1, 470.2, 500, 22.4, 500, 37.5, 215306, 8612, 21.4, 9683, 78165, 3127, 12.89, 4741, 13.86, 1931, 41778564, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (77, N'CS500 x 378', 377.8, 481.3, 500, 25, 500, 37.5, 216969, 8679, 21.23, 9801, 78180, 3127, 12.75, 4754, 13.8, 1999, 41778564, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (78, N'CS550 x 228', 228.4, 290.9, 550, 16, 550, 19, 165283, 6010, 23.84, 6598, 52703, 1916, 13.46, 2907, 14.93, 324, 37138082, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (79, N'CS550 x 257', 256.9, 327.2, 550, 16, 550, 22.4, 189447, 6889, 24.06, 7520, 62131, 2259, 13.78, 3420, 15.08, 484, 43224942, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (80, N'CS550 x 269', 268.8, 342.4, 550, 19, 550, 22.4, 192667, 7006, 23.72, 7711, 62142, 2260, 13.47, 3434, 14.94, 533, 43224942, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (81, N'CS550 x 279', 278.7, 355, 550, 16, 550, 25, 206302, 7502, 24.11, 8219, 69340, 2521, 13.98, 3813, 15.16, 645, 47767822, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (82, N'CS550 x 290', 290.5, 370, 550, 19, 550, 25, 209427, 7616, 23.79, 8406, 69351, 2522, 13.69, 3826, 15.04, 693, 47767822, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (83, N'CS550 x 345', 344.6, 439, 550, 19, 550, 31.5, 251459, 9144, 23.93, 10110, 87375, 3177, 14.11, 4808, 15.22, 1265, 58706326, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (84, N'CS550 x 358', 357.6, 455.6, 550, 22.4, 550, 31.5, 254731, 9263, 23.65, 10311, 87392, 3178, 13.85, 4825, 15.11, 1340, 58706326, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (85, N'CS550 x 368', 367.6, 468.3, 550, 25, 550, 31.5, 257234, 9354, 23.44, 10465, 87410, 3179, 13.66, 4840, 15.02, 1416, 58706326, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (86, N'CS550 x 395', 394.7, 502.8, 550, 19, 550, 37.5, 288317, 10484, 23.95, 11642, 104012, 3782, 14.38, 5715, 15.33, 2051, 68280365, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (87, N'CS550 x 407', 407.3, 518.9, 550, 22.4, 550, 37.5, 291353, 10595, 23.7, 11834, 104029, 3783, 14.16, 5731, 15.24, 2126, 68280365, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (88, N'CS550 x 417', 417.1, 531.3, 550, 25, 550, 37.5, 293675, 10679, 23.51, 11980, 104046, 3783, 13.99, 5746, 15.17, 2201, 68280365, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (89, N'CS550 x 441', 441.2, 562.1, 550, 31.5, 550, 37.5, 299480, 10890, 23.08, 12347, 104108, 3786, 13.61, 5790, 15, 2468, 68280365, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (90, N'CS550 x 498', 498.2, 634.7, 550, 31.5, 550, 44.5, 339231, 12336, 23.12, 14046, 123515, 4491, 13.95, 6845, 15.15, 3758, 78827755, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (91, N'CS600 x 250', 249.6, 317.9, 600, 16, 600, 19, 216146, 7205, 26.08, 7887, 68419, 2281, 14.67, 3456, 16.28, 354, 57722931, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (92, N'CS600 x 281', 280.7, 357.6, 600, 16, 600, 22.4, 248024, 8267, 26.34, 8995, 80659, 2689, 15.02, 4068, 16.44, 528, 67258147, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (93, N'CS600 x 294', 293.8, 374.3, 600, 19, 600, 22.4, 252298, 8410, 25.96, 9226, 80672, 2689, 14.68, 4082, 16.29, 582, 67258147, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (94, N'CS600 x 305', 304.6, 388, 600, 16, 600, 25, 270308, 9010, 26.39, 9835, 90019, 3001, 15.23, 4535, 16.53, 704, 74390625, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (95, N'CS600 x 318', 317.5, 404.5, 600, 19, 600, 25, 274468, 9149, 26.05, 10062, 90031, 3001, 14.92, 4550, 16.4, 757, 74390625, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (96, N'CS600 x 332', 332.2, 423.2, 600, 22.4, 600, 25, 279182, 9306, 25.68, 10319, 90052, 3002, 14.59, 4569, 16.25, 840, 74390625, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (97, N'CS600 x 377', 376.8, 480, 600, 19, 600, 31.5, 330248, 11008, 26.23, 12114, 113431, 3781, 15.37, 5718, 16.59, 1380, 91625003, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (98, N'CS600 x 391', 391.2, 498.3, 600, 22.4, 600, 31.5, 334635, 11155, 25.91, 12360, 113450, 3782, 15.09, 5737, 16.47, 1463, 91625003, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (99, N'CS600 x 402', 402.2, 512.3, 600, 25, 600, 31.5, 337991, 11266, 25.69, 12547, 113470, 3782, 14.88, 5754, 16.38, 1546, 91625003, 100, 1, 0)
GO
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (100, N'CS600 x 432', 431.6, 549.8, 600, 19, 600, 37.5, 379396, 12647, 26.27, 13965, 135030, 4501, 15.67, 6797, 16.71, 2238, 106787109, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (101, N'CS600 x 446', 445.6, 567.6, 600, 22.4, 600, 37.5, 383496, 12783, 25.99, 14200, 135049, 4502, 15.42, 6816, 16.61, 2320, 106787109, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (102, N'CS600 x 456', 456.3, 581.3, 600, 25, 600, 37.5, 386631, 12888, 25.79, 14379, 135068, 4502, 15.24, 6832, 16.54, 2402, 106787109, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (103, N'CS600 x 483', 483.1, 615.4, 600, 31.5, 600, 37.5, 394469, 13149, 25.32, 14827, 135137, 4505, 14.82, 6880, 16.35, 2695, 106787109, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (104, N'CS600 x 546', 545.6, 695, 600, 31.5, 600, 44.5, 447862, 14929, 25.39, 16888, 160333, 5344, 15.19, 8137, 16.51, 4104, 123586390, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (105, N'CS650 x 305', 304.6, 388, 650, 16, 650, 22.4, 317584, 9772, 28.61, 10602, 102547, 3155, 16.26, 4771, 17.8, 573, 100958460, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (106, N'CS650 x 319', 318.9, 406.2, 650, 19, 650, 22.4, 323120, 9942, 28.2, 10876, 102561, 3156, 15.89, 4787, 17.64, 631, 100958460, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (107, N'CS650 x 330', 330.5, 421, 650, 16, 650, 25, 346352, 10657, 28.68, 11596, 114448, 3521, 16.49, 5320, 17.9, 762, 111745199, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (108, N'CS650 x 345', 344.6, 439, 650, 19, 650, 25, 351752, 10823, 28.31, 11866, 114461, 3522, 16.15, 5335, 17.76, 820, 111745199, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (109, N'CS650 x 361', 360.6, 459.4, 650, 22.4, 650, 25, 357872, 11011, 27.91, 12172, 114483, 3523, 15.79, 5357, 17.59, 911, 111745199, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (110, N'CS650 x 395', 395.2, 503.4, 650, 16, 650, 31.5, 418935, 12890, 28.85, 14042, 144198, 4437, 16.92, 6692, 18.09, 1439, 137885561, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (111, N'CS650 x 409', 409, 521, 650, 19, 650, 31.5, 423991, 13046, 28.53, 14300, 144212, 4437, 16.64, 6707, 17.97, 1496, 137885561, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (112, N'CS650 x 425', 424.7, 541, 650, 22.4, 650, 31.5, 429722, 13222, 28.18, 14593, 144233, 4438, 16.33, 6728, 17.83, 1586, 137885561, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (113, N'CS650 x 437', 436.7, 556.3, 650, 25, 650, 31.5, 434104, 13357, 27.93, 14817, 144255, 4439, 16.1, 6746, 17.74, 1677, 137885561, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (114, N'CS650 x 468', 468.5, 596.8, 650, 19, 650, 37.5, 487894, 15012, 28.59, 16500, 171673, 5282, 16.96, 7974, 18.1, 2425, 160980133, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (115, N'CS650 x 484', 483.8, 616.3, 650, 22.4, 650, 37.5, 493280, 15178, 28.29, 16781, 171694, 5283, 16.69, 7994, 17.99, 2515, 160980133, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (116, N'CS650 x 496', 495.6, 631.3, 650, 25, 650, 37.5, 497399, 15305, 28.07, 16996, 171715, 5284, 16.49, 8012, 17.91, 2604, 160980133, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (117, N'CS650 x 525', 524.9, 668.6, 650, 31.5, 650, 37.5, 507697, 15621, 27.56, 17533, 171790, 5286, 16.03, 8065, 17.7, 2923, 160980133, 100, 1, 0)
INSERT [dbo].[CS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (118, N'CS650 x 593', 592.8, 755.2, 650, 31.5, 650, 44.5, 577540, 17770, 27.65, 19993, 203826, 6272, 16.43, 9540, 17.88, 4449, 186688314, 100, 1, 0)

SET IDENTITY_INSERT [dbo].[CS] OFF
SET IDENTITY_INSERT [dbo].[CVS] ON 

INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (1, N'CVS200 x 21', 20.8, 26.5, 200, 4.75, 140, 6.3, 1963, 196, 8.61, 212, 288, 41, 3.3, 63, 3.74, 3, 27025, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (2, N'CVS200 x 24', 24.4, 31.1, 200, 4.75, 140, 8, 2312, 231, 8.62, 255, 366, 52, 3.43, 79, 3.8, 5.5, 33718, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (3, N'CVS200 x 28', 27.6, 35.2, 200, 4.75, 140, 9.5, 2650, 265, 8.68, 292, 435, 62, 3.52, 94, 3.84, 8.7, 39417, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (4, N'CVS200 x 27', 26.7, 34, 200, 6.3, 140, 8, 2393, 239, 8.39, 268, 366, 52, 3.28, 80, 3.73, 6.4, 33718, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (5, N'CVS200 x 30', 29.8, 38, 200, 6.3, 140, 9.5, 2727, 273, 8.47, 305, 435, 62, 3.38, 95, 3.78, 9.6, 39417, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (6, N'CVS200 x 36', 36.1, 46, 200, 6.3, 140, 12.5, 3362, 336, 8.55, 376, 572, 82, 3.53, 124, 3.85, 19.8, 50244, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (7, N'CVS200 x 38', 38.5, 49, 200, 8, 140, 12.5, 3438, 344, 8.38, 389, 572, 82, 3.42, 125, 3.8, 21.4, 50244, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (8, N'CVS200 x 46', 45.7, 58.2, 200, 8, 140, 16, 4118, 412, 8.41, 469, 732, 105, 3.55, 159, 3.85, 41.4, 61934, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (9, N'CVS250 x 30', 30.1, 38.3, 250, 4.75, 170, 8, 4491, 359, 10.83, 394, 655, 77, 4.14, 117, 4.6, 6.7, 95908, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (10, N'CVS250 x 33', 32.9, 41.9, 250, 6.3, 170, 8, 4656, 372, 10.54, 415, 656, 77, 3.96, 118, 4.52, 7.8, 95908, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (11, N'CVS250 x 40', 39.9, 50.8, 250, 8, 170, 9.5, 5495, 440, 10.4, 495, 779, 92, 3.92, 141, 4.5, 13.8, 112484, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (12, N'CVS250 x 47', 47.5, 60.5, 250, 8, 170, 12.5, 6758, 541, 10.57, 606, 1025, 121, 4.12, 184, 4.59, 26.2, 144335, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (13, N'CVS250 x 56', 56.4, 71.8, 250, 8, 170, 16, 8149, 652, 10.65, 732, 1311, 154, 4.27, 235, 4.67, 50.4, 179344, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (14, N'CVS250 x 64', 64.1, 81.7, 250, 12.5, 170, 16, 8538, 683, 10.22, 785, 1314, 155, 4.01, 240, 4.54, 61.7, 179344, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (15, N'CVS250 x 72', 71.5, 91.1, 250, 12.5, 170, 19, 9630, 770, 10.28, 887, 1559, 183, 4.14, 283, 4.6, 92.8, 207545, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (16, N'CVS300 x 47', 47.5, 60.5, 300, 8, 200, 9.5, 9499, 633, 12.53, 710, 1268, 127, 4.58, 194, 5.28, 16.4, 267236, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (17, N'CVS300 x 57', 56.5, 72, 300, 8, 200, 12.5, 11725, 782, 12.76, 870, 1668, 167, 4.81, 254, 5.39, 30.9, 344401, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (18, N'CVS300 x 67', 67, 85.4, 300, 8, 200, 16, 14202, 947, 12.9, 1052, 2134, 213, 5, 324, 5.48, 59.5, 430165, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (19, N'CVS300 x 70', 70.3, 89.5, 300, 9.5, 200, 16, 14442, 963, 12.7, 1079, 2135, 214, 4.88, 326, 5.43, 62.7, 430165, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (20, N'CVS300 x 79', 79.2, 100.9, 300, 9.5, 200, 19, 16449, 1097, 12.77, 1231, 2535, 254, 5.01, 386, 5.48, 99.5, 500086, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (21, N'CVS300 x 85', 85.4, 108.8, 300, 12.5, 200, 19, 16899, 1127, 12.46, 1282, 2538, 254, 4.83, 390, 5.4, 109.7, 500086, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (22, N'CVS300 x 95', 95.4, 121.5, 300, 12.5, 200, 22.4, 19092, 1273, 12.54, 1447, 2991, 299, 4.96, 458, 5.46, 167.9, 575394, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (23, N'CVS300 x 55', 55, 70, 300, 8, 250, 9.5, 11504, 767, 12.82, 848, 2475, 198, 5.95, 301, 6.71, 19.2, 521945, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (24, N'CVS300 x 66', 66.3, 84.5, 300, 8, 250, 12.5, 14310, 954, 13.01, 1050, 3256, 260, 6.21, 395, 6.83, 37.5, 672658, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (25, N'CVS300 x 80', 79.6, 101.4, 300, 8, 250, 16, 17432, 1162, 13.11, 1280, 4168, 333, 6.41, 504, 6.91, 73.1, 840167, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (26, N'CVS300 x 83', 82.8, 105.5, 300, 9.5, 250, 16, 17672, 1178, 12.94, 1307, 4169, 334, 6.29, 506, 6.86, 76.4, 840167, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (27, N'CVS300 x 94', 94.1, 119.9, 300, 9.5, 250, 19, 20206, 1347, 12.98, 1498, 4950, 396, 6.43, 600, 6.92, 122.3, 976731, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (28, N'CVS300 x 100', 100.3, 127.8, 300, 12.5, 250, 19, 20655, 1377, 12.71, 1549, 4952, 396, 6.22, 604, 6.84, 132.6, 976731, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (29, N'CVS300 x 113', 113, 143.9, 300, 12.5, 250, 22.4, 23433, 1562, 12.76, 1758, 5837, 467, 6.37, 710, 6.9, 205.4, 1123817, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (30, N'CVS350 x 73', 73.3, 93.4, 350, 9.5, 250, 12.5, 20524, 1173, 14.82, 1306, 3258, 261, 5.91, 398, 6.69, 42.2, 926971, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (31, N'CVS350 x 87', 86.5, 110.2, 350, 9.5, 250, 16, 24874, 1421, 15.02, 1576, 4169, 334, 6.15, 507, 6.8, 77.8, 1162042, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (32, N'CVS350 x 98', 97.8, 124.6, 350, 9.5, 250, 19, 28454, 1626, 15.11, 1803, 4950, 396, 6.3, 601, 6.87, 123.8, 1355247, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (33, N'CVS350 x 105', 105.2, 134, 350, 12.5, 250, 19, 29213, 1669, 14.77, 1876, 4953, 396, 6.08, 606, 6.77, 135.9, 1355247, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (34, N'CVS350 x 118', 117.8, 150.1, 350, 12.5, 250, 22.4, 33169, 1895, 14.87, 2125, 5838, 467, 6.24, 712, 6.84, 208.7, 1565109, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (35, N'CVS350 x 128', 127.6, 162.5, 350, 12.5, 250, 25, 35885, 2051, 14.86, 2313, 6515, 521, 6.33, 793, 6.88, 281.6, 1719157, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (36, N'CVS350 x 136', 135.8, 173, 350, 16, 250, 25, 36673, 2096, 14.56, 2391, 6521, 522, 6.14, 800, 6.8, 304.8, 1719157, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (37, N'CVS400 x 82', 82.4, 105, 400, 8, 300, 12.5, 31680, 1584, 17.37, 1734, 5627, 375, 7.32, 569, 8.14, 45.7, 2111572, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (38, N'CVS400 x 87', 86.8, 110.6, 400, 9.5, 300, 12.5, 32339, 1617, 17.1, 1787, 5628, 375, 7.13, 571, 8.05, 50.1, 2111572, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (39, N'CVS400 x 103', 102.8, 131, 400, 9.5, 300, 16, 39355, 1968, 17.33, 2165, 7203, 480, 7.42, 728, 8.18, 92.9, 2654208, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (40, N'CVS400 x 116', 116.5, 148.4, 400, 9.5, 300, 19, 45161, 2258, 17.44, 2483, 8553, 570, 7.59, 863, 8.26, 148.1, 3102816, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (41, N'CVS400 x 125', 125.1, 159.3, 400, 12.5, 300, 19, 46347, 2317, 17.06, 2581, 8556, 570, 7.33, 869, 8.14, 162, 3102816, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (42, N'CVS400 x 140', 140.4, 178.8, 400, 12.5, 300, 22.4, 52813, 2641, 17.19, 2931, 10086, 672, 7.51, 1022, 8.22, 249.4, 3593060, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (43, N'CVS400 x 152', 152.1, 193.8, 400, 12.5, 300, 25, 57279, 2864, 17.19, 3195, 11256, 750, 7.62, 1139, 8.27, 336.9, 3955078, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (44, N'CVS400 x 162', 161.7, 206, 400, 16, 300, 25, 58529, 2926, 16.86, 3303, 11262, 751, 7.39, 1147, 8.17, 363.7, 3955078, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (45, N'CVS450 x 116', 116.4, 148.3, 450, 12.5, 300, 16, 52834, 2348, 18.87, 2629, 7207, 480, 6.97, 736, 7.97, 110.2, 3390408, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (46, N'CVS450 x 130', 129.9, 165.5, 450, 12.5, 300, 19, 60261, 2678, 19.08, 2987, 8557, 570, 7.19, 871, 8.07, 165.2, 3970641, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (47, N'CVS450 x 141', 141.2, 179.9, 450, 16, 300, 19, 62301, 2769, 18.61, 3136, 8564, 571, 6.9, 881, 7.93, 196, 3970641, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (48, N'CVS450 x 156', 156.4, 199.2, 450, 16, 300, 22.4, 70595, 3138, 18.83, 3530, 10094, 673, 7.12, 1034, 8.04, 283.2, 4607612, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (49, N'CVS450 x 168', 168, 214, 450, 16, 300, 25, 76346, 3393, 18.89, 3828, 11264, 751, 7.26, 1151, 8.1, 370.5, 5080078, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (50, N'CVS450 x 177', 177.4, 226, 450, 19, 300, 25, 77946, 3464, 18.57, 3948, 11273, 752, 7.06, 1161, 8.01, 409.7, 5080078, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (51, N'CVS450 x 188', 188.1, 239.6, 450, 22.4, 300, 25, 79759, 3545, 18.25, 4084, 11287, 752, 6.86, 1175, 7.91, 471.7, 5080078, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (52, N'CVS450 x 206', 206.1, 262.5, 450, 19, 300, 31.5, 92088, 4093, 18.73, 4666, 14197, 946, 7.35, 1452, 8.15, 720.8, 6206603, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (53, N'CVS450 x 216', 216.4, 275.7, 450, 22.4, 300, 31.5, 93730, 4166, 18.44, 4794, 14211, 947, 7.18, 1466, 8.07, 781.9, 6206603, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (54, N'CVS500 x 123', 122.9, 156.5, 500, 9.5, 350, 16, 73730, 2949, 21.71, 3231, 11437, 654, 8.55, 991, 9.5, 109.4, 6695817, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (55, N'CVS500 x 134', 133.8, 170.5, 500, 12.5, 350, 16, 76293, 3052, 21.15, 3395, 11441, 654, 8.19, 998, 9.33, 127.1, 6695817, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (56, N'CVS500 x 150', 149.8, 190.8, 500, 12.5, 350, 19, 87240, 3490, 21.38, 3866, 13585, 776, 8.44, 1182, 9.44, 191.4, 7853019, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (57, N'CVS500 x 162', 162.4, 206.9, 500, 16, 350, 19, 90116, 3605, 20.87, 4052, 13593, 777, 8.11, 1193, 9.28, 225.7, 7853019, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (58, N'CVS500 x 180', 180.2, 229.6, 500, 16, 350, 22.4, 102403, 4096, 21.12, 4572, 16022, 916, 8.35, 1401, 9.4, 327.5, 9127872, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (59, N'CVS500 x 194', 193.9, 247, 500, 16, 350, 25, 110952, 4438, 21.19, 4966, 17880, 1022, 8.51, 1560, 9.48, 429.4, 10076742, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (60, N'CVS500 x 204', 204.5, 260.5, 500, 19, 350, 25, 113230, 4529, 20.85, 5118, 17890, 1022, 8.29, 1572, 9.37, 473.2, 10076742, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (61, N'CVS500 x 217', 216.5, 275.8, 500, 22.4, 350, 25, 115812, 4632, 20.49, 5290, 17907, 1023, 8.06, 1588, 9.26, 542.5, 10076742, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (62, N'CVS500 x 238', 238.2, 303.5, 500, 19, 350, 31.5, 134391, 5376, 21.04, 6072, 22534, 1288, 8.62, 1969, 9.53, 836.4, 12351583, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (63, N'CVS500 x 250', 249.9, 318.4, 500, 22.4, 350, 31.5, 136755, 5470, 20.72, 6235, 22550, 1289, 8.42, 1984, 9.43, 904.8, 12351583, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (64, N'CVS500 x 259', 258.9, 329.8, 500, 25, 350, 31.5, 138564, 5543, 20.5, 6359, 22566, 1289, 8.27, 1998, 9.36, 973.3, 12351583, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (65, N'CVS500 x 281', 280.8, 357.7, 500, 22.4, 350, 37.5, 155013, 6201, 20.82, 7082, 26837, 1534, 8.66, 2350, 9.55, 1403.7, 14330048, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (66, N'CVS500 x 317', 316.8, 403.6, 500, 22.4, 350, 44.5, 175049, 7002, 20.83, 8040, 31837, 1819, 8.88, 2777, 9.64, 2226.8, 16494140, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (67, N'CVS550 x 184', 183.6, 233.9, 550, 16, 400, 19, 125087, 4549, 23.13, 5084, 20284, 1014, 9.31, 1553, 10.63, 255.4, 14286024, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (68, N'CVS550 x 204', 204.1, 260, 550, 16, 400, 22.4, 142463, 5180, 23.41, 5747, 23911, 1196, 9.59, 1824, 10.77, 371.8, 16627476, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (69, N'CVS550 x 220', 219.8, 280, 550, 16, 400, 25, 154583, 5621, 23.5, 6250, 26684, 1334, 9.76, 2032, 10.85, 488.3, 18375000, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (70, N'CVS550 x 232', 231.6, 295, 550, 19, 400, 25, 157708, 5735, 23.12, 6438, 26695, 1335, 9.51, 2045, 10.73, 536.7, 18375000, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (71, N'CVS550 x 245', 244.9, 312, 550, 22.4, 400, 25, 161250, 5864, 22.73, 6650, 26713, 1336, 9.25, 2063, 10.6, 613.4, 18375000, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (72, N'CVS550 x 270', 270.4, 344.5, 550, 19, 400, 31.5, 187867, 6832, 23.35, 7660, 33628, 1681, 9.88, 2564, 10.9, 952, 22582749, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (73, N'CVS550 x 283', 283.5, 361.1, 550, 22.4, 400, 31.5, 191139, 6951, 23.01, 7861, 33646, 1682, 9.65, 2581, 10.8, 1027.7, 22582749, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (74, N'CVS550 x 293', 293.4, 373.8, 550, 25, 400, 31.5, 193642, 7042, 22.76, 8015, 33663, 1683, 9.49, 2596, 10.72, 1103.5, 22582749, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (75, N'CVS550 x 319', 319, 406.4, 550, 22.4, 400, 37.5, 217349, 7904, 23.13, 8951, 40044, 2002, 9.93, 3060, 10.92, 1598.3, 26265625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (76, N'CVS550 x 329', 328.8, 418.8, 550, 25, 400, 37.5, 219671, 7988, 22.9, 9098, 40062, 2003, 9.78, 3074, 10.86, 1673.2, 26265625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (77, N'CVS550 x 361', 360.6, 459.3, 550, 22.4, 400, 44.5, 246298, 8956, 23.16, 10188, 47510, 2376, 10.17, 3618, 11.03, 2539.3, 30322923, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (78, N'CVS550 x 370', 370, 471.3, 550, 25, 400, 44.5, 248420, 9033, 22.96, 10326, 47527, 2376, 10.04, 3632, 10.97, 2613.2, 30322923, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (79, N'CVS600 x 156', 156.2, 199, 600, 12.5, 400, 16, 128254, 4275, 25.39, 4746, 17076, 854, 9.26, 1302, 10.61, 147.2, 14551723, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (80, N'CVS600 x 190', 189.9, 241.9, 600, 16, 400, 19, 151986, 5066, 25.07, 5679, 20286, 1014, 9.16, 1556, 10.55, 262.2, 17103091, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (81, N'CVS600 x 210', 210.4, 268, 600, 16, 400, 22.4, 172948, 5765, 25.4, 6407, 23912, 1196, 9.45, 1828, 10.7, 378.6, 19928340, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (82, N'CVS600 x 226', 226.1, 288, 600, 16, 400, 25, 187600, 6253, 25.52, 6960, 26685, 1334, 9.63, 2035, 10.78, 495.2, 22041667, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (83, N'CVS600 x 239', 239, 304.5, 600, 19, 400, 25, 191759, 6392, 25.09, 7187, 26698, 1335, 9.36, 2050, 10.66, 548.1, 22041667, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (84, N'CVS600 x 278', 277.9, 354, 600, 19, 400, 31.5, 228338, 7611, 25.4, 8533, 33631, 1682, 9.75, 2568, 10.84, 963.5, 27148149, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (85, N'CVS600 x 292', 292.3, 372.3, 600, 22.4, 400, 31.5, 232726, 7758, 25, 8778, 33650, 1683, 9.51, 2587, 10.73, 1046.5, 27148149, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (86, N'CVS600 x 328', 327.8, 417.6, 600, 22.4, 400, 37.5, 264668, 8822, 25.18, 9981, 40049, 2002, 9.79, 3066, 10.86, 1617, 31640625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (87, N'CVS600 x 339', 338.6, 431.3, 600, 25, 400, 37.5, 267803, 8927, 24.92, 10160, 40068, 2003, 9.64, 3082, 10.79, 1699.2, 31640625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (88, N'CVS600 x 369', 369.3, 470.5, 600, 22.4, 400, 44.5, 300131, 10004, 25.26, 11350, 47515, 2376, 10.05, 3624, 10.98, 2558, 36618190, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (89, N'CVS650 x 211', 211.1, 268.9, 650, 16, 450, 19, 200828, 6179, 27.33, 6893, 28877, 1283, 10.36, 1963, 11.91, 291.9, 28723583, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (90, N'CVS650 x 234', 234.2, 298.4, 650, 16, 450, 22.4, 228951, 7045, 27.7, 7790, 34041, 1513, 10.68, 2307, 12.06, 422.9, 33499644, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (91, N'CVS650 x 252', 252, 321, 650, 16, 450, 25, 248644, 7651, 27.83, 8471, 37989, 1688, 10.88, 2570, 12.16, 554.1, 37078857, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (92, N'CVS650 x 266', 266.1, 339, 650, 19, 450, 25, 254044, 7817, 27.38, 8741, 38003, 1689, 10.59, 2585, 12.02, 611.6, 37078857, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (93, N'CVS650 x 282', 282.1, 359.4, 650, 22.4, 450, 25, 260164, 8005, 26.91, 9047, 38025, 1690, 10.29, 2607, 11.87, 702.9, 37078857, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (94, N'CVS650 x 310', 310.1, 395, 650, 19, 450, 31.5, 303386, 9335, 27.71, 10404, 47874, 2128, 11.01, 3242, 12.22, 1079.1, 45752651, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (95, N'CVS650 x 326', 325.8, 415, 650, 22.4, 450, 31.5, 309117, 9511, 27.29, 10697, 47896, 2129, 10.74, 3263, 12.09, 1169.4, 45752651, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (96, N'CVS650 x 351', 350.7, 446.8, 650, 19, 450, 37.5, 347034, 10678, 27.87, 11906, 56986, 2533, 11.29, 3849, 12.34, 1722.1, 53415802, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (97, N'CVS650 x 366', 366, 466.3, 650, 22.4, 450, 37.5, 352421, 10844, 27.49, 12187, 57007, 2534, 11.06, 3869, 12.24, 1811.5, 53415802, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (98, N'CVS650 x 413', 413.1, 526.2, 650, 22.4, 450, 44.5, 400707, 12329, 27.6, 13888, 67637, 3006, 11.34, 4576, 12.36, 2870.5, 61946191, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (99, N'CVS650 x 461', 461.2, 587.5, 650, 25, 450, 50, 440599, 13557, 27.39, 15391, 76009, 3378, 11.37, 5148, 12.38, 4062.5, 68343750, 100, 1, 0)
GO
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (100, N'CVS700 x 214', 214.1, 272.8, 700, 12.5, 500, 19, 250564, 7159, 30.31, 7839, 39594, 1584, 12.05, 2401, 13.49, 273, 45893016, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (101, N'CVS700 x 232', 232.3, 295.9, 700, 16, 500, 19, 259026, 7401, 29.59, 8222, 39606, 1584, 11.57, 2417, 13.26, 321.6, 45893016, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (102, N'CVS700 x 278', 277.9, 354, 700, 16, 500, 25, 321513, 9186, 30.14, 10128, 52106, 2084, 12.13, 3167, 13.53, 613, 59326172, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (103, N'CVS700 x 293', 293.2, 373.5, 700, 19, 500, 25, 328378, 9382, 29.65, 10444, 52120, 2085, 11.81, 3184, 13.38, 675.2, 59326172, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (104, N'CVS700 x 327', 327.3, 416.9, 700, 16, 500, 31.5, 386651, 11047, 30.45, 12152, 65647, 2626, 12.55, 3978, 13.71, 1133.1, 73318260, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (105, N'CVS700 x 342', 342.3, 436, 700, 19, 500, 31.5, 393113, 11232, 30.03, 12456, 65661, 2626, 12.27, 3995, 13.59, 1194.7, 73318260, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (106, N'CVS750 x 284', 284.2, 362, 750, 16, 500, 25, 374379, 9983, 32.16, 11023, 52107, 2084, 12, 3170, 13.46, 619.8, 68440755, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (107, N'CVS750 x 301', 300.7, 383, 750, 19, 500, 25, 382954, 10212, 31.62, 11390, 52123, 2085, 11.67, 3188, 13.3, 686.6, 68440755, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (108, N'CVS750 x 334', 333.5, 424.9, 750, 16, 500, 31.5, 450034, 12001, 32.54, 13204, 65648, 2626, 12.43, 3981, 13.66, 1140, 84695994, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (109, N'CVS750 x 350', 349.7, 445.5, 750, 19, 500, 31.5, 458140, 12217, 32.07, 13558, 65664, 2627, 12.14, 4000, 13.53, 1206.1, 84695994, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (110, N'CVS800 x 288', 288.3, 367.2, 800, 16, 550, 22.4, 431525, 10788, 34.28, 11860, 62139, 2260, 13.01, 3436, 14.72, 518.3, 93893894, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (111, N'CVS800 x 310', 310.1, 395, 800, 16, 550, 25, 469323, 11733, 34.47, 12906, 69349, 2522, 13.25, 3829, 14.84, 678.7, 104092692, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (112, N'CVS800 x 328', 327.7, 417.5, 800, 19, 550, 25, 479870, 11997, 33.9, 13328, 69366, 2522, 12.89, 3849, 14.66, 750.1, 104092692, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (113, N'CVS800 x 365', 364.6, 464.4, 800, 16, 550, 31.5, 565262, 14132, 34.89, 15487, 87372, 3177, 13.72, 4812, 15.05, 1251, 128965969, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (114, N'CVS800 x 382', 381.9, 486.5, 800, 19, 550, 31.5, 575270, 14382, 34.39, 15894, 87389, 3178, 13.4, 4831, 14.91, 1321.8, 128965969, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (115, N'CVS850 x 336', 336, 428, 850, 16, 600, 25, 578892, 13621, 36.78, 14935, 90027, 3001, 14.5, 4551, 16.21, 737.6, 153140625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (116, N'CVS850 x 355', 354.8, 452, 850, 19, 600, 25, 591692, 13922, 36.18, 15415, 90046, 3002, 14.11, 4572, 16.02, 813.6, 153140625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (117, N'CVS850 x 396', 395.6, 503.9, 850, 16, 600, 31.5, 698400, 16433, 37.23, 17947, 113427, 3781, 15, 5720, 16.43, 1362, 189928628, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (118, N'CVS850 x 414', 414.1, 527.5, 850, 19, 600, 31.5, 710587, 16720, 36.7, 18412, 113445, 3782, 14.66, 5741, 16.28, 1437.4, 189928628, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (119, N'CVS900 x 342', 342.3, 436, 900, 16, 600, 25, 656258, 14584, 38.8, 16015, 90029, 3001, 14.37, 4554, 16.14, 744.5, 172265625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (120, N'CVS900 x 362', 362.3, 461.5, 900, 19, 600, 25, 671611, 14925, 38.15, 16557, 90049, 3002, 13.97, 4577, 15.95, 825.1, 172265625, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (121, N'CVS900 x 402', 401.8, 511.9, 900, 16, 600, 31.5, 791302, 17584, 39.32, 19217, 113429, 3781, 14.89, 5724, 16.38, 1368.8, 213841853, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (122, N'CVS900 x 422', 421.5, 537, 900, 19, 600, 31.5, 805962, 17910, 38.74, 19742, 113448, 3782, 14.53, 5746, 16.22, 1448.8, 213841853, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (123, N'CVS950 x 368', 368.2, 469, 950, 16, 650, 25, 792565, 16686, 41.11, 18271, 114458, 3522, 15.62, 5339, 17.52, 803.4, 244766683, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (124, N'CVS950 x 389', 389.4, 496, 950, 19, 650, 25, 810790, 17069, 40.43, 18879, 114479, 3522, 15.19, 5362, 17.31, 888.6, 244766683, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (125, N'CVS950 x 433', 432.8, 551.4, 950, 16, 650, 31.5, 957066, 20149, 41.66, 21953, 144208, 4437, 16.17, 6711, 17.77, 1479.8, 304086894, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (126, N'CVS950 x 454', 453.7, 578, 950, 19, 650, 31.5, 974513, 20516, 41.06, 22543, 144229, 4438, 15.8, 6734, 17.6, 1564.4, 304086894, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (127, N'CVS1000 x 394', 394.1, 502, 1000, 16, 700, 25, 946296, 18926, 43.42, 20673, 142949, 4084, 16.87, 6186, 18.89, 862.3, 339650391, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (128, N'CVS1000 x 416', 416.4, 530.5, 1000, 19, 700, 25, 967730, 19355, 42.71, 21349, 142971, 4085, 16.42, 6211, 18.67, 952.1, 339650391, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (129, N'CVS1000 x 464', 463.9, 590.9, 1000, 16, 700, 31.5, 1144189, 22884, 44, 24867, 180107, 5146, 17.46, 7777, 19.15, 1590.8, 422272386, 100, 1, 0)
INSERT [dbo].[CVS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (130, N'CVS1000 x 486', 485.9, 619, 1000, 19, 700, 31.5, 1164755, 23295, 43.38, 25526, 180129, 5147, 17.06, 7802, 18.97, 1680, 422272386, 100, 1, 0)
SET IDENTITY_INSERT [dbo].[CVS] OFF
SET IDENTITY_INSERT [dbo].[VS] ON 

INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (1, N'VS200 x 19', 18.8, 24, 200, 4.8, 120, 6.3, 1720, 172, 8.5, 188, 182, 30, 2.8, 46, 3.2, 2.7, 17019, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (2, N'VS200 x 22', 21.9, 27.9, 200, 4.8, 120, 8, 2017, 202, 8.5, 225, 231, 39, 2.9, 59, 3.2, 4.8, 21234, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (3, N'VS200 x 25', 24.6, 31.4, 200, 4.8, 120, 9.5, 2305, 231, 8.6, 256, 274, 46, 3, 69, 3.3, 7.5, 24823, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (4, N'VS200 x 20', 19.9, 25.3, 200, 4.8, 130, 6.3, 1841, 184, 8.5, 200, 231, 36, 3, 54, 3.5, 2.9, 21638, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (5, N'VS200 x 23', 23.2, 29.5, 200, 4.8, 130, 8, 2165, 217, 8.6, 240, 293, 45, 3.2, 69, 3.5, 5.1, 26997, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (6, N'VS200 x 26', 26.1, 33.3, 200, 4.8, 130, 9.5, 2477, 248, 8.6, 274, 348, 54, 3.2, 81, 3.6, 8.1, 31560, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (7, N'VS250 x 21', 20.7, 26.4, 250, 4.8, 120, 6.3, 2840, 227, 10.4, 251, 182, 30, 2.6, 47, 3.1, 2.9, 26939, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (8, N'VS250 x 24', 23.8, 30.3, 250, 4.8, 120, 8, 3319, 266, 10.5, 297, 231, 39, 2.8, 59, 3.2, 5, 33733, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (9, N'VS250 x 27', 26.5, 33.8, 250, 4.8, 120, 9.5, 3787, 303, 10.6, 338, 274, 46, 2.9, 70, 3.2, 7.7, 39563, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (10, N'VS250 x 23', 22.7, 28.9, 250, 4.8, 140, 6.3, 3225, 258, 10.6, 282, 288, 41, 3.2, 63, 3.7, 3.2, 42778, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (11, N'VS250 x 26', 26.3, 33.5, 250, 4.8, 140, 8, 3788, 303, 10.6, 336, 366, 52, 3.3, 80, 3.7, 5.6, 53567, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (12, N'VS250 x 30', 29.5, 37.6, 250, 4.8, 140, 9.5, 4336, 347, 10.7, 383, 435, 62, 3.4, 94, 3.8, 8.9, 62824, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (13, N'VS250 x 25', 24.6, 31.4, 250, 4.8, 160, 6.3, 3611, 289, 10.7, 312, 430, 54, 3.7, 82, 4.2, 3.5, 63856, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (14, N'VS250 x 29', 28.8, 36.7, 250, 4.8, 160, 8, 4257, 341, 10.8, 375, 546, 68, 3.9, 104, 4.3, 6.3, 79959, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (15, N'VS250 x 32', 32.5, 41.4, 250, 4.8, 160, 9.5, 4886, 391, 10.9, 429, 649, 81, 4, 123, 4.4, 10, 93778, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (16, N'VS300 x 23', 22.6, 28.8, 300, 4.8, 120, 6.3, 4296, 286, 12.2, 320, 182, 30, 2.5, 47, 3, 3, 39127, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (17, N'VS300 x 26', 25.7, 32.7, 300, 4.8, 120, 8, 5000, 333, 12.4, 376, 231, 39, 2.7, 59, 3.1, 5.1, 49112, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (18, N'VS300 x 28', 28.3, 36.1, 300, 4.8, 120, 9.5, 5690, 379, 12.6, 425, 274, 46, 2.8, 70, 3.2, 7.9, 57723, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (19, N'VS300 x 25', 24.6, 31.3, 300, 4.8, 140, 6.3, 4856, 324, 12.5, 357, 288, 41, 3, 63, 3.6, 3.4, 62133, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (20, N'VS300 x 28', 28.2, 35.9, 300, 4.8, 140, 8, 5683, 379, 12.6, 423, 366, 52, 3.2, 80, 3.7, 5.8, 77988, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (21, N'VS300 x 31', 31.3, 39.9, 300, 4.8, 140, 9.5, 6492, 433, 12.8, 480, 435, 62, 3.3, 95, 3.7, 9, 91662, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (22, N'VS300 x 27', 26.5, 33.8, 300, 4.8, 160, 6.3, 5416, 361, 12.7, 394, 430, 54, 3.6, 82, 4.2, 3.7, 92746, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (23, N'VS300 x 31', 30.7, 39.1, 300, 4.8, 160, 8, 6365, 424, 12.8, 470, 546, 68, 3.7, 104, 4.3, 6.5, 116414, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (24, N'VS300 x 34', 34.3, 43.7, 300, 4.8, 160, 9.5, 7294, 486, 12.9, 535, 649, 81, 3.9, 123, 4.3, 10.2, 136825, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (25, N'VS300 x 33', 33.2, 42.3, 300, 4.8, 180, 8, 7047, 470, 12.9, 516, 778, 86, 4.3, 131, 4.8, 7.2, 165753, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (26, N'VS300 x 37', 37.3, 47.5, 300, 4.8, 180, 9.5, 8096, 540, 13.1, 591, 924, 103, 4.4, 155, 4.9, 11.3, 194815, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (27, N'VS300 x 46', 45.6, 58.1, 300, 4.8, 180, 12.5, 10128, 675, 13.2, 737, 1215, 135, 4.6, 204, 5, 24.5, 251068, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (28, N'VS350 x 26', 26.4, 33.6, 350, 4.8, 140, 6.3, 6884, 393, 14.3, 438, 288, 41, 2.9, 64, 3.5, 3.6, 85089, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (29, N'VS350 x 30', 30.1, 38.3, 350, 4.8, 140, 8, 8026, 459, 14.5, 516, 366, 52, 3.1, 80, 3.6, 6, 106983, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (30, N'VS350 x 33', 33.2, 42.3, 350, 4.8, 140, 9.5, 9148, 523, 14.7, 583, 435, 62, 3.2, 95, 3.7, 9.2, 125930, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (31, N'VS350 x 28', 28.4, 36.2, 350, 4.8, 160, 6.3, 7651, 437, 14.5, 481, 430, 54, 3.5, 83, 4.1, 3.9, 127013, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (32, N'VS350 x 33', 32.6, 41.5, 350, 4.8, 160, 8, 8962, 512, 14.7, 570, 546, 68, 3.6, 104, 4.2, 6.7, 159695, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (33, N'VS350 x 36', 36.2, 46.1, 350, 4.8, 160, 9.5, 10249, 586, 14.9, 648, 649, 81, 3.8, 123, 4.3, 10.4, 187978, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (34, N'VS350 x 30', 30.4, 38.7, 350, 4.8, 180, 6.3, 8418, 481, 14.8, 525, 613, 68, 4, 104, 4.7, 4.2, 180845, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (35, N'VS350 x 35', 35.1, 44.7, 350, 4.8, 180, 8, 9898, 566, 14.9, 625, 778, 86, 4.2, 131, 4.8, 7.4, 227378, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (36, N'VS350 x 39', 39.2, 49.9, 350, 4.8, 180, 9.5, 11351, 649, 15.1, 712, 924, 103, 4.3, 156, 4.8, 11.5, 267648, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (37, N'VS350 x 38', 37.6, 47.9, 350, 4.8, 200, 8, 10834, 619, 15, 680, 1067, 107, 4.7, 162, 5.4, 8, 311904, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (38, N'VS350 x 42', 42.2, 53.7, 350, 4.8, 200, 9.5, 12453, 712, 15.2, 777, 1267, 127, 4.9, 192, 5.4, 12.6, 367144, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (39, N'VS350 x 51', 51.3, 65.4, 350, 4.8, 200, 12.5, 15604, 892, 15.5, 969, 1667, 167, 5.1, 252, 5.5, 27.2, 474609, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (40, N'VS400 x 28', 28.3, 36, 400, 4.8, 140, 6.3, 9340, 467, 16.1, 525, 288, 41, 2.8, 64, 3.5, 3.7, 111646, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (41, N'VS400 x 32', 31.9, 40.6, 400, 4.8, 140, 8, 10848, 542, 16.4, 614, 366, 52, 3, 81, 3.6, 6.2, 140551, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (42, N'VS400 x 35', 35.1, 44.7, 400, 4.8, 140, 9.5, 12332, 617, 16.6, 692, 435, 62, 3.1, 95, 3.7, 9.4, 165630, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (43, N'VS400 x 30', 30.2, 38.5, 400, 4.8, 160, 6.3, 10347, 517, 16.4, 575, 430, 54, 3.3, 83, 4.1, 4.1, 166656, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (44, N'VS400 x 34', 34.4, 43.8, 400, 4.8, 160, 8, 12077, 604, 16.6, 677, 546, 68, 3.5, 105, 4.2, 6.9, 209803, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (45, N'VS400 x 38', 38.1, 48.5, 400, 4.8, 160, 9.5, 13781, 689, 16.9, 766, 649, 81, 3.7, 124, 4.2, 10.5, 247238, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (46, N'VS400 x 32', 32.3, 41.1, 400, 4.8, 180, 6.3, 11353, 568, 16.6, 624, 613, 68, 3.9, 104, 4.6, 4.4, 237289, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (47, N'VS400 x 37', 36.9, 47, 400, 4.8, 180, 8, 13307, 665, 16.8, 740, 778, 86, 4.1, 132, 4.7, 7.5, 298723, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (48, N'VS400 x 41', 41.1, 52.3, 400, 4.8, 180, 9.5, 15230, 762, 17.1, 840, 924, 103, 4.2, 156, 4.8, 11.7, 352024, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (49, N'VS400 x 39', 39.4, 50.2, 400, 4.8, 200, 8, 14536, 727, 17, 802, 1067, 107, 4.6, 162, 5.3, 8.2, 409771, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (50, N'VS400 x 44', 44, 56.1, 400, 4.8, 200, 9.5, 16679, 834, 17.2, 914, 1267, 127, 4.8, 192, 5.4, 12.8, 482886, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (51, N'VS400 x 53', 53.2, 67.8, 400, 4.8, 200, 12.5, 20863, 1043, 17.5, 1136, 1667, 167, 5, 252, 5.5, 27.4, 625651, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (52, N'VS450 x 51', 51.2, 65.2, 450, 6.3, 200, 9.5, 22640, 1006, 18.6, 1130, 1268, 127, 4.4, 194, 5.2, 15.1, 614461, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (53, N'VS450 x 60', 60.3, 76.8, 450, 6.3, 200, 12.5, 27962, 1243, 19.1, 1378, 1668, 167, 4.7, 254, 5.3, 29.7, 797526, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (54, N'VS450 x 71', 70.9, 90.3, 450, 6.3, 200, 16, 33985, 1510, 19.4, 1664, 2134, 213, 4.9, 324, 5.4, 58.2, 1004565, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (55, N'VS450 x 80', 80.1, 102, 450, 6.3, 200, 19, 38989, 1733, 19.6, 1905, 2534, 253, 5, 384, 5.5, 95, 1176486, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (56, N'VS450 x 59', 58.6, 74.7, 450, 6.3, 250, 9.5, 27249, 1211, 19.1, 1339, 2475, 198, 5.8, 301, 6.6, 18, 1200119, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (57, N'VS450 x 70', 70.1, 89.3, 450, 6.3, 250, 12.5, 33946, 1509, 19.5, 1652, 3256, 260, 6, 395, 6.8, 36.2, 1557668, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (58, N'VS450 x 83', 83.4, 106.3, 450, 6.3, 250, 16, 41523, 1845, 19.8, 2011, 4168, 333, 6.3, 504, 6.9, 71.9, 1962042, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (59, N'VS450 x 95', 95, 121, 450, 6.3, 250, 19, 47818, 2125, 19.9, 2315, 4949, 396, 6.4, 598, 6.9, 117.9, 2297825, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (60, N'VS500 x 61', 61.1, 77.8, 500, 6.3, 250, 9.5, 34416, 1377, 21, 1529, 2475, 198, 5.6, 302, 6.6, 18.4, 1488026, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (61, N'VS500 x 73', 72.5, 92.4, 500, 6.3, 250, 12.5, 42768, 1711, 21.5, 1879, 3256, 260, 5.9, 395, 6.7, 36.6, 1934052, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (62, N'VS500 x 86', 86, 109.5, 500, 6.3, 250, 16, 52250, 2090, 21.8, 2281, 4168, 333, 6.2, 505, 6.8, 72.3, 2440167, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (63, N'VS500 x 97', 97.4, 124.1, 500, 6.3, 250, 19, 60154, 2406, 22, 2621, 4949, 396, 6.3, 598, 6.9, 118.3, 2861887, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (64, N'VS550 x 64', 63.6, 81, 550, 6.3, 250, 9.5, 42556, 1547, 22.9, 1728, 2475, 198, 5.5, 302, 6.5, 18.8, 1806857, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (65, N'VS550 x 75', 75, 95.6, 550, 6.3, 250, 12.5, 52747, 1918, 23.5, 2114, 3256, 260, 5.8, 396, 6.7, 37, 2351125, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (66, N'VS550 x 88', 88.4, 112.6, 550, 6.3, 250, 16, 64345, 2340, 23.9, 2559, 4168, 333, 6.1, 505, 6.8, 72.7, 2970375, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (67, N'VS550 x 100', 99.9, 127.3, 550, 6.3, 250, 19, 74041, 2692, 24.1, 2935, 4949, 396, 6.2, 599, 6.8, 118.7, 3487799, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (68, N'VS600 x 81', 81.2, 103.5, 600, 8, 300, 9.5, 62768, 2092, 24.6, 2358, 4277, 285, 6.4, 437, 7.7, 27.2, 3726627, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (69, N'VS600 x 95', 95, 121, 600, 8, 300, 12.5, 77401, 2580, 25.3, 2864, 5627, 375, 6.8, 572, 7.9, 49.1, 4853760, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (70, N'VS600 x 111', 111, 141.4, 600, 8, 300, 16, 94091, 3136, 25.8, 3448, 7202, 480, 7.1, 729, 8.1, 91.9, 6139008, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (71, N'VS600 x 125', 124.8, 159, 600, 8, 300, 19, 108073, 3602, 26.1, 3943, 8552, 570, 7.3, 864, 8.1, 147.1, 7215366, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (72, N'VS600 x 140', 140.4, 178.8, 600, 8, 300, 22.4, 124012, 4134, 26.3, 4498, 10082, 672, 7.5, 1017, 8.2, 234.6, 8407268, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (73, N'VS600 x 152', 152.3, 194, 600, 8, 300, 25, 135154, 4505, 26.4, 4918, 11252, 750, 7.6, 1134, 8.3, 322.3, 9298828, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (74, N'VS650 x 84', 84.4, 107.5, 650, 8, 300, 9.5, 75213, 2314, 26.5, 2622, 4278, 285, 6.3, 438, 7.6, 28.1, 4384443, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (75, N'VS650 x 98', 98.1, 125, 650, 8, 300, 12.5, 92487, 2846, 27.2, 3172, 5628, 375, 6.7, 573, 7.8, 49.9, 5715088, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (76, N'VS650 x 114', 114.1, 145.4, 650, 8, 300, 16, 112225, 3453, 27.8, 3807, 7203, 480, 7, 730, 8, 92.7, 7235208, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (77, N'VS650 x 128', 128, 163, 650, 8, 300, 19, 128792, 3963, 28.1, 4346, 8553, 570, 7.2, 865, 8.1, 147.9, 8510691, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (78, N'VS650 x 143', 143.5, 182.8, 650, 8, 300, 22.4, 147713, 4545, 28.4, 4950, 10083, 672, 7.4, 1018, 8.2, 235.5, 9925820, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (79, N'VS650 x 155', 155.4, 198, 650, 8, 300, 25, 160963, 4953, 28.5, 5408, 11253, 750, 7.5, 1135, 8.2, 323.2, 10986328, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (80, N'VS700 x 105', 105.2, 134, 700, 8, 320, 12.5, 115045, 3287, 29.3, 3661, 6830, 427, 7.1, 651, 8.4, 53.4, 8066667, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (81, N'VS700 x 122', 122.3, 155.8, 700, 8, 320, 16, 139665, 3990, 29.9, 4395, 8741, 546, 7.5, 830, 8.5, 99.1, 10220470, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (82, N'VS700 x 137', 137.1, 174.6, 700, 8, 320, 19, 160361, 4582, 30.3, 5017, 10379, 649, 7.7, 983, 8.6, 157.9, 12030579, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (83, N'VS700 x 154', 153.7, 195.8, 700, 8, 320, 22.4, 184037, 5258, 30.7, 5715, 12236, 765, 7.9, 1157, 8.7, 251.3, 14042147, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (84, N'VS700 x 166', 166.4, 212, 700, 8, 320, 25, 200642, 5733, 30.8, 6245, 13656, 854, 8, 1290, 8.8, 344.9, 15552000, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (85, N'VS750 x 108', 108.3, 138, 750, 8, 320, 12.5, 134197, 3579, 31.2, 4001, 6830, 427, 7, 652, 8.3, 54.3, 9282667, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (86, N'VS750 x 125', 125.4, 159.8, 750, 8, 320, 16, 162620, 4337, 31.9, 4789, 8741, 546, 7.4, 831, 8.5, 99.9, 11769304, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (87, N'VS750 x 140', 140.2, 178.6, 750, 8, 320, 19, 186545, 4975, 32.3, 5458, 10380, 649, 7.6, 984, 8.6, 158.8, 13862037, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (88, N'VS750 x 157', 156.8, 199.8, 750, 8, 320, 22.4, 213953, 5705, 32.7, 6209, 12236, 765, 7.8, 1158, 8.7, 252.2, 16190941, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (89, N'VS750 x 170', 169.6, 216, 750, 8, 320, 25, 233200, 6219, 32.9, 6780, 13656, 854, 8, 1291, 8.7, 345.7, 17941333, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (90, N'VS800 x 111', 111.5, 142, 800, 8, 320, 12.5, 155074, 3877, 33.1, 4351, 6830, 427, 6.9, 652, 8.2, 55.1, 10584000, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (91, N'VS800 x 129', 128.6, 163.8, 800, 8, 320, 16, 187573, 4689, 33.8, 5194, 8741, 546, 7.3, 831, 8.4, 100.8, 13427365, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (92, N'VS800 x 143', 143.3, 182.6, 800, 8, 320, 19, 214961, 5374, 34.3, 5910, 10380, 649, 7.5, 985, 8.6, 159.7, 15823202, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (93, N'VS800 x 160', 160, 203.8, 800, 8, 320, 22.4, 246374, 6159, 34.8, 6714, 12237, 765, 7.8, 1159, 8.7, 253, 18492653, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (94, N'VS800 x 173', 172.7, 220, 800, 8, 320, 25, 268458, 6711, 34.9, 7325, 13657, 854, 7.9, 1292, 8.7, 346.6, 20501333, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (95, N'VS850 x 120', 120.5, 153.5, 850, 8, 350, 12.5, 190878, 4491, 35.3, 5025, 8936, 511, 7.6, 779, 9, 59.9, 15662913, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (96, N'VS850 x 139', 139.3, 177.4, 850, 8, 350, 16, 231269, 5442, 36.1, 6009, 11437, 654, 8, 993, 9.2, 109.8, 19881309, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (97, N'VS850 x 155', 155.4, 198, 850, 8, 350, 19, 265344, 6243, 36.6, 6845, 13581, 776, 8.3, 1177, 9.4, 174.2, 23439511, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (98, N'VS850 x 174', 173.6, 221.2, 850, 8, 350, 22.4, 304467, 7164, 37.1, 7784, 16010, 915, 8.5, 1385, 9.5, 276.4, 27408286, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (99, N'VS850 x 188', 187.6, 239, 850, 8, 350, 25, 331998, 7812, 37.3, 8499, 17868, 1021, 8.7, 1544, 9.5, 378.7, 30397705, 100, 1, 0)
GO
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (100, N'VS900 x 124', 123.6, 157.5, 900, 8, 350, 12.5, 216973, 4822, 37.1, 5414, 8936, 511, 7.5, 780, 9, 60.7, 17588938, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (101, N'VS900 x 142', 142.4, 181.4, 900, 8, 350, 16, 262430, 5832, 38, 6457, 11437, 654, 7.9, 994, 9.2, 110.7, 22336617, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (102, N'VS900 x 159', 158.6, 202, 900, 8, 350, 19, 300814, 6685, 38.6, 7345, 13581, 776, 8.2, 1178, 9.3, 175.1, 26345006, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (103, N'VS900 x 177', 176.8, 225.2, 900, 8, 350, 22.4, 344925, 7665, 39.1, 8342, 16010, 915, 8.4, 1386, 9.4, 277.2, 30820107, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (104, N'VS900 x 191', 190.8, 243, 900, 8, 350, 25, 375994, 8355, 39.3, 9101, 17868, 1021, 8.6, 1545, 9.5, 379.5, 34193929, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (105, N'VS950 x 127', 126.8, 161.5, 950, 8, 350, 12.5, 245036, 5159, 39, 5813, 8936, 511, 7.4, 780, 8.9, 61.6, 19626617, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (106, N'VS950 x 146', 145.5, 185.4, 950, 8, 350, 16, 295858, 6229, 40, 6916, 11437, 654, 7.9, 995, 9.2, 111.5, 24934842, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (107, N'VS950 x 162', 161.7, 206, 950, 8, 350, 19, 338808, 7133, 40.6, 7855, 13581, 776, 8.1, 1178, 9.3, 175.9, 29420216, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (108, N'VS950 x 180', 179.9, 229.2, 950, 8, 350, 22.4, 388207, 8173, 41.2, 8910, 16011, 915, 8.4, 1386, 9.4, 278.1, 34432011, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (109, N'VS950 x 194', 193.9, 247, 950, 8, 350, 25, 423027, 8906, 41.4, 9714, 17868, 1021, 8.5, 1546, 9.5, 380.4, 38213460, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (110, N'VS1000 x 140', 139.7, 178, 1000, 8, 400, 12.5, 305593, 6112, 41.4, 6839, 13337, 667, 8.7, 1016, 10.3, 68.9, 32505208, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (111, N'VS1000 x 161', 161.2, 205.4, 1000, 8, 400, 16, 370339, 7407, 42.5, 8172, 17071, 854, 9.1, 1295, 10.5, 126, 41312256, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (112, N'VS1000 x 180', 179.8, 229, 1000, 8, 400, 19, 425095, 8502, 43.1, 9306, 20271, 1014, 9.4, 1535, 10.7, 199.6, 48759624, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (113, N'VS1000 x 201', 200.6, 255.6, 1000, 8, 400, 22.4, 488119, 9762, 43.7, 10583, 23897, 1195, 9.7, 1807, 10.8, 316.4, 57087252, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (114, N'VS1000 x 217', 216.7, 276, 1000, 8, 400, 25, 532575, 10652, 43.9, 11555, 26671, 1334, 9.8, 2015, 10.9, 433.3, 63375000, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (115, N'VS1100 x 159', 158.6, 202.1, 1100, 9.5, 400, 12.5, 394026, 7164, 44.2, 8182, 13341, 667, 8.1, 1024, 10, 83.2, 39421875, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (116, N'VS1100 x 180', 180.2, 229.5, 1100, 9.5, 400, 16, 472485, 8591, 45.4, 9647, 17074, 854, 8.6, 1304, 10.3, 140.2, 50135723, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (117, N'VS1100 x 199', 198.5, 252.9, 1100, 9.5, 400, 19, 538922, 9799, 46.2, 10894, 20274, 1014, 9, 1544, 10.5, 213.8, 59207091, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (118, N'VS1100 x 219', 219.3, 279.4, 1100, 9.5, 400, 22.4, 615490, 11191, 46.9, 12299, 23901, 1195, 9.3, 1816, 10.6, 330.5, 69363646, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (119, N'VS1100 x 235', 235.3, 299.8, 1100, 9.5, 400, 25, 669562, 12174, 47.3, 13368, 26674, 1334, 9.4, 2024, 10.7, 447.4, 77041667, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (120, N'VS1200 x 200', 200.2, 255, 1200, 9.5, 450, 16, 630844, 10514, 49.7, 11765, 24308, 1080, 9.8, 1646, 11.6, 156.7, 85162752, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (121, N'VS1200 x 221', 220.9, 281.4, 1200, 9.5, 450, 19, 720523, 12009, 50.6, 13304, 28865, 1283, 10.1, 1950, 11.8, 239.5, 100618930, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (122, N'VS1200 x 244', 244.4, 311.3, 1200, 9.5, 450, 22.4, 823984, 13733, 51.5, 15039, 34028, 1512, 10.5, 2294, 12, 370.8, 117942387, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (123, N'VS1200 x 262', 262.4, 334.3, 1200, 9.5, 450, 25, 897121, 14952, 51.8, 16360, 37977, 1688, 10.7, 2557, 12.1, 502.3, 131051514, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (124, N'VS1200 x 307', 307.3, 391.5, 1200, 9.5, 450, 31.5, 1084322, 18072, 52.6, 19634, 47849, 2127, 11.1, 3215, 12.2, 971.1, 163303047, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (125, N'VS1300 x 237', 237.5, 302.5, 1300, 12.5, 450, 16, 805914, 12399, 51.6, 14269, 24321, 1081, 9, 1670, 11.1, 206.5, 100155852, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (126, N'VS1300 x 258', 258.1, 328.8, 1300, 12.5, 450, 19, 910929, 14014, 52.6, 15930, 28877, 1283, 9.4, 1973, 11.4, 289.2, 118379952, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (127, N'VS1300 x 281', 281.4, 358.5, 1300, 12.5, 450, 22.4, 1032190, 15880, 53.7, 17800, 34040, 1513, 9.7, 2317, 11.6, 420.4, 138823863, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (128, N'VS1300 x 299', 299.3, 381.3, 1300, 12.5, 450, 25, 1117982, 17200, 54.2, 19227, 37989, 1688, 10, 2580, 11.7, 551.8, 154307373, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (129, N'VS1300 x 344', 343.9, 438.1, 1300, 12.5, 450, 31.5, 1337847, 20582, 55.3, 22763, 47861, 2127, 10.5, 3238, 12, 1020.3, 192449947, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (130, N'VS1400 x 260', 259.8, 331, 1400, 12.5, 500, 16, 1032894, 14756, 55.9, 16920, 33356, 1334, 10, 2053, 12.4, 226.6, 159621333, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (131, N'VS1400 x 283', 282.8, 360.3, 1400, 12.5, 500, 19, 1169143, 16702, 57, 18917, 39606, 1584, 10.5, 2428, 12.7, 318.5, 188729474, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (132, N'VS1400 x 309', 308.8, 393.4, 1400, 12.5, 500, 22.4, 1326589, 18951, 58.1, 21167, 46689, 1868, 10.9, 2853, 12.9, 464.3, 221407872, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (133, N'VS1400 x 329', 328.8, 418.8, 1400, 12.5, 500, 25, 1438060, 20544, 58.6, 22883, 52105, 2084, 11.2, 3178, 13, 610.4, 246175130, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (134, N'VS1400 x 378', 378.4, 482.1, 1400, 12.5, 500, 31.5, 1724041, 24629, 59.8, 27140, 65647, 2626, 11.7, 3990, 13.3, 1131, 307254979, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (135, N'VS1400 x 424', 424.4, 540.6, 1400, 12.5, 500, 37.5, 1983133, 28330, 60.6, 31033, 78147, 3126, 12, 4739, 13.5, 1846.5, 362579346, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (136, N'VS1400 x 478', 478, 608.9, 1400, 12.5, 500, 44.5, 2279533, 32565, 61.2, 35531, 92730, 3709, 12.3, 5614, 13.6, 3025.6, 425851152, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (137, N'VS1500 x 270', 269.6, 343.5, 1500, 12.5, 500, 16, 1210476, 16140, 59.4, 18606, 33357, 1334, 9.9, 2057, 12.3, 233.1, 183521333, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (138, N'VS1500 x 293', 292.6, 372.8, 1500, 12.5, 500, 19, 1367419, 18232, 60.6, 20749, 39607, 1584, 10.3, 2432, 12.6, 325.1, 217051349, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (139, N'VS1500 x 319', 318.6, 405.9, 1500, 12.5, 500, 22.4, 1548898, 20652, 61.8, 23165, 46690, 1868, 10.7, 2857, 12.8, 470.8, 254718539, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (140, N'VS1500 x 339', 338.6, 431.3, 1500, 12.5, 500, 25, 1677461, 22366, 62.4, 25008, 52107, 2084, 11, 3182, 13, 616.9, 283284505, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (141, N'VS1500 x 388', 388.3, 494.6, 1500, 12.5, 500, 31.5, 2007598, 26768, 63.7, 29582, 65648, 2626, 11.5, 3994, 13.2, 1137.5, 353799510, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (142, N'VS1500 x 434', 434.2, 553.1, 1500, 12.5, 500, 37.5, 2307085, 30761, 64.6, 33768, 78148, 3126, 11.9, 4743, 13.4, 1853, 417755127, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (143, N'VS1500 x 488', 487.8, 621.4, 1500, 12.5, 500, 44.5, 2650168, 35336, 65.3, 38607, 92731, 3709, 12.2, 5618, 13.6, 3032.1, 491001933, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (144, N'VS1600 x 328', 328.4, 418.4, 1600, 12.5, 500, 22.4, 1791549, 22394, 65.4, 25225, 46692, 1868, 10.6, 2861, 12.7, 477.4, 290362539, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (145, N'VS1600 x 348', 348.4, 443.8, 1600, 12.5, 500, 25, 1938424, 24230, 66.1, 27195, 52109, 2084, 10.8, 3186, 12.9, 623.4, 322998047, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (146, N'VS1600 x 398', 398.1, 507.1, 1600, 12.5, 500, 31.5, 2315887, 28949, 67.6, 32086, 65650, 2626, 11.4, 3998, 13.2, 1144, 403625291, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (147, N'VS1600 x 444', 444, 565.6, 1600, 12.5, 500, 37.5, 2658693, 33234, 68.6, 36564, 78150, 3126, 11.8, 4747, 13.4, 1859.5, 476837158, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (148, N'VS1600 x 498', 497.6, 633.9, 1600, 12.5, 500, 44.5, 3051871, 38148, 69.4, 41745, 92733, 3709, 12.1, 5622, 13.5, 3038.6, 560788131, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (149, N'VS1700 x 338', 338.3, 430.9, 1700, 12.5, 500, 22.4, 2055170, 24178, 69.1, 27349, 46694, 1868, 10.4, 2865, 12.6, 483.9, 328339872, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (150, N'VS1700 x 358', 358.2, 456.3, 1700, 12.5, 500, 25, 2221576, 26136, 69.8, 29445, 52110, 2084, 10.7, 3189, 12.8, 629.9, 365315755, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (151, N'VS1700 x 408', 407.9, 519.6, 1700, 12.5, 500, 31.5, 2649532, 31171, 71.4, 34653, 65652, 2626, 11.2, 4001, 13.1, 1150.5, 456732322, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (152, N'VS1700 x 454', 453.8, 578.1, 1700, 12.5, 500, 37.5, 3038582, 35748, 72.5, 39424, 78151, 3126, 11.6, 4751, 13.3, 1866, 539825439, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (153, N'VS1700 x 507', 507.4, 646.4, 1700, 12.5, 500, 44.5, 3485268, 41003, 73.4, 44945, 92735, 3709, 12, 5625, 13.5, 3045.2, 635209745, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (154, N'VS1800 x 348', 348.1, 443.4, 1800, 12.5, 500, 22.4, 2340384, 26004, 72.7, 29534, 46695, 1868, 10.3, 2869, 12.5, 490.4, 368650539, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (155, N'VS1800 x 368', 368, 468.8, 1800, 12.5, 500, 25, 2527539, 28084, 73.4, 31758, 52112, 2084, 10.5, 3193, 12.7, 636.4, 410237630, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (156, N'VS1800 x 418', 417.7, 532.1, 1800, 12.5, 500, 31.5, 3009158, 33435, 75.2, 37283, 65653, 2626, 11.1, 4005, 13, 1157, 513120604, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (157, N'VS1800 x 464', 463.6, 590.6, 1800, 12.5, 500, 37.5, 3447378, 38304, 76.4, 42346, 78153, 3126, 11.5, 4755, 13.2, 1872.6, 606719971, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (158, N'VS1800 x 517', 517.2, 658.9, 1800, 12.5, 500, 44.5, 3950984, 43900, 77.4, 48208, 92736, 3709, 11.9, 5629, 13.4, 3051.7, 714266777, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (159, N'VS1800 x 465', 465.4, 592.9, 1800, 16, 500, 31.5, 3162016, 35134, 73, 39923, 65684, 2627, 10.5, 4049, 12.7, 1283.3, 513120604, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (160, N'VS1800 x 511', 511, 651, 1800, 16, 500, 37.5, 3597089, 39968, 74.3, 44949, 78184, 3127, 11, 4798, 12.9, 1998.5, 606719971, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (161, N'VS1800 x 564', 564.3, 718.8, 1800, 16, 500, 44.5, 4097080, 45523, 75.5, 50770, 92767, 3711, 11.4, 5672, 13.2, 3177.1, 714266777, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (162, N'VS1900 x 429', 428.6, 546, 1900, 16, 500, 25, 3041613, 32017, 74.6, 37128, 52146, 2086, 9.8, 3243, 12.2, 776.8, 457763672, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (163, N'VS1900 x 478', 478, 608.9, 1900, 16, 500, 31.5, 3576198, 37644, 76.6, 42927, 65688, 2628, 10.4, 4055, 12.6, 1297, 572790135, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (164, N'VS1900 x 524', 523.6, 667, 1900, 16, 500, 37.5, 4062991, 42768, 78.1, 48244, 78187, 3127, 10.8, 4804, 12.9, 2012.1, 677520752, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (165, N'VS1900 x 577', 576.8, 734.8, 1900, 16, 500, 44.5, 4622882, 48662, 79.3, 54404, 92770, 3711, 11.2, 5678, 13.1, 3190.7, 797959225, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (166, N'VS2000 x 461', 460.8, 587, 2000, 16, 550, 25, 3670473, 36705, 79.1, 42366, 69389, 2523, 10.9, 3906, 13.5, 842.6, 676006755, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (167, N'VS2000 x 515', 515.3, 656.4, 2000, 16, 550, 31.5, 4326007, 43260, 81.2, 49112, 87413, 3179, 11.5, 4888, 13.9, 1414.8, 846171159, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (168, N'VS2000 x 566', 565.6, 720.5, 2000, 16, 550, 37.5, 4923357, 49234, 82.7, 55299, 104050, 3784, 12, 5795, 14.2, 2201.5, 1001215179, 100, 1, 0)
INSERT [dbo].[VS] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (169, N'VS2000 x 624', 624.3, 795.3, 2000, 16, 550, 44.5, 5610913, 56109, 84, 62469, 123460, 4489, 12.5, 6853, 14.5, 3498.1, 1179648116, 100, 1, 0)
SET IDENTITY_INSERT [dbo].[VS] OFF
SET IDENTITY_INSERT [dbo].[VSM] ON 

INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (1, N'VSM-200 x 18', 18.1, 23.1, 200, 4.75, 100, 100, 6.3, 8, 1573, 148, 168, 8.25, 179, 119, 24, 2.27, 77, 2.58, 3, 10923, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (2, N'VSM-200 x 19', 19.2, 24.5, 200, 4.75, 100, 100, 6.3, 9.5, 1669, 150, 188, 8.25, 192, 132, 26, 2.32, 80, 2.57, 4, 11649, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (3, N'VSM-200 x 22', 21.5, 27.4, 200, 4.75, 100, 100, 6.3, 12.5, 1823, 153, 226, 8.16, 218, 157, 31, 2.39, 86, 2.55, 8, 12681, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (4, N'VSM-200 x 23', 23, 29.3, 200, 4.75, 130, 130, 6.3, 9.5, 2091, 186, 239, 8.45, 238, 289, 44, 3.14, 107, 3.42, 5, 25592, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (5, N'VSM-200 x 26', 25.9, 33, 200, 4.75, 130, 130, 6.3, 12.5, 2285, 188, 290, 8.32, 272, 344, 53, 3.23, 118, 3.39, 10, 27860, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (6, N'VSM-250 x 20', 20, 25.5, 250, 4.75, 100, 100, 6.3, 8, 2611, 197, 222, 10.12, 240, 119, 24, 2.16, 102, 2.52, 3, 17322, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (7, N'VSM-250 x 21', 21.1, 26.9, 250, 4.75, 100, 100, 6.3, 9.5, 2771, 200, 248, 10.15, 256, 132, 26, 2.22, 105, 2.5, 5, 18502, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (8, N'VSM-250 x 23', 23.4, 29.8, 250, 4.75, 100, 100, 6.3, 12.5, 3034, 205, 297, 10.09, 290, 157, 31, 2.3, 110, 2.48, 8, 20207, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (9, N'VSM-250 x 25', 24.9, 31.7, 250, 4.75, 130, 130, 6.3, 9.5, 3442, 246, 312, 10.42, 314, 289, 44, 3.02, 132, 3.35, 6, 40649, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (10, N'VSM-250 x 28', 27.8, 35.4, 250, 4.75, 130, 130, 6.3, 12.5, 3773, 251, 378, 10.32, 357, 344, 53, 3.12, 143, 3.32, 10, 44395, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (11, N'VSM-300 x 25', 25.3, 32.2, 300, 4.75, 130, 130, 6.3, 8, 4878, 306, 347, 12.31, 369, 262, 40, 2.85, 157, 3.3, 4, 55339, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (12, N'VSM-300 x 27', 26.7, 34, 300, 4.75, 130, 130, 6.3, 9.5, 5187, 311, 389, 12.35, 396, 290, 45, 2.92, 163, 3.28, 6, 59172, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (13, N'VSM-300 x 30', 29.7, 37.8, 300, 4.75, 130, 130, 6.3, 12.5, 5693, 318, 470, 12.27, 449, 344, 53, 3.02, 173, 3.25, 11, 64764, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (14, N'VSM-300 x 29', 29.2, 37.2, 300, 4.75, 150, 150, 6.3, 9.5, 5837, 348, 442, 12.53, 442, 445, 59, 3.46, 185, 3.84, 7, 90900, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (15, N'VSM-300 x 33', 32.7, 41.6, 300, 4.75, 150, 150, 6.3, 12.5, 6411, 355, 536, 12.41, 504, 529, 71, 3.57, 200, 3.81, 12, 99489, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (16, N'VSM-350 x 29', 29.4, 37.4, 350, 4.75, 150, 150, 6.3, 8, 7752, 417, 473, 14.4, 502, 402, 54, 3.28, 214, 3.8, 5, 116519, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (17, N'VSM-350 x 31', 31.1, 39.6, 350, 4.75, 150, 150, 6.3, 9.5, 8248, 424, 531, 14.43, 538, 445, 59, 3.35, 222, 3.78, 7, 124683, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (18, N'VSM-350 x 36', 36, 45.8, 350, 4.75, 160, 160, 6.3, 12.5, 9560, 456, 682, 14.45, 643, 642, 80, 3.74, 251, 4.02, 13, 165867, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (19, N'VSM-350 x 34', 33.5, 42.7, 350, 4.75, 170, 170, 6.3, 9.5, 9141, 467, 592, 14.63, 592, 647, 76, 3.89, 247, 4.34, 7, 181501, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (20, N'VSM-350 x 37', 37.4, 47.7, 350, 4.75, 170, 170, 6.3, 12.5, 10053, 477, 721, 14.52, 675, 770, 91, 4.02, 266, 4.3, 14, 198952, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (21, N'VSM-400 x 33', 33.4, 42.6, 400, 4.75, 170, 170, 6.3, 8, 11578, 544, 618, 16.49, 654, 586, 69, 3.71, 280, 4.3, 6, 222697, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (22, N'VSM-400 x 38', 37.6, 47.9, 400, 4.75, 170, 170, 8, 9.5, 13552, 646, 713, 16.82, 756, 717, 84, 3.87, 300, 4.42, 9, 272176, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (23, N'VSM-400 x 42', 41.5, 52.9, 400, 4.75, 170, 170, 8, 12.5, 14993, 661, 865, 16.84, 850, 840, 99, 3.98, 319, 4.38, 15, 303378, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (24, N'VSM-400 x 40', 40.3, 51.4, 400, 4.75, 190, 190, 8, 9.5, 14883, 708, 785, 17.02, 824, 1001, 105, 4.41, 332, 4.99, 10, 379983, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (25, N'VSM-400 x 46', 46.3, 59, 400, 4.75, 200, 200, 8, 12.5, 17229, 755, 1003, 17.09, 970, 1367, 137, 4.81, 376, 5.23, 18, 494000, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (26, N'VSM-450 x 49', 48.8, 62.2, 450, 6.3, 200, 200, 8, 9.5, 21218, 903, 987, 18.47, 1067, 1168, 117, 4.33, 470, 5.07, 13, 563707, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (27, N'VSM-450 x 53', 53.5, 68.1, 450, 6.3, 200, 200, 8, 12.5, 23428, 928, 1186, 18.55, 1192, 1368, 137, 4.48, 496, 5.02, 20, 628878, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (28, N'VSM-450 x 59', 58.7, 74.8, 450, 6.3, 200, 200, 8, 16, 25498, 948, 1410, 18.46, 1337, 1601, 160, 4.63, 526, 4.98, 34, 682112, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (29, N'VSM-450 x 61', 61.5, 78.3, 450, 6.3, 250, 250, 8, 12.5, 28180, 1105, 1446, 18.97, 1417, 2670, 214, 5.84, 611, 6.43, 24, 1228278, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (30, N'VSM-450 x 68', 68.1, 86.8, 450, 6.3, 250, 250, 8, 16, 30691, 1125, 1732, 18.8, 1600, 3126, 250, 6, 661, 6.38, 42, 1332250, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (31, N'VSM-500 x 58', 58.2, 74.1, 500, 6.3, 250, 250, 8, 9.5, 32184, 1229, 1352, 20.84, 1441, 2280, 182, 5.55, 640, 6.41, 15, 1364644, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (32, N'VSM-500 x 64', 64, 81.5, 500, 6.3, 250, 250, 8, 12.5, 35616, 1262, 1636, 20.9, 1617, 2670, 214, 5.72, 682, 6.36, 25, 1523470, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (33, N'VSM-500 x 71', 70.7, 90, 500, 6.3, 250, 250, 8, 16, 38813, 1287, 1956, 20.77, 1821, 3126, 250, 5.89, 732, 6.31, 42, 1653778, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (34, N'VSM-500 x 67', 66.8, 85.1, 500, 6.3, 250, 250, 9.5, 12.5, 38234, 1413, 1666, 21.2, 1705, 2866, 229, 5.8, 704, 6.51, 27, 1680612, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (35, N'VSM-500 x 79', 79.3, 101, 500, 6.3, 250, 250, 12.5, 16, 47109, 1745, 2047, 21.6, 2081, 3712, 297, 6.06, 795, 6.66, 54, 2156004, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (36, N'VSM-550 x 69', 69.3, 88.3, 550, 6.3, 250, 250, 9.5, 12.5, 47229, 1591, 1866, 23.13, 1921, 2866, 229, 5.7, 783, 6.44, 28, 2041866, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (37, N'VSM-550 x 76', 76, 96.8, 550, 6.3, 250, 250, 9.5, 16, 51668, 1625, 2226, 23.1, 2146, 3321, 266, 5.86, 832, 6.4, 46, 2240243, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (38, N'VSM-550 x 82', 81.7, 104.1, 550, 6.3, 250, 250, 9.5, 19, 54798, 1646, 2525, 22.94, 2337, 3712, 297, 5.97, 874, 6.36, 69, 2366985, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (39, N'VSM-550 x 84', 84, 107, 550, 6.3, 260, 260, 12.5, 16, 60089, 2026, 2371, 23.7, 2413, 4175, 321, 6.25, 910, 6.9, 57, 2950178, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (40, N'VSM-550 x 90', 90, 114.6, 550, 6.3, 260, 260, 12.5, 19, 64041, 2051, 2694, 23.64, 2611, 4615, 355, 6.35, 956, 6.87, 81, 3151962, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (41, N'VSM-600 x 85', 84.6, 107.8, 600, 8, 280, 280, 9.5, 12.5, 65754, 2043, 2364, 24.7, 2482, 4027, 288, 6.11, 1099, 7.05, 36, 3425582, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (42, N'VSM-600 x 92', 92.2, 117.4, 600, 8, 280, 280, 9.5, 16, 71846, 2093, 2799, 24.74, 2757, 4667, 333, 6.3, 1160, 7, 56, 3760472, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (43, N'VSM-600 x 99', 98.5, 125.5, 600, 8, 280, 280, 9.5, 19, 76212, 2124, 3160, 24.64, 2990, 5216, 373, 6.45, 1212, 6.96, 82, 3975116, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (44, N'VSM-600 x 103', 103, 131.2, 600, 8, 300, 300, 12.5, 16, 85096, 2640, 3064, 25.47, 3157, 6415, 428, 6.99, 1294, 7.84, 70, 5417417, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (45, N'VSM-600 x 110', 109.9, 140, 600, 8, 300, 300, 12.5, 19, 90657, 2678, 3467, 25.45, 3407, 7090, 473, 7.12, 1355, 7.8, 98, 5790726, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (46, N'VSM-650 x 88', 87.8, 111.8, 650, 8, 280, 280, 9.5, 12.5, 78774, 2264, 2608, 26.54, 2757, 4027, 288, 6, 1220, 6.99, 37, 4031861, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (47, N'VSM-650 x 95', 95.3, 121.4, 650, 8, 280, 280, 9.5, 16, 86043, 2322, 3078, 26.62, 3055, 4667, 333, 6.2, 1280, 6.93, 57, 4428085, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (48, N'VSM-650 x 102', 101.7, 129.5, 650, 8, 280, 280, 9.5, 19, 91292, 2359, 3471, 26.55, 3309, 5216, 373, 6.35, 1331, 6.89, 83, 4682717, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (49, N'VSM-650 x 106', 106.1, 135.2, 650, 8, 300, 300, 12.5, 16, 101610, 2916, 3370, 27.41, 3490, 6415, 428, 6.89, 1414, 7.78, 71, 6381759, 102, 1, 0)
INSERT [dbo].[VSM] ([ID], [nome], [peso], [A], [d], [tw], [bfs], [bfi], [tfs], [tfi], [Ix], [Wxs], [Wxi], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (50, N'VSM-650 x 113', 113, 144, 650, 8, 300, 300, 12.5, 19, 108246, 2959, 3809, 27.42, 3762, 7090, 473, 7.02, 1474, 7.74, 99, 6824275, 102, 1, 0)
SET IDENTITY_INSERT [dbo].[VSM] OFF
SET IDENTITY_INSERT [dbo].[W] ON 

INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (1, N'﻿W 150 x 13,0', 13, 16.6, 148, 4.3, 100, 4.9, 635, 85.8, 6.18, 96.4, 82, 16.4, 2.22, 25.5, 2.6, 1.72, 4181, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (2, N'W 150 x 18,0', 18, 23.4, 153, 5.8, 102, 7.1, 939, 122.8, 6.34, 139.4, 126, 24.7, 2.32, 38.5, 2.69, 4.34, 6683, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (3, N'W 150 x 22,5 (H)', 22.5, 29, 152, 5.8, 152, 6.6, 1229, 161.7, 6.51, 179.6, 387, 50.9, 3.65, 77.9, 4.1, 4.75, 20417, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (4, N'W 150 x 24,0', 24, 31.5, 160, 6.6, 102, 10.3, 1384, 173, 6.63, 197.6, 183, 35.9, 2.41, 55.8, 2.73, 11.08, 10206, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (5, N'W 150 x 29,8 (H)', 29.8, 38.5, 157, 6.6, 153, 9.3, 1739, 221.5, 6.72, 247.5, 556, 72.6, 3.8, 110.8, 4.18, 10.95, 30277, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (6, N'W 150 x 37,1 (H)', 37.1, 47.8, 162, 8.1, 154, 11.6, 2244, 277, 6.85, 313.5, 707, 91.8, 3.84, 140.4, 4.22, 20.58, 39930, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (7, N'W 200 x 15,0', 15, 19.4, 200, 4.3, 100, 5.2, 1305, 130.5, 8.2, 147.9, 87, 17.4, 2.12, 27.3, 2.55, 2.05, 8222, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (8, N'W 200 x 19,3', 19.3, 25.1, 203, 5.8, 102, 6.5, 1686, 166.1, 8.19, 190.6, 116, 22.7, 2.14, 35.9, 2.59, 4.02, 11098, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (9, N'W 200 x 22,5', 22.5, 29, 206, 6.2, 102, 8, 2029, 197, 8.37, 225.5, 142, 27.9, 2.22, 43.9, 2.63, 6.18, 13868, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (10, N'W 200 x 26,6', 26.6, 34.2, 207, 5.8, 133, 8.4, 2611, 252.3, 8.73, 282.3, 330, 49.6, 3.1, 76.3, 3.54, 7.65, 32477, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (11, N'W 200 x 31,3', 31.3, 40.3, 210, 6.4, 134, 10.2, 3168, 301.7, 8.86, 338.6, 410, 61.2, 3.19, 94, 3.6, 12.59, 40822, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (12, N'W 200 x 35,9 (H)', 35.9, 45.7, 201, 6.2, 165, 10.2, 3437, 342, 8.67, 379.2, 764, 92.6, 4.09, 141, 4.5, 14.51, 69502, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (13, N'W 200 x 41,7 (H)', 41.7, 53.5, 205, 7.2, 166, 11.8, 4114, 401.4, 8.77, 448.6, 901, 108.5, 4.1, 165.7, 4.53, 23.19, 83948, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (14, N'W 200 x 46,1 (H)', 46.1, 58.6, 203, 7.2, 203, 11, 4543, 447.6, 8.81, 495.3, 1535, 151.2, 5.12, 229.5, 5.58, 22.01, 141342, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (15, N'W 200 x 52,0 (H)', 52, 66.9, 206, 7.9, 204, 12.6, 5298, 514.4, 8.9, 572.5, 1784, 174.9, 5.16, 265.8, 5.61, 33.34, 166710, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (16, N'HP 200 x 53,0 (H)', 53, 68.1, 204, 11.3, 207, 11.3, 4977, 488, 8.55, 551.3, 1673, 161.7, 4.96, 248.6, 5.57, 31.93, 155075, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (17, N'W 200 x 59,0 (H)', 59, 76, 210, 9.1, 205, 14.2, 6140, 584.8, 8.99, 655.9, 2041, 199.1, 5.18, 303, 5.64, 47.69, 195418, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (18, N'W 200 x 71,0 (H)', 71, 91, 216, 10.2, 206, 17.4, 7660, 709.2, 9.17, 803.2, 2537, 246.3, 5.28, 374.5, 5.7, 81.66, 24976, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (19, N'W 200 x 86,0 (H)', 86, 110.9, 222, 13, 209, 20.6, 9498, 855.7, 9.26, 984.2, 3139, 300.4, 5.32, 458.7, 5.77, 142.19, 317844, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (20, N'W 250 x 17,9', 17.9, 23.1, 251, 4.8, 101, 5.3, 2291, 182.6, 9.96, 211, 91, 18.1, 1.99, 28.8, 2.48, 2.54, 13735, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (21, N'W 250 x 22,3', 22.3, 28.9, 254, 5.8, 102, 6.9, 2939, 231.4, 10.09, 267.7, 123, 24.1, 2.06, 38.4, 2.54, 4.77, 18629, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (22, N'W 250 x 25,3', 25.3, 32.6, 257, 6.1, 102, 8.4, 3473, 270.2, 10.31, 311.1, 149, 29.3, 2.14, 46.4, 2.58, 7.06, 22955, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (23, N'W 250 x 28,4', 28.4, 36.6, 260, 6.4, 102, 10, 4046, 311.2, 10.51, 357.3, 178, 34.8, 2.2, 54.9, 2.62, 10.34, 27636, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (24, N'W 250 x 32,7', 32.7, 42.1, 258, 6.1, 146, 9.1, 4937, 382.7, 10.83, 428.5, 473, 64.8, 3.35, 99.7, 3.86, 10.44, 73104, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (25, N'W 250 x 38,5', 38.5, 49.6, 262, 6.6, 147, 11.2, 6057, 462.4, 11.05, 517.8, 594, 80.8, 3.46, 124.1, 3.93, 17.63, 93242, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (26, N'W 250 x 44,8', 44.8, 57.6, 266, 7.6, 148, 13, 7158, 538.2, 11.15, 606.3, 704, 95.1, 3.5, 146.4, 3.96, 27.14, 112398, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (27, N'HP 250 x 62,0 (H)', 62, 79.6, 246, 10.5, 256, 10.7, 8728, 709.6, 10.47, 790.5, 2995, 234, 6.13, 357.8, 6.89, 33.46, 417130, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (28, N'W 250 x 73,0 (H)', 73, 92.7, 253, 8.6, 254, 14.2, 11257, 889.9, 11.02, 983.3, 3880, 305.5, 6.47, 463.1, 7.01, 56.94, 552900, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (29, N'W 250 x 80,0 (H)', 80, 101.9, 256, 9.4, 255, 15.6, 12550, 980.5, 11.1, 1088.7, 4313, 338.3, 6.51, 513.1, 7.04, 75.02, 622878, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (30, N'HP 250 x 85,0 (H)', 85, 108.5, 254, 14.4, 260, 14.4, 1228, 966.9, 10.64, 1093.2, 4225, 325, 6.24, 499.6, 7, 82.07, 605403, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (31, N'W 250 x 89,0 (H)', 89, 113.9, 260, 10.7, 256, 17.3, 14237, 1095.1, 11.18, 1224.4, 4841, 378.2, 6.52, 574.3, 7.06, 102.81, 712351, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (32, N'W 250 x 101,0 (H)', 101, 128.7, 264, 11.9, 257, 19.6, 16352, 1238.8, 11.27, 1395, 5549, 431.8, 6.57, 656.3, 7.1, 147.7, 828031, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (33, N'W 250 x 115,0 (H)', 115, 146.1, 269, 13.5, 259, 22.1, 18920, 1406.7, 11.38, 1597.4, 6405, 494.6, 6.62, 752.7, 7.16, 212, 975265, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (34, N'W 310 x 21,0', 21, 27.2, 303, 5.1, 101, 5.7, 3776, 249.2, 11.77, 291.9, 98, 19.5, 1.9, 31.4, 2.42, 3.27, 21628, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (35, N'W 310 x 23,8', 23.8, 30.7, 305, 5.6, 101, 6.7, 4346, 285, 11.89, 333.2, 116, 22.9, 1.94, 36.9, 2.45, 4.65, 25594, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (36, N'W 310 x 28,3', 28.3, 36.5, 309, 6, 102, 8.9, 5500, 356, 12.28, 412, 158, 31, 2.08, 49.4, 2.55, 8.14, 35441, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (37, N'W 310 x 32,7', 32.7, 42.1, 313, 6.6, 102, 10.8, 6570, 419.8, 12.49, 485.3, 192, 37.6, 2.13, 59.8, 2.58, 12.91, 43612, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (38, N'W 310 x 38,7', 38.7, 49.7, 310, 5.8, 165, 9.7, 8581, 553.6, 13.14, 615.4, 727, 88.1, 3.82, 134.9, 4.38, 13.2, 163728, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (39, N'W 310 x 44,5', 44.5, 57.2, 313, 6.6, 166, 11.2, 9997, 638.8, 13.22, 712.8, 855, 103, 3.87, 158, 4.41, 19.9, 194433, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (40, N'W 310 x 52,0', 52, 67, 317, 7.6, 167, 13.2, 11909, 751.4, 13.33, 842.5, 1026, 122.9, 3.91, 188.8, 4.45, 31.81, 236422, 101, 2, 10)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (41, N'HP 310 x 79,0 (H)', 79, 100, 299, 11, 306, 11, 16316, 1091.3, 12.77, 1210.1, 5258, 343.7, 7.25, 525.4, 8.2, 46.72, 1089258, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (42, N'HP 310 x 93,0 (H)', 93, 119.2, 303, 13.1, 308, 13.1, 19682, 1299.1, 12.85, 1450.3, 6387, 414.7, 7.32, 635.5, 8.26, 77.33, 1340320, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (43, N'W 310 x 97,0 (H)', 97, 123.6, 308, 9.9, 305, 15.4, 22284, 1447, 13.43, 1594.2, 7286, 477.8, 7.68, 725, 8.38, 92.12, 1558682, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (44, N'W 310 x 107,0 (H)', 107, 136.4, 311, 10.9, 306, 17, 24839, 1597.3, 13.49, 1768.2, 8123, 530.9, 7.72, 806.1, 8.41, 122.86, 1754271, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (45, N'HP 310 x 110,0 (H)', 110, 141, 308, 15.4, 310, 15.5, 23703, 1539.1, 12.97, 1730.6, 7707, 497.3, 7.39, 763.7, 8.33, 125.66, 1646104, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (46, N'W 310 x 117,0 (H)', 117, 149.9, 314, 11.9, 307, 18.7, 27563, 1755.6, 13.56, 1952.6, 9024, 587.9, 7.76, 893.1, 8.44, 161.61, 1965950, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (47, N'HP 310 x 125,0 (H)', 125, 159, 312, 17.4, 312, 17.4, 27076, 1735.6, 13.05, 1963.3, 8823, 565.6, 7.45, 870.6, 8.38, 177.98, 1911029, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (48, N'W 360 x 32,9', 32.9, 42.1, 349, 5.8, 127, 8.5, 8358, 479, 14.09, 547.6, 291, 45.9, 2.63, 72, 3.2, 9.15, 84111, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (49, N'W 360 x 39,0', 39, 50.2, 353, 6.5, 128, 10.7, 10331, 585.3, 14.35, 667.7, 375, 58.6, 2.73, 91.9, 3.27, 15.83, 109551, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (50, N'W 360 x 44,0', 44, 57.7, 352, 6.9, 171, 9.8, 12258, 696.5, 14.58, 784.3, 818, 95.7, 3.77, 148, 4.43, 16.7, 239091, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (51, N'W 360 x 51,0', 51, 64.8, 355, 7.2, 171, 11.6, 14222, 801.2, 14.81, 899.5, 968, 113.3, 3.87, 174.7, 4.49, 24.65, 284994, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (52, N'W 360 x 57,8', 57.8, 72.5, 358, 7.9, 172, 13.1, 16143, 901.8, 14.92, 1014.8, 1113, 129.4, 3.92, 199.8, 4.53, 34.45, 330394, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (53, N'W 360 x 64,0', 64, 81.7, 347, 7.7, 203, 13.5, 17890, 1031.1, 14.8, 1145.5, 1885, 185.7, 4.8, 284.5, 5.44, 44.57, 523362, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (54, N'W 360 x 72,0', 72, 91.3, 350, 8.6, 204, 15.1, 20169, 1152.5, 14.86, 1285.9, 2140, 209.8, 4.84, 321.8, 5.47, 61.18, 599082, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (55, N'W 360 x 79,0', 79, 101.2, 354, 9.4, 205, 16.8, 22713, 1283.2, 14.98, 1437, 2416, 235.7, 4.89, 361.9, 5.51, 82.41, 685701, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (56, N'W 360 x 91,0 (H)', 91, 115.9, 353, 9.5, 254, 16.4, 26755, 1515.9, 15.19, 1680.1, 4483, 353, 6.22, 538.1, 6.9, 92.61, 1268709, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (57, N'W 360 x 101,0 (H)', 101, 129.5, 357, 10.5, 255, 18.3, 30279, 1696.3, 15.29, 1888.9, 5063, 397.1, 6.25, 606.1, 6.93, 128.47, 1450410, 101, 2, 17)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (58, N'W 360 x 110,0 (H)', 110, 140.6, 360, 11.4, 256, 19.9, 33155, 1841.9, 15.36, 2059.3, 5570, 435.2, 6.29, 664.5, 6.96, 161.93, 1609070, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (59, N'W 360 x 122,0 (H)', 122, 155.3, 363, 13, 257, 21.7, 36599, 2016.5, 15.35, 2269.8, 6147, 478.4, 6.29, 732.4, 6.98, 212.7, 1787806, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (60, N'W 410 x 38,8', 38.8, 50.3, 399, 6.4, 140, 8.8, 12777, 640.5, 15.94, 736.8, 404, 57.7, 2.83, 90.9, 3.49, 11.69, 153190, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (61, N'W 410 x 46,1', 46.1, 59.2, 403, 7, 140, 11.2, 15690, 778.7, 16.27, 891.1, 514, 73.4, 2.95, 115.2, 3.55, 20.06, 196571, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (62, N'W 410 x 53,0', 53, 68.4, 403, 7.5, 177, 10.9, 18734, 929.7, 16.55, 1052.2, 1009, 114, 3.84, 176.9, 4.56, 23.38, 387194, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (63, N'W 410 x 60,0', 60, 76.2, 407, 7.7, 178, 12.8, 21707, 1066.7, 16.88, 1201.5, 1205, 135.4, 3.98, 209.2, 4.65, 33.78, 467404, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (64, N'W 410 x 67,0', 67, 86.3, 410, 8.8, 179, 14.4, 24678, 1203.8, 16.91, 1362.7, 1379, 154.1, 4, 239, 4.67, 48.11, 538546, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (65, N'W 410 x 75,0', 75, 95.8, 413, 9.7, 180, 16, 27616, 1337.3, 16.98, 1518.6, 1559, 173.2, 4.03, 269.1, 4.7, 65.21, 612784, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (66, N'W 410 x 85,0', 85, 108.6, 417, 10.9, 181, 18.2, 31658, 1518.4, 17.07, 1731.7, 1804, 199.3, 4.08, 310.4, 4.74, 94.48, 715165, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (67, N'W 460 x 52,0', 52, 66.6, 450, 7.6, 152, 10.8, 21370, 949.8, 17.91, 1095.9, 634, 83.5, 3.09, 131.7, 3.79, 21.79, 304837, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (68, N'W 460 x 60,0', 60, 76.2, 455, 8, 153, 13.3, 25652, 1127.6, 18.35, 1292.1, 796, 104.1, 3.23, 163.4, 3.89, 34.6, 387230, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (69, N'W 460 x 68,0', 68, 87.6, 459, 9.1, 154, 15.4, 29851, 1300.7, 18.46, 1495.4, 941, 122.2, 3.28, 192.4, 3.93, 52.29, 461163, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (70, N'W 460 x 74,0', 74, 94.9, 457, 9, 190, 14.5, 33415, 1462.4, 18.77, 1657.4, 1661, 174.8, 4.18, 271.3, 4.93, 52.97, 811417, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (71, N'W 460 x 82,0', 82, 104.7, 460, 9.9, 191, 16, 37157, 1615.5, 18.84, 1836.4, 1862, 195, 4.22, 303.3, 4.96, 70.62, 915745, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (72, N'W 460 x 89,0', 89, 114.1, 463, 10.5, 192, 17.7, 41105, 1775.6, 18.98, 2019.4, 2093, 218, 4.28, 339, 5.01, 92.49, 1035073, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (73, N'W 460 x 97,0', 97, 123.4, 466, 11.4, 193, 19, 44658, 1916.7, 19.03, 2187.4, 2283, 236.6, 4.3, 368.8, 5.03, 115.05, 1137180, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (74, N'W 460 x 106,0', 106, 135.1, 469, 12.6, 194, 20.6, 48978, 2088.6, 19.04, 2394.6, 2515, 259.3, 4.32, 405.7, 5.05, 148.19, 1260063, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (75, N'W 530 x 66,0', 66, 83.6, 525, 8.9, 165, 11.4, 34971, 1332.2, 20.46, 1558, 857, 103.9, 3.2, 166, 4.02, 31.52, 562854, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (76, N'W 530 x 72,0', 72, 91.6, 524, 9, 207, 10.9, 39969, 1525.5, 20.89, 1755.9, 1615, 156, 4.2, 244.6, 5.16, 33.41, 1060548, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (77, N'W 530 x 74,0', 74, 95.1, 529, 9.7, 166, 13.6, 40969, 1548.9, 20.76, 1804.9, 1041, 125.5, 3.31, 200.1, 4.1, 47.39, 688558, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (78, N'W 530 x 82,0', 82, 104.5, 528, 9.5, 209, 13.3, 47569, 1801.8, 21.34, 2058.5, 2028, 194.1, 4.41, 302.7, 5.31, 51.23, 1340255, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (79, N'W 530 x 85,0', 85, 107.7, 535, 10.3, 166, 16.5, 48453, 1811.3, 21.21, 2099.8, 1263, 152.2, 3.42, 241.6, 4.17, 72.93, 845463, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (80, N'W 530 x 92,0', 92, 117.6, 533, 10.2, 209, 15.6, 55157, 2069.7, 21.65, 2359.8, 2379, 227.6, 4.5, 354.7, 5.36, 75.5, 1588565, 101, 2, 12)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (81, N'W 530 x 101,0', 101, 130, 537, 10.9, 210, 17.4, 62198, 2316.5, 21.87, 2640.4, 2693, 256.5, 4.55, 400.6, 5.4, 106.04, 1812734, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (82, N'W 530 x 109,0', 109, 139.7, 539, 11.6, 211, 18.8, 67226, 2494.5, 21.94, 2847, 2952, 279.8, 4.6, 437.4, 5.44, 131.38, 1991291, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (83, N'W 610 x 101,0', 101, 130.3, 603, 10.5, 228, 14.9, 77003, 2554, 24.31, 2922.7, 2951, 258.8, 4.76, 405, 5.76, 81.68, 2544966, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (84, N'W 610 x 113,0', 113, 145.3, 608, 11.2, 228, 17.3, 88196, 2901.2, 24.64, 3312.9, 3426, 300.5, 4.86, 469.7, 5.82, 116.5, 2981078, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (85, N'W 610 x 125,0', 125, 160.1, 612, 11.9, 229, 19.6, 99184, 3241.3, 24.89, 3697.3, 3933, 343.5, 4.96, 536.3, 5.89, 159.5, 3441766, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (86, N'W 610 x 140,0', 140, 179.3, 617, 13.1, 230, 22.2, 112619, 3650.5, 25.06, 4173.1, 4515, 392.6, 5.02, 614, 5.94, 225.01, 3981687, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (87, N'W 610 x 155,0', 155, 198.1, 611, 12.7, 324, 19, 129583, 4241.7, 25.58, 4749.1, 10783, 665.6, 7.38, 1022.6, 8.53, 200.77, 9436714, 101, 2, 16)
INSERT [dbo].[W] ([ID], [nome], [peso], [A], [d], [tw], [bf], [tf], [Ix], [Wx], [rx], [Zx], [Iy], [Wy], [ry], [Zy], [rT], [IT], [Cw], [ProfCode], [Fabrication], [R]) VALUES (88, N'W 610 x 174,0', 174, 222.8, 616, 14, 325, 21.6, 147754, 4797.2, 25.75, 5383.3, 12374, 761.5, 7.45, 1171.1, 8.58, 286.88, 10915665, 101, 2, 16)
SET IDENTITY_INSERT [dbo].[W] OFF
