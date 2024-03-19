DROP TABLE IF EXISTS Transactions;
DROP TABLE IF EXISTS VendingMachine_Product;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Supplier;
DROP TABLE IF EXISTS Maintenance;
DROP TABLE IF EXISTS VendingMachine;

CREATE TABLE VendingMachine(
	idVendingMachine INT PRIMARY KEY IDENTITY (1,1),
	posizione VARCHAR(50) NOT NULL,
	modello VARCHAR(50) NOT NULL
);

CREATE TABLE Maintenance(
	idMaintenance INT PRIMARY KEY IDENTITY (1,1),
	data_manutenzione DATE NOT NULL,
	descrizione TEXT,
	vendingMachineRIF INT NOT NULL
FOREIGN KEY (vendingMachineRIF) REFERENCES VendingMachine(idVendingMachine)
);

CREATE TABLE Supplier(
	idSupplier INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(30) NOT NULL,
	contatto VARCHAR(20) NOT NULL
UNIQUE (nome,contatto)
);

CREATE TABLE Product(
	idProduct INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	prezzo DECIMAL (3,2) NOT NULL,
	quantita INT,
	vendingMachineRIF INT NOT NULL,
	supplierRIF INT NOT NULL
FOREIGN KEY (vendingMachineRIF) REFERENCES VendingMachine(idVendingMachine),
FOREIGN KEY (supplierRIF) REFERENCES Supplier(idSupplier)
);

CREATE TABLE Transactions(
	idTransaction INT PRIMARY KEY IDENTITY (1,1),
	data_transazione DATETIME NOT NULL,
	importo DECIMAL (3,2),
	productRIF INT NOT NULL
FOREIGN KEY (productRIF) REFERENCES Product(idProduct)
);

INSERT INTO VendingMachine (posizione, modello) VALUES
	('posizione1', 'modello1'),
	('posizione2', 'modello1'),
	('posizione3', 'modello2'),
	('posizione4', 'modello2'),
	('posizione5', 'modello3'),
	('posizione6', 'modello3');

INSERT INTO Maintenance (data_manutenzione, descrizione, vendingMachineRIF) VALUES
	('2024-03-15T14:03:56','manutenzione settimanale',1),
	('2024-03-08T14:14:02','manutenzione settimanale',1),
	('2024-03-17T11:51:27',null,1);


INSERT INTO Maintenance (data_manutenzione, descrizione, vendingMachineRIF) VALUES
	('2024-03-22T14:03:56','manutenzione settimanale',1),
	('2024-03-08T14:14:02','manutenzione settimanale',2),
	('2024-03-17T11:51:27',null,2);

INSERT INTO Supplier (nome, contatto) VALUES	
	('supplier1','supp1@email.com'),
	('supplier2','supp2@email.com');

INSERT INTO Product (nome, prezzo, quantita, vendingMachineRIF, supplierRIF) VALUES
	('prodotto1',3.50,10,1,1),
	('prodotto2',2.50,7,1,1),
	('prodotto3',5.50,15,1,2);

INSERT INTO Transactions (data_transazione, importo, productRIF) VALUES
	('2024-02-11',3.50,1),
	('2024-02-11',5.50,3),
	('2024-02-11',2.50,2),
	('2024-02-11',3.50,1);

SELECT * FROM VendingMachine;
SELECT * FROM Maintenance;
SELECT * FROM Supplier;
SELECT * FROM Product;
SELECT * FROM Transactions;

DROP VIEW IF EXISTS ProductsByVendingMachine;
CREATE VIEW ProductsByVendingMachine AS
	SELECT idVendingMachine, posizione, Product.nome, prezzo, quantita  FROM VendingMachine
		JOIN Product ON VendingMachine.idVendingMachine = Product.vendingMachineRIF;

SELECT * FROM ProductsByVendingMachine;

DROP VIEW IF EXISTS RecentTransactions;
CREATE VIEW RecentTransactions AS
	SELECT idTransaction, data_transazione, Supplier.nome AS 'Nome supplier', Product.nome AS 'Nome product', importo FROM Supplier
		JOIN Product ON Supplier.idSupplier = Product.supplierRIF
		JOIN Transactions ON Product.idProduct = Transactions.productRIF

SELECT * FROM RecentTransactions;

CREATE VIEW ScheduledMaintenance AS
	SELECT TOP 2 * FROM VendingMachine
		JOIN Maintenance ON VendingMachine.idVendingMachine = Maintenance.vendingMachineRIF
		ORDER BY Maintenance.data_manutenzione DESC;
-- Da vedere



DROP PROCEDURE IF EXISTS RefillProduct;
CREATE PROCEDURE RefillProduct
	@stockAggiunto INT,
	@idVendingMachine INT,
	@idProdotto INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			
			DECLARE @vecchioStock INT;

			DECLARE @cont INT;

			SELECT @cont = COUNT(*) FROM Product
				WHERE idProduct = @idProdotto AND vendingMachineRIF = @idVendingMachine;

			IF @cont <> 0
			BEGIN
				UPDATE Product SET
					quantita = quantita + @stockAggiunto
					WHERE idProduct = @idProdotto
			END

			ELSE
				THROW 50003, 'Prodotto non trovato', 1

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERRORE: ' + ERROR_MESSAGE()
	END CATCH
END;

SELECT * FROM Product;

EXEC RefillProduct @stockAggiunto = 2, @idProdotto = 1, @idVendingMachine = 1;

DROP PROCEDURE IF EXISTS RecordTransaction;
CREATE PROCEDURE RecordTransaction
	@idProdotto INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			DECLARE @cont INT;
			DECLARE @vecchioStock INT;
			DECLARE @prezzo DECIMAL (3,2);

			SELECT @cont = COUNT(*) FROM Product
				WHERE idProduct = @idProdotto;

			SELECT @prezzo = prezzo FROM Product
				WHERE idProduct = @idProdotto;

			SELECT @vecchioStock = quantita FROM Product
				WHERE idProduct = @idProdotto;

			IF @vecchioStock = 0
				THROW 50005, 'Il prodotto non e disponibile', 1

			IF @cont <> 0
			BEGIN
				INSERT INTO Transactions (productRIF, importo, data_transazione) VALUES
					(@idProdotto, @prezzo, CURRENT_TIMESTAMP);

				UPDATE Product SET
					quantita = quantita - 1
					WHERE idProduct = @idProdotto
			END

			ELSE
				THROW 50002, 'Prodotto non trovato', 1

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERRORE: ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC RecordTransaction @idProdotto = 1;

SELECT * FROM Transactions
	JOIN Product ON Transactions.productRIF = Product.idProduct;

DROP PROCEDURE IF EXISTS ScheduleMaintenance;
CREATE PROCEDURE ScheduleMaintenance
	@nuovaData DATE,
	@idVendingMachine INT,
	@descrizione TEXT = NULL
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			
			IF @nuovaData > CURRENT_TIMESTAMP
			BEGIN
				INSERT INTO Maintenance(vendingMachineRIF, data_manutenzione, descrizione) VALUES
					(@idVendingMachine, @nuovaData, @descrizione);
			END
			ELSE
				THROW 50001, 'Data non valida', 1

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERROR ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC ScheduleMaintenance @nuovaData = '2024-03-18', @idVendingMachine = 1, @descrizione = 'manutenzione settimanale';

SELECT * FROM Maintenance;

DROP PROCEDURE IF EXISTS UpdateProductPrice;
CREATE PROCEDURE UpdateProductPrice
	@idProdotto INT,
	@nuovoPrezzo DECIMAL (3,2)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			IF @nuovoPrezzo < 0
				THROW 50005, 'Prezzo negativo', 1

			DECLARE @cont INT;

			SELECT @cont = COUNT(*) FROM Product
				WHERE idProduct = @idProdotto;

			IF @cont <> 0
			BEGIN

				UPDATE Product SET
					prezzo = @nuovoPrezzo
					WHERE idProduct = @idProdotto
			END

			ELSE
				THROW 50004, 'Prodotto non trovato', 1

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERROR ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC UpdateProductPrice @idProdotto = 1, @nuovoPrezzo = 5.50;

SELECT * FROM Product;