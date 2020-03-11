CREATE DATABASE Senatur_Tarde
GO
USE Senatur_Tarde
GO
CREATE TABLE Pacotes (
IdPacote INT PRIMARY KEY IDENTITY,
NomePacote VARCHAR (250),
Descricao VARCHAR (1000),
DataIda DATE,
DataVolta DATE,
Valor Decimal(18,2),
Ativo BIT,
NomeCidade VARCHAR (250)
);

CREATE TABLE TiposUsuario (
IdTipoUsuario INT PRIMARY KEY IDENTITY,
Titulo VARCHAR (250) not null
);

CREATE TABLE Usuarios (
IdUsuario INT PRIMARY KEY IDENTITY,
Email VARCHAR (250) NOT NULL UNIQUE,
Senha VARCHAR (250) not null,
IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario (IdTipoUsuario)

);