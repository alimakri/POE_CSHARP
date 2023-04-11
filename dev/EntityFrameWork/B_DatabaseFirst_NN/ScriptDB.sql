USE [master]
GO
CREATE DATABASE [HabitantDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HabitantDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HabitantDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HabitantDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HabitantDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
USE [HabitantDB]
GO
CREATE TABLE [dbo].[Personne](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Ville](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ville] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[PersonneVille](
	[Personne] [bigint] NOT NULL,
	[Ville] [bigint] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PersonneVille]  WITH CHECK ADD  CONSTRAINT [FK_PersonneVille_Personne] FOREIGN KEY([Personne]) REFERENCES [dbo].[Personne] ([Id])
ALTER TABLE [dbo].[PersonneVille] CHECK CONSTRAINT [FK_PersonneVille_Personne]
GO

ALTER TABLE [dbo].[PersonneVille]  WITH CHECK ADD  CONSTRAINT [FK_PersonneVille_Ville] FOREIGN KEY([Ville]) REFERENCES [dbo].[Ville] ([Id])
ALTER TABLE [dbo].[PersonneVille] CHECK CONSTRAINT [FK_PersonneVille_Ville]
GO

insert Personne (Nom) values('Albert')
insert Personne (Nom) values('Béatrice')
insert Ville (Nom) values('Bordeaux')
insert Ville (Nom) values('Agen')
insert PersonneVille (Personne, Ville) values(1, 1)
insert PersonneVille (Personne, Ville) values(1, 2)
insert PersonneVille (Personne, Ville) values(2, 2)

select * from Personne
select * from PersonneVille


