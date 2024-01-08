CREATE DATABASE GameBook
GO

CREATE TABLE Usuario(
	Id							INT IDENTITY NOT NULL,
	Nm_Usuario					VARCHAR(500) NOT NULL,
	Ds_Documento				VARCHAR(14) NOT NULL,
	Ds_Email					VARCHAR(500) NOT NULL,
	Fl_Ativo					BIT NOT NULL,
	Dt_Criacao					DATE NOT NULL,
	Dt_UltimaAlteracao			DATE NULL,
	Ds_Responsavel				VARCHAR(500) NOT NULL

	CONSTRAINT PK_Usuario_Id PRIMARY KEY (Id)
)
GO

CREATE TABLE Categoria_Quadro(
	Id							INT IDENTITY NOT NULL,
	Nm_CategoriaQuadro			VARCHAR(500) NOT NULL,
	Fl_Ativo					BIT NOT NULL,
	Dt_Criacao					DATE NOT NULL,
	Dt_UltimaAlteracao			DATE NULL,
	Ds_Responsavel				VARCHAR(500) NOT NULL

	CONSTRAINT PK_CategoriaQuadro_Id PRIMARY KEY (Id)
)
GO

CREATE TABLE Quadro(
	Id							INT IDENTITY NOT NULL,
	Nm_Quadro					VARCHAR(500) NOT NULL,
	Id_Usuario					INT NOT NULL,
	Id_CategoriaQuadro			INT NOT NULL,
	Fl_Ativo					BIT NOT NULL,
	Dt_Criacao					DATE NOT NULL,
	Dt_UltimaAlteracao			DATE NULL,
	Ds_Responsavel				VARCHAR(500) NOT NULL

	CONSTRAINT PK_Quadro_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Quadro_IdUsuario FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id),
	CONSTRAINT FK_Quadro_IdCategoriaQuadro FOREIGN KEY (Id_CategoriaQuadro) REFERENCES Categoria_Quadro(Id)
)

CREATE TABLE Jogo_Quadro(
	Id							INT IDENTITY NOT NULL,
	Id_Quadro					INT NULL,
	Id_Jogo						INT NULL,
	Fl_Ativo					BIT NOT NULL,
	Dt_Criacao					DATE NOT NULL,
	Dt_UltimaAlteracao			DATE NULL,
	Ds_Responsavel				VARCHAR(500) NOT NULL

	CONSTRAINT PK_JogoQuadro_Id PRIMARY KEY (Id),
	CONSTRAINT FK_JogoQuadro_IdQuadro FOREIGN KEY (Id_Quadro) REFERENCES Quadro(Id),
)