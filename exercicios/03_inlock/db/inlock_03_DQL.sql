-- Fazer as consultadas no seguinte banco de dados:
USE InLock_Games_Manha;
GO

-- Listar todos os usuários
SELECT IdUsuario, Email, Senha, TU.Titulo [Tipo de Usuário] FROM Usuarios U
INNER JOIN TiposDeUsuarios TU
ON U.IdTipoUsuario = TU.IdTipoUsuario;
GO

-- Listar todos os estúdios
SELECT * FROM Estudios;
GO

-- Listar todos os jogos
SELECT * FROM Jogos;

-- Listar todos os jogos e seus respectivos estúdios
SELECT 
	IdJogo,
	NomeJogo Nome,
	Descricao [Descrição],
	DataLancamento [Data de Lançamento],
	FORMAT(Valor, 'c', 'pt-br') AS Valor,
	E.NomeEstudio [Estúdio]
FROM Jogos J
INNER JOIN Estudios E
ON J.IdEstudio = E.IdEstudio;

-- Listar todos os estúdios com seus respectivos jogos, até mesmo os estúdios que não possuem jogos cadastrados
SELECT 
	E.IdEstudio,
	NomeEstudio [Estúdio],
	IdJogo,
	J.NomeJogo [Nome do Jogo],
	Descricao [Descrição],
	DataLancamento [Data de Lançamento],
	FORMAT(Valor, 'c', 'pt-br') AS Valor 
FROM Estudios E
LEFT JOIN Jogos J
ON E.IdEstudio = J.IdEstudio;

-- Buscar por um usuário específico, passando e-mail e senha (login)
SELECT IdUsuario, Email, Senha, TU.Titulo [Tipo de Usuário] FROM Usuarios U
INNER JOIN TiposDeUsuarios TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE U.Email = 'admin@admin.com' AND U.Senha = 'admin';

-- Buscar um jogo pelo seu id
SELECT 
	IdJogo,
	NomeJogo [Nome],
	Descricao [Descrição],
	DataLancamento [Data de Lançamento],
	E.NomeEstudio [Estúdio]
FROM Jogos J
INNER JOIN Estudios E
ON J.IdEstudio = E.IdEstudio
WHERE IdJogo = 2;

-- Buscar um estúdio pelo seu id
SELECT IdEstudio, NomeEstudio [Estúdio] FROM Estudios
WHERE IdEstudio = 1;