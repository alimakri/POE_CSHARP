use master;
CREATE DATABASE [JeuBD]  ON  PRIMARY 
( 
	NAME = N'JeuBD', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\JeuBD.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB 
)
LOG ON 
( 
	NAME = N'JeuBD_log', 
	FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\JeuBD_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB 
);
GO
USE [JeuBD];
CREATE TABLE Score
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Joueur] [nvarchar](50) NOT NULL,
	[Score] [tinyint] NOT NULL,
	CONSTRAINT [PK_Score] PRIMARY KEY CLUSTERED ([Id] ASC)
)


