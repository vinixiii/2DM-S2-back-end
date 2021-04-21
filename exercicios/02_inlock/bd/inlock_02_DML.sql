USE InLock_Games_Manha;
GO

INSERT INTO TiposDeUsuarios (Titulo)
VALUES ('ADMINISTRADOR'),
       ('CLIENTE');
GO

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES ('admin@admin.com', 'admin', 1)
	  ,('cliente@cliente.com', 'cliente', 2);
GO

INSERT INTO Estudios (NomeEstudio)
VALUES ('Blizzard'),
       ('Rockstar Studios'),
	   ('Square Enix');
GO

INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES ('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '15/05/2012', 99, 1),
	   ('Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western', '26/10/2018', 120, 2);
GO