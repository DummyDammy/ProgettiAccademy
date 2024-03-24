USE progetto05_02_Eventi;

DROP TABLE IF EXISTS Evento_Risorsa;
DROP TABLE IF EXISTS Evento_Partecipante;
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
	nome VARCHAR(100) NOT NULL UNIQUE,
	data_evento DATE NOT NULL,
	luogo VARCHAR(100) NOT NULL,
	capacita INT NOT NULL CHECK (capacita > 0)
);

CREATE TABLE Evento_Partecipante(
	eventoRIF INT NOT NULL,
	partecipanteRIF INT NOT NULL
FOREIGN KEY (eventoRIF) REFERENCES Evento(eventoID),
FOREIGN KEY (partecipanteRIF) REFERENCES Partecipante(partecipanteID),
PRIMARY KEY (eventoRIF, partecipanteRIF)
);

CREATE TABLE Evento_Risorsa(
	eventoRIF INT NOT NULL,
	risorsaRIF INT NOT NULL
FOREIGN KEY (eventoRIF) REFERENCES Evento(eventoID),
FOREIGN KEY (risorsaRIF) REFERENCES Risorsa(risorsaID),
PRIMARY KEY (eventoRIF, risorsaRIF)
);

SELECT * FROM Evento;

SELECT * FROM Partecipante;

SELECT * FROM Evento_Partecipante;

SELECT * FROM Risorsa;

SELECT * FROM Evento
	JOIN Evento_Partecipante ON Evento.eventoID = Evento_Partecipante.eventoRIF
	JOIN Partecipante ON Evento_Partecipante.partecipanteRIF = Partecipante.partecipanteID;

SELECT * FROM Evento
	JOIN Evento_Risorsa ON Evento.eventoID = Evento_Risorsa.eventoRIF
	JOIN Risorsa ON Evento_Risorsa.risorsaRIF = Risorsa.risorsaID;