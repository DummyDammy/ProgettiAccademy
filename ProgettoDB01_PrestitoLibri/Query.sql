DROP TABLE IF EXISTS Utente;
CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE
);

DROP TABLE IF EXISTS Libro;
CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY (1,1),
	titolo VARCHAR(100) NOT NULL,
	annoPubblicazione DATE NOT NULL,
	isDisponibile BIT DEFAULT 1
);

DROP TABLE IF EXISTS Prestito;
CREATE TABLE Prestito(
	prestitOID INT PRIMARY KEY IDENTITY (1,1),
	dataInizio DATE NOT NULL,
	dataRitorno DATE,
	utenteRIF INT NOT NULL,
	libroRIF INT NOT NULL
FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID) ON DELETE CASCADE,
FOREIGN KEY (libroRIF) REFERENCES Libro(libroID) ON DELETE CASCADE
);

INSERT INTO Libro (titolo, annoPubblicazione) VALUES
	('Libro 1','2020-10-10');

INSERT INTO Utente (nome, cognome, email) VALUES
	('Utente1Nome','Utente1Cognome','utente1@email.com');