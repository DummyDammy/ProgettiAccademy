USE Progetto_API;

DROP TABLE IF EXISTS Prodotto;

CREATE TABLE Prodotto(
	prodottoID INT PRIMARY KEY IDENTITY (1,1),
	codice VARCHAR(50) DEFAULT NEWID(),
	nome VARCHAR(100) NOT NULL,
	descrizione TEXT,
	prezzo DECIMAL(10,2) NOT NULL CHECK (prezzo >= 0),
	quantita INT DEFAULT 0 CHECK (quantita >= 0),
	categoria VARCHAR(100) NOT NULL,
	data_creazione DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Prodotto(nome,descrizione,prezzo,quantita,categoria) VALUES
	('Cavo','lungo',7.50,12,'elettronica');

	SELECT * FROM Prodotto;