--CREATE DATABASE Peoples;
--GO

USE Peoples;
GO

CREATE TABLE Funcionarios
(
	IdFuncionario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200),
	Sobrenome		VARCHAR(255)
);
GO