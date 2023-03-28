USE [BD3]
GO

/****** Object:  Table [dbo].[Instrument]    Script Date: 27/03/2023 14:18:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Instrument](
	[id] [uniqueidentifier] NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[DateCreation] [datetime] NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Instrument] ADD  CONSTRAINT [DF_Instrument_id]  DEFAULT (newid()) FOR [id]
GO


USE [BD3]
GO

/****** Object:  Table [dbo].[Musicien]    Script Date: 27/03/2023 14:18:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Musicien](
	[id] [uniqueidentifier] NOT NULL,
	[Nom] [nvarchar](max) NULL,
	[age] [tinyint] NULL,
 CONSTRAINT [PK_Musicien] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Musicien] ADD  CONSTRAINT [DF_Musicien_id]  DEFAULT (newid()) FOR [id]
GO


USE [BD3]
GO

/****** Object:  Table [dbo].[Pret]    Script Date: 27/03/2023 14:18:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pret](
	[id] [uniqueidentifier] NOT NULL,
	[Instrument] [uniqueidentifier] NOT NULL,
	[Musicien] [uniqueidentifier] NOT NULL,
	[DatePret] [datetime] NULL,
	[DateRetour] [datetime] NULL,
	[EstRendu] [bit] NULL,
 CONSTRAINT [PK_Pret] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pret] ADD  CONSTRAINT [DF_Pret_id]  DEFAULT (newid()) FOR [id]
GO

ALTER TABLE [dbo].[Pret] ADD  CONSTRAINT [DF_Pret_EstRendu]  DEFAULT ((0)) FOR [EstRendu]
GO

ALTER TABLE [dbo].[Pret]  WITH CHECK ADD  CONSTRAINT [FK_Pret_Instrument1] FOREIGN KEY([Instrument])
REFERENCES [dbo].[Instrument] ([id])
GO

ALTER TABLE [dbo].[Pret] CHECK CONSTRAINT [FK_Pret_Instrument1]
GO

ALTER TABLE [dbo].[Pret]  WITH CHECK ADD  CONSTRAINT [FK_Pret_Musicien1] FOREIGN KEY([Musicien])
REFERENCES [dbo].[Musicien] ([id])
GO

ALTER TABLE [dbo].[Pret] CHECK CONSTRAINT [FK_Pret_Musicien1]
GO

