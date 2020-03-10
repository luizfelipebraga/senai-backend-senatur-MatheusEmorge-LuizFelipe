use Senatur_Tarde
CREATE TABLE Pacotes (
IdPacote INT PRIMARY KEY IDENTITY,
NomePacote VARCHAR (250) not null,
Descricao VARCHAR (1000),
DataIda DATE not null,
DataVolta DATE not null,
Valor Decimal(18,2),
Ativo BIT,
NomeCidade VARCHAR (250) not null
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