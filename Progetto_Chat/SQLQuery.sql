USE Progetto_Chat;

DROP TABLE IF EXISTS Utente;

CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY (1,1),
	nickname VARCHAR(30) NOT NULL UNIQUE,
	pass VARCHAR(50) NOT NULL,
	email VARCHAR(30) NOT NULL UNIQUE
);

INSERT INTO Utente (nickname, pass, email) VALUES
	('Whatsup','1rOjàkcJG-ki?N8fijXGCkliHòiglk','');

SELECT * FROM Utente;