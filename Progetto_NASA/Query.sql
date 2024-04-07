--Creare il sistema di gestione oggetti celesti per la NASA

--Ogni oggetto celeste e caratterizzato da:
--	nome
--	codice
--	data scoperta
--	scopritore
--	tipo
--	distanza dalla terra
--	coordinate polari

--Ogni oggetto celeste puo far parte di uno o piu sistemi

--Ogni sistema e caratterizzato da
--	tipo (Sistema planetario, Costellazione, galassia)
--	nome 
--	codice

--Ricercare gli elementi per
--	nome dell'oggetto celeste
--	tipo di sistema
--	scopritore
--	tipologia

--Regole
--	Non posso inserire un oggetto all'interno di un sistema se fa gia parte di un altro sistema della stesso tipo anche se di codice diverso
--	No scaffolding

USE API_NASA;

DROP TABLE IF EXISTS SistemaCorpo;
DROP TABLE IF EXISTS Corpo;
DROP TABLE IF EXISTS Sistema;

CREATE TABLE Sistema(
	sistemaID INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR(50) NOT NULL UNIQUE,
	nome VARCHAR(100) NOT NULL,
	tipo VARCHAR(100) NOT NULL
);

CREATE TABLE Corpo(
	CorpoID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(100) NOT NULL,
	codice VARCHAR(50) NOT NULL UNIQUE,
	dataScoperta DATE NOT NULL,
	tipo VARCHAR(100) NOT NULL,
	distanza DECIMAL (10,2) NOT NULL,
	scopritore VARCHAR(100) DEFAULT 'Sconosciuto',
	coordinataAngolare DECIMAL (10,2) NOT NULL,
	coordinataRadiale DECIMAL (10,2) NOT NULL
);

CREATE TABLE SistemaCorpo(
	SistemaRIF INT NOT NULL,
	CorpoRIF INT NOT NULL
FOREIGN KEY (SistemaRIF) REFERENCES Sistema(SistemaID) ON DELETE CASCADE,
FOREIGN KEY (CorpoRIF) REFERENCES Corpo(CorpoID) ON DELETE CASCADE,
PRIMARY KEY (SistemaRIF, CorpoRIF)
);

INSERT INTO Sistema (codice, nome, tipo) VALUES ('boi','boi','boi');

INSERT INTO Corpo (nome, codice, dataScoperta, tipo, distanza, scopritore, coordinataAngolare, coordinataRadiale) VALUES
	('boiplanet','boip','2000-10-10','planet',10,'boio',210,10);

SELECT * FROM Sistema;

DELETE FROM Sistema WHERE sistemaID = 3;

SELECT * FROM Corpo;

INSERT INTO SistemaCorpo (SistemaRIF, CorpoRIF) VALUES (1,1);

SELECT * FROM Sistema
	JOIN SistemaCorpo ON SistemaCorpo.SistemaRIF = Sistema.sistemaID
	JOIN Corpo ON SistemaCorpo.CorpoRIF = Corpo.CorpoID;