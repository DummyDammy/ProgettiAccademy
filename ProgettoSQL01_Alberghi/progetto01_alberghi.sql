DROP TABLE IF EXISTS Prenotazione;
DROP TABLE IF EXISTS Camera;
DROP TABLE IF EXISTS Facility;
DROP TABLE IF EXISTS Dipendente;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Albergo;

CREATE TABLE Albergo(
	albergoID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(100) NOT NULL,
	indirizzo VARCHAR(100) NOT NULL,
	valutazione INT CHECK (valutazione BETWEEN 0 AND 5),
UNIQUE (nome,indirizzo)
);

-- INIZIO Persona
CREATE TABLE Cliente(
	clienteID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	contatto TEXT NOT NULL
);

CREATE TABLE Dipendente(
	dipendenteID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	contatto TEXT NOT NULL,
	posizione VARCHAR(50) NOT NULL,
	albergoRIF INT NOT NULL,
FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE
);
-- FINE Persona

CREATE TABLE Facility(
	facilityID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	descrizione TEXT,
	orario_apertura CHAR(20) NOT NULL,
	orario_chiusura CHAR(20) NOT NULL,
	albergoRIF INT NOT NULL,
FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE
);

CREATE TABLE Camera(
	cameraID INT PRIMARY KEY IDENTITY (1,1),
	numero INT NOT NULL,
	tipo VARCHAR(50) NOT NULL,
	capacita INT NOT NULL,
	tariffa DECIMAL (10,2) NOT NULL CHECK (tariffa > 0),
	albergoRIF INT NOT NULL,
FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE,
UNIQUE (numero,albergoRIF)
);

CREATE TABLE Prenotazione(
	prenotazioID INT PRIMARY KEY IDENTITY (1,1),
	data_inizio DATE NOT NULL,
	data_fine DATE NOT NULL,
	clienteRIF INT NOT NULL,
	cameraRIF INT NOT NULL,
FOREIGN KEY (clienteRIF) REFERENCES Cliente(clienteID) ON DELETE CASCADE,
FOREIGN KEY (cameraRIF) REFERENCES Camera(cameraID) ON DELETE CASCADE
);

ALTER TABLE Prenotazione ADD CONSTRAINT CHK_data_fine CHECK (data_fine > data_inizio);

INSERT INTO Albergo (nome, indirizzo, valutazione) VALUES
	('albergo1','via albergo1',4),
	('albergo2','via albergo2',0),
	('albergo3','via albergo3',5);

INSERT INTO Cliente (nome, cognome, contatto) VALUES
	('cliente1','cliente1','33344445555'),
	('cliente2','cliente2','33344445556'),
	('cliente3','cliente3','33344445557');

INSERT INTO Dipendente (nome, cognome, contatto, posizione, albergoRIF) VALUES
	('dipendente1','dipendente1','dpn1@dpn.it','posizione1',1),
	('dipendente2','dipendente2','dpn2@dpn.it','posizione2',1),
	('dipendente3','dipendente3','dpn3@dpn.it','posizione1',1);

INSERT INTO Camera (numero, tipo, capacita, tariffa, albergoRIF) VALUES
	(1,'singola',1,50,1),
	(1,'singola',1,50,2),
	(2,'doppia',1,50,1);

INSERT INTO Prenotazione (data_inizio, data_fine, cameraRIF, clienteRIF) VALUES
	('2020-10-10','2020-10-12',1,1),
	('2020-10-10','2020-10-12',2,2),
	('2020-10-10','2020-10-12',3,3);

INSERT INTO Facility (nome, descrizione, orario_apertura, orario_chiusura, albergoRIF) VALUES
	('Palestra','descrizione1','06:00','18:00',1),
	('Palestra2','descrizione2','06:00','18:00',1),
	('Palestra3','descrizione3','06:00','18:00',2);


SELECT * FROM Camera;
SELECT * FROM Albergo;
SELECT * FROM Facility;  
SELECT * FROM Cliente;
SELECT * FROM Dipendente;
SELECT * FROM Prenotazione;

-- Equivalente di funzione
DROP VIEW IF EXISTS dettaglioGeneraleAlberghiFacility;
DROP VIEW IF EXISTS dettaglioGeneraleAlberghiFacility;
DROP VIEW IF EXISTS albergoGeneraleConClienti;

CREATE VIEW albergoGeneraleConClienti AS
-- dichiaro AS nome_albergo per ordinare successivamente
  	SELECT albergoID, al.nome AS nome_albergo, indirizzo, cl.nome + ' ' + cl.cognome AS 'Nominativo' FROM Albergo AS al
    	JOIN Camera ca ON al.albergoID = ca.albergoRIF
    	JOIN Prenotazione pr ON ca.cameraID = pr.cameraRIF
    	JOIN Cliente cl ON pr.clienteRIF = cl.clienteID;
--Per cambiare nome alla variabile
 
CREATE VIEW dettaglioGeneraleAlberghiFacility AS
  	SELECT nome_albergo, indirizzo, nominativo, nome, descrizione, orario_apertura, orario_chiusura FROM albergoGeneraleConClienti
    	JOIN Facility f ON albergoGeneraleConClienti.albergoID = f.albergoRIF;
 
SELECT * FROM dettaglioGeneraleAlberghiFacility 
  	ORDER BY nome_albergo; -- richiami dalla prima funzione anche se usi la terza
 
-- Conta tutti i clienti per un albergo
SELECT COUNT(*) AS 'Numero clienti' FROM albergoGeneraleConClienti WHERE nome_albergo = 'albergo1';