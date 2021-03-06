USE [bloomberg]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/27/2016 7:55:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 12/27/2016 7:55:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Expenses](
	[id] [uniqueidentifier] NOT NULL,
	[dateExpensed] [date] NOT NULL,
	[dateCreated] [date] NOT NULL,
	[description] [varchar](50) NOT NULL,
	[amount] [float] NOT NULL,
	[categoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Expenses] ADD  CONSTRAINT [DF_Expenses_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Expenses_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Expenses_Categories]
GO
