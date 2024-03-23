USE progetto05_Eventi;

DROP TABLE IF EXISTS Evento;
DROP TABLE IF EXISTS Risorsa;
DROP TABLE IF EXISTS Partecipante;

CREATE TABLE Partecipante(
	partecipanteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Risorsa(
	risorsaID INT PRIMARY KEY IDENTITY (1,1),
	tipo VARCHAR(50) NOT NULL,
	nome VARCHAR(50) NOT NULL,
	quantita INT NOT NULL CHECK (quantita > 0),
	prezzo DECIMAL (7,2) NOT NULL CHECK (prezzo > 0),
	fornitore VARCHAR(50) NOT NULL,
);

CREATE TABLE Evento(
	eventoID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(100) NOT NULL,
	data_evento DATE NOT NULL,
	luogo VARCHAR(100) NOT NULL,
	capacita INT NOT NULL CHECK (capacita > 0),
	partecipanteRIF INT,
	risorsaRIF INT
FOREIGN KEY (partecipanteRIF) REFERENCES Partecipante(partecipanteID),
FOREIGN KEY (risorsaRIF) REFERENCES Risorsa(risorsaID)
);

SELECT * FROM Partecipante;

SELECT * FROM Risorsa;

SELECT * FROM Evento;

SELECT * FROM Evento
	JOIN Partecipante ON Evento.partecipanteRIF = Partecipante.partecipanteID;

SELECT * FROM Evento
	JOIN Risorsa ON Evento.risorsaRIF = Risorsa.risorsaID;