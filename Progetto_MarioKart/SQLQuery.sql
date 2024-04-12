USE Progetto_MarioKart;

DROP TABLE IF EXISTS Personaggio;
DROP TABLE IF EXISTS Giocatore;

CREATE TABLE Giocatore(
	giocatoreID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	crediti INT NOT NULL,
	colore VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE Personaggio(
	personaggioID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL UNIQUE,
	categoria VARCHAR(10) NOT NULL,
	mezzo VARCHAR(50) NOT NULL,
	costo INT NOT NULL,
	giocatoreRIF INT
FOREIGN KEY (giocatoreRIF) REFERENCES Giocatore(giocatoreID) ON DELETE SET NULL
);

ALTER TABLE Giocatore ADD CHECK(crediti >= 0);
ALTER TABLE Giocatore ADD CHECK(crediti <= 10);
ALTER TABLE Personaggio ADD CHECK (categoria IN ('50cc','100cc','150cc'));
ALTER TABLE Personaggio ADD CHECK (mezzo IN ('Kart','Moto'));
ALTER TABLE Personaggio ADD CHECK (costo BETWEEN 1 AND 4);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Mario','100cc','Kart',3),
	('Luigi','100cc','Kart',3),
	('Peach','100cc','Moto',3),
	('Daisy','100cc','Moto',3);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Yoshi','100cc','Kart',2),
	('BowserJR','100cc','Moto',2);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Bowser','100cc','Kart',4),
	('Donkey Kong','100cc','Moto',4);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Baby Mario','50cc','Kart',3),
	('Baby Luigi','50cc','Kart',3),
	('Baby Peach','50cc','Moto',3),
	('Baby Daisy','50cc','Moto',3);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Tipo Timido','50cc','Kart',2),
	('Toad','50cc','Moto',2);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Diddy Kong','50cc','Kart',4),
	('Koopa','50cc','Moto',4);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Wario','150cc','Kart',3),
	('Link','150cc','Kart',3),
	('Rosalina','150cc','Moto',3),
	('Inkling','150cc','Moto',3);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Skelekoopa','150cc','Kart',2),
	('King Boo','150cc','Moto',2);

INSERT INTO Personaggio (nome,categoria,mezzo,costo) VALUES
	('Waluigi','150cc','Kart',4),
	('Funky Kong','150cc','Moto',4);

SELECT * FROM Personaggio;
SELECT * FROM Giocatore;

SELECT * FROM Giocatore
	JOIN Personaggio ON Giocatore.giocatoreID = Personaggio.giocatoreRIF;