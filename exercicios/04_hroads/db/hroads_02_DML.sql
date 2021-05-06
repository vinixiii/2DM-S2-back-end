USE SENAI_HROADS_MANHA;

INSERT INTO TiposDeHabilidades (Nome)
VALUES ('Ataque'),
	   ('Defesa'),
	   ('Cura'),
	   ('Magia');

INSERT INTO Habilidades (Nome, IdTipo)
VALUES ('Lan�a Mortal', 1),
	   ('Escudo do Supremo', 2),
	   ('Recuperar Vida', 3);

INSERT INTO Classes (Nome)
VALUES ('B�rbaro'),
	   ('Cruzado'),
	   ('Ca�adora de Dem�nios'),
	   ('Monge'),
	   ('Necromante'),
	   ('Feiticeiro'),
	   ('Arcanista');

INSERT INTO ClasseHabilidades (IdClasse, IdHabilidade)
VALUES (1, 1),
	   (1, 2),
	   (2, 2),
	   (3, 1),
	   (4, 3),
	   (4, 2),
	   (5, null),
	   (6, 3),
	   (7, null);

INSERT INTO Personagens (Nome, Vida, Mana, DataDeAtualizacao, DataDeCriacao, IdClasse)
VALUES ('DeuBug', 100, 80, '01/03/2021', '18/01/2019', 1),
	   ('BitBug', 70, 100, '01/03/2021', '17/03/2016', 4),
	   ('Fer8', 75, 60, '01/03/2021', '18/03/2018', 7);

--Tarefa 4
UPDATE Personagens
SET Nome = 'Fer7'
WHERE IdPersonagem = 3;

--Tarefa 5
UPDATE Classes
SET Nome = 'Necromancer'
WHERE IdClasse = 5;


-- API Update
INSERT INTO TiposDeUsuarios (Titulo)
VALUES ('Administrador'),
       ('Jogador');
GO

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES ('admin@admin.com', 'admin', 1),
       ('jogador@jogador.com', 'jogador', 2);
GO

UPDATE Personagens
SET IdUsuario = 2;