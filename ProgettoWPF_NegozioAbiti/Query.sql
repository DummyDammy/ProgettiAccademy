USE progetto06_NegozioAbiti;

DROP TABLE IF EXISTS Ordine;
DROP TABLE IF EXISTS Offerta;
DROP TABLE IF EXISTS Variazione;
DROP TABLE IF EXISTS Prodotto;
DROP TABLE IF EXISTS Categoria;
DROP TABLE IF EXISTS Utente;

CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	telefono VARCHAR(15) UNIQUE NOT NULL
);

CREATE TABLE Categoria(
	categoriaID INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Prodotto(
	prodottoID INT PRIMARY KEY IDENTITY (1,1),
	marca VARCHAR(50) NOT NULL,
	nome VARCHAR(50) NOT NULL,
	descrizione TEXT,
	categoriaRIF INT NOT NULL
FOREIGN KEY (categoriaRIF) REFERENCES Categoria(categoriaID) ON DELETE CASCADE
);

CREATE TABLE Variazione(
	variazioneID INT PRIMARY KEY IDENTITY (1,1),
	taglia VARCHAR(10) NOT NULL,
	prezzo DECIMAL(7,2) NOT NULL,
	colore VARCHAR(30) NOT NULL,
	quantita INT NOT NULL CHECK (quantita > 0),
	prodottoRIF INT NOT NULL
FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID) ON DELETE CASCADE
);

CREATE TABLE Offerta(
	offertaID INT PRIMARY KEY IDENTITY (1,1),
	data_inizio DATE NOT NULL,
	data_fine DATE NOT NULL,
	sconto INT NOT NULL,
	variazioneRIF INT NOT NULL
FOREIGN KEY (variazioneRIF) REFERENCES Variazione(variazioneID) ON DELETE CASCADE
);

CREATE TABLE Ordine(
	ordineID INT PRIMARY KEY IDENTITY (1,1),
	data_ordine DATETIME NOT NULL,
	data_ritiro DATETIME,
	quantita INT NOT NULL CHECK (quantita>0),
	variazioneRIF INT NOT NULL,
	utenteRIF INT NOT NULL
FOREIGN KEY (variazioneRIF) REFERENCES Variazione(variazioneID) ON DELETE CASCADE,
FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID) ON DELETE CASCADE
);

SELECT * FROM Utente;