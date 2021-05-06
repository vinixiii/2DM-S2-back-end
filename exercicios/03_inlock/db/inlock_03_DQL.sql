-- Fazer as consultadas no seguinte banco de dados:
USE InLock_Games_Manha;
GO

-- Listar todos os usu�rios
SELECT IdUsuario, Email, Senha, TU.Titulo [Tipo de Usu�rio] FROM Usuarios U
INNER JOIN TiposDeUsuarios TU
ON U.IdTipoUsuario = TU.IdTipoUsuario;
GO

-- Listar todos os est�dios
SELECT * FROM Estudios;
GO

-- Listar todos os jogos
SELECT * FROM Jogos;

-- Listar todos os jogos e seus respectivos est�dios
SELECT 
	IdJogo,
	NomeJogo Nome,
	Descricao [Descri��o],
	DataLancamento [Data de Lan�amento],
	FORMAT(Valor, 'c', 'pt-br') AS Valor,
	E.NomeEstudio [Est�dio]
FROM Jogos J
INNER JOIN Estudios E
ON J.IdEstudio = E.IdEstudio;

-- Listar todos os est�dios com seus respectivos jogos, at� mesmo os est�dios que n�o possuem jogos cadastrados
SELECT 
	E.IdEstudio,
	NomeEstudio [Est�dio],
	IdJogo,
	J.NomeJogo [Nome do Jogo],
	Descricao [Descri��o],
	DataLancamento [Data de Lan�amento],
	FORMAT(Valor, 'c', 'pt-br') AS Valor 
FROM Estudios E
LEFT JOIN Jogos J
ON E.IdEstudio = J.IdEstudio;

-- Buscar por um usu�rio espec�fico, passando e-mail e senha (login)
SELECT IdUsuario, Email, Senha, TU.Titulo [Tipo de Usu�rio] FROM Usuarios U
INNER JOIN TiposDeUsuarios TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE U.Email = 'admin@admin.com' AND U.Senha = 'admin';

-- Buscar um jogo pelo seu id
SELECT 
	IdJogo,
	NomeJogo [Nome],
	Descricao [Descri��o],
	DataLancamento [Data de Lan�amento],
	E.NomeEstudio [Est�dio]
FROM Jogos J
INNER JOIN Estudios E
ON J.IdEstudio = E.IdEstudio
WHERE IdJogo = 2;

-- Buscar um est�dio pelo seu id
SELECT IdEstudio, NomeEstudio [Est�dio] FROM Estudios
WHERE IdEstudio = 1;