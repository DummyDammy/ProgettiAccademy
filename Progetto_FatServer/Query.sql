USE Progetto_FatServer;

DROP TABLE IF EXISTS Impiegato;
DROP TABLE IF EXISTS Citta;
DROP TABLE IF EXISTS Provincia;
DROP TABLE IF EXISTS Reparto;

CREATE TABLE Reparto(
	repartoID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Provincia(
	provinciaID INT PRIMARY KEY IDENTITY (1,1),
	provincia VARCHAR(10) NOT NULL UNIQUE
);

CREATE TABLE Citta(
	cittaID INT PRIMARY KEY IDENTITY(1,1),
	citta VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Impiegato(
	impiegatoID INT PRIMARY KEY IDENTITY (1,1),
	matricola VARCHAR(15) NOT NULL UNIQUE,
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	ruolo VARCHAR(50) NOT NULL DEFAULT 'Non Allocato',
	dataNascita DATE NOT NULL,
	viaResidenza VARCHAR(100) NOT NULL,
	repartoRIF INT NOT NULL DEFAULT 1,
	cittaRIF INT NOT NULL,
	provinciaRIF INT NOT NULL
FOREIGN KEY (repartoRIF) REFERENCES Reparto(RepartoID) ON DELETE CASCADE,
FOREIGN KEY (cittaRIF) REFERENCES Citta(cittaID) ON DELETE CASCADE,
FOREIGN KEY (provinciaRIF) REFERENCES Provincia(provinciaID) ON DELETE CASCADE
);

INSERT INTO Reparto(nome) VALUES ('Non allocato');

INSERT INTO Reparto(nome) VALUES ('Reception');
INSERT INTO Reparto(nome) VALUES ('Maintenance');
INSERT INTO Reparto(nome) VALUES ('Uffici');

INSERT INTO Provincia (provincia) VALUES ('RM');
INSERT INTO Provincia (provincia) VALUES ('ML');
INSERT INTO Provincia (provincia) VALUES ('CA');

INSERT INTO Citta (citta) VALUES ('RM');
INSERT INTO Citta (citta) VALUES ('Nettuno');
INSERT INTO Citta (citta) VALUES ('ML');
INSERT INTO Citta (citta) VALUES ('Cremona');

INSERT INTO Impiegato (matricola, nome, cognome, ruolo, repartoRIF , dataNascita, viaResidenza, cittaRIF, provinciaRIF) VALUES
 ('NC123','Nome','Cognome','ruolo',1,'2020-10-10','Via',1,1);

SELECT * FROM Reparto ORDER BY repartoID;

SELECT * FROM Provincia ORDER BY provinciaID;

SELECT * FROM Citta ORDER BY cittaID;

SELECT * FROM Impiegato
	JOIN Reparto ON Impiegato.repartoRIF = Reparto.repartoID