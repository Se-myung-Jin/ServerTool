CREATE TABLE [dbo].[Users](
	[Id] [bigint] NOT NULL IDENTITY (1, 1),
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Confirmed] [bit] NOT NULL DEFAULT 0,
	[Locked] [bit] NOT NULL DEFAULT 1
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO