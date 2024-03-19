DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Review;
DROP TABLE IF EXISTS Ticket;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Showtime;
DROP TABLE IF EXISTS Movie;
DROP TABLE IF EXISTS Theater;
DROP TABLE IF EXISTS Cinema;

CREATE TABLE Cinema (
	CinemaID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	Address VARCHAR(255) NOT NULL,
	Phone VARCHAR(20)
);

CREATE TABLE Theater (
	TheaterID INT PRIMARY KEY IDENTITY (1,1),
	CinemaID INT NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Capacity INT NOT NULL,
	ScreenType VARCHAR(50),
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);

CREATE TABLE Movie (
	MovieID INT PRIMARY KEY IDENTITY (1,1),
	Title VARCHAR(255) NOT NULL,
	Director VARCHAR(100),
	ReleaseDate DATE,
	DurationMinutes INT,
	Rating VARCHAR(5)
);

CREATE TABLE Showtime (
	ShowtimeID INT PRIMARY KEY IDENTITY (1,1),
	MovieID INT NOT NULL,
	TheaterID INT NOT NULL,
	ShowDateTime DATETIME NOT NULL,
	Price DECIMAL(5,2) NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (TheaterID) REFERENCES Theater(TheaterID)
);

CREATE TABLE Customer (
	CustomerID INT PRIMARY KEY IDENTITY (1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Email VARCHAR(100),
	PhoneNumber VARCHAR(20)
);

CREATE TABLE Ticket (
	TicketID INT PRIMARY KEY IDENTITY (1,1),
	ShowtimeID INT NOT NULL,
	SeatNumber VARCHAR(10) NOT NULL,
	PurchasedDateTime DATETIME NOT NULL,
	CustomerID INT NOT NULL,
	FOREIGN KEY (ShowtimeID) REFERENCES Showtime(ShowtimeID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE Review (
	ReviewID INT PRIMARY KEY IDENTITY (1,1),
	MovieID INT NOT NULL,
	CustomerID INT NOT NULL,
	ReviewText TEXT,
	Rating INT CHECK (Rating >= 1 AND Rating <= 5),
	ReviewDate DATETIME NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE Employee (
	EmployeeID INT PRIMARY KEY IDENTITY (1,1),
	CinemaID INT NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Position VARCHAR(50),
	HireDate DATE,
	FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);

INSERT INTO Cinema (Name, Address, Phone) VALUES
	('Moderno','Via moderna', '3334445555'),
	('Astoria','Via astoria', '3334445556'),
	('Buster','Via buster', '3334445557');

INSERT INTO Theater (CinemaID, Name, Capacity, ScreenType) VALUES
	(1,'Sala 1',50,'normale'),
	(1,'Sala 2',50,'3D'),
	(1,'Sala 3',50,'normale'),
	(2,'Sala A',50,'3D'),
	(2,'Sala B',50,'normale'),
	(2,'Sala C',50,'3D'),
	(3,'Sala A1',50,'normale'),
	(3,'Sala A2',50,'3D'),
	(3,'Sala A3',50,'normale');

INSERT INTO Movie (Title, ReleaseDate, Director, DurationMinutes, Rating) VALUES
	('Colpo di fortuna','2023-02-16','Steven spielberg',90,'16+'),
	('Shrek II','2016-03-21','Dreamworks',110,'3+'),
	('Puss in boots','2022-10-01','Dreamworks',90,'16+');

INSERT INTO Showtime (MovieID, TheaterID, ShowDateTime, Price) VALUES
	(2,6,'2024-04-20T18:00:00',6.00),
	(1,8,'2024-04-22T20:00:00',8.50),
	(3,2,'2024-04-27T19:30:00',9.00);

INSERT INTO Customer (FirstName, LastName, PhoneNumber, Email) VALUES
	('Giangiacomo','della Villa','3412345672','bad.boi@libero.it'),
	('Sten','Onesis',null,null),
	('Claudio','Ma','0612345670','clad.ma@gmail.com');

INSERT INTO Ticket (CustomerID, ShowtimeID, PurchasedDateTime, SeatNumber) VALUES
	(1,1,'2024-04-20T17:50:00','12'),
	(1,2,'2024-04-20T19:50:00','27'),
	(2,1,'2024-04-20T17:50:00','13'),
	(2,3,'2024-04-20T19:10:00','14'),
	(3,2,'2024-04-20T17:50:00','43'),
	(3,2,'2024-04-20T17:50:00','1');

INSERT INTO Review (MovieID, CustomerID, Rating, ReviewText, ReviewDate) VALUES
	(2,1,5,'5/7 Perfect score','2024-04-21T17:50:00'),
	(1,2,3,'Non mi piaceva il doppiaggio','2024-04-24T15:30:00'),
	(3,3,1,'Che schifo','2024-04-30T12:00:00');

INSERT INTO Employee (CinemaID, FirstName, LastName, Position, HireDate) VALUES
	(1,'Clara','Cheno','Receptonist','2020-02-10'),
	(1,'Cross','Ta','CEO','2020-01-01'),
	(2,'Paul','Camiseria','Manutezione','2022-09-09'),
	(2,'Maccio','Capatonda','Manger','2019-01-13'),
	(3,'Halo','Masterchief','Sicurezza','2021-06-19'),
	(3,'Todd','Howard','PR','2016-03-10');

DROP VIEW IF EXISTS FilmsInProgrammations;
CREATE VIEW FilmsInProgrammations AS
	SELECT Title, ShowDateTime, DurationMinutes, Rating FROM Movie
	JOIN Showtime ON Movie.MovieID = Showtime.MovieID;

SELECT * FROM FilmsInProgrammations;

DROP VIEW IF EXISTS AvailableSeatsForShow;
CREATE VIEW	AvailableSeatsForShow AS
	SELECT Title, Capacity, Capacity - (SELECT COUNT(*) FROM Ticket JOIN Showtime ON Showtime.ShowtimeID = Ticket.ShowtimeID) AS Difference FROM Theater
	JOIN Showtime ON Theater.TheaterID = Showtime.TheaterID
	JOIN Movie ON Showtime.MovieID = Movie.MovieID;

SELECT * FROM AvailableSeatsForShow;

DROP VIEW IF EXISTS TotalEarningsPerMovie;
CREATE VIEW TotalEarningsPerMovie AS
	SELECT DISTINCT Title, Price * (SELECT COUNT(*) FROM Ticket JOIN Showtime ON Showtime.ShowtimeID = Ticket.ShowtimeID) AS Total FROM Movie 
	JOIN Showtime ON Movie.MovieID = Showtime.MovieID;

SELECT * FROM TotalEarningsPerMovie;

DROP VIEW IF EXISTS RecentReviews;
CREATE VIEW RecentReviews AS
	SELECT Title, Review.Rating, ReviewText, ReviewDate AS reviewDate FROM Review
	JOIN Movie ON Review.MovieID = Movie.MovieID;

SELECT * FROM RecentReviews
	ORDER BY reviewDate DESC;


DROP PROCEDURE IF EXISTS PurchaseTicket;
CREATE PROCEDURE PurchaseTicket
	@idSpettacolo INT,
	@numeroPosto VARCHAR(10),
	@idCliente INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		
		DECLARE @cont INT;

		SELECT @cont = COUNT(*) FROM ShowTime
			JOIN Ticket ON Showtime.ShowtimeID = Ticket.ShowtimeID
			WHERE Showtime.ShowtimeID = @idSpettacolo AND Ticket.SeatNumber = @numeroPosto
		
		IF @cont = 0
			INSERT INTO Ticket (CustomerID, PurchasedDateTime, SeatNumber, ShowtimeID) VALUES
				(@idCliente, CURRENT_TIMESTAMP, @numeroPosto, @idSpettacolo);

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERRORE: ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC PurchaseTicket @idSpettacolo = 1, @numeroPosto = 23, @idCliente = 1;

SELECT * FROM Ticket;

DROP PROCEDURE IF EXISTS UpdateMovieSchedule;
CREATE PROCEDURE UpdateMovieSchedule
	@idFilm INT,
	@nuovaData DATETIME
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		
		DECLARE @cont INT;

		SELECT @cont = COUNT(*) FROM ShowTime
			WHERE MovieID = @idFilm;
		
		IF @cont <> 0
			UPDATE Showtime SET
				ShowDateTime = @nuovaData
				WHERE MovieID = @idFilm;

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERRORE: ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC UpdateMovieSchedule @idFilm = 3, @nuovaData = '2024-04-28T19:30:00';

SELECT * FROM Showtime;

DROP PROCEDURE IF EXISTS InsertNewMovie;
CREATE PROCEDURE InsertNewMovie
	@titolo VARCHAR(255),
	@direttore VARCHAR(100) = NULL,
	@dataRilascio DATE = NULL,
	@durata INT = NULL,
	@restrizione VARCHAR(5) = NULL
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			IF (@dataRilascio <> NULL AND @dataRilascio < CURRENT_TIMESTAMP)
				THROW 50001, 'Data precedente a oggi', 1

			IF (@durata <> NULL AND @durata <= 0)
				THROW 50002, 'Durata minore di 0 non possibile', 1

			INSERT INTO Movie (Title, Director, ReleaseDate, DurationMinutes, Rating) VALUES
				(@titolo, @direttore, @dataRilascio, @durata, @restrizione);
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERRORE: ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC InsertNewMovie @titolo = 'Planes', @direttore = 'Pixar', @dataRilascio = '2023-01-16', @durata = 130, @restrizione = '7+';

SELECT * FROM Movie;

DROP PROCEDURE IF EXISTS SubmitReview;
CREATE PROCEDURE SubmitReview
	@valutazione INT,
	@testo TEXT,
	@idFilm INT,
	@idCliente INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			DECLARE @cont INT;
			DECLARE @dataFilm DATETIME;

			SELECT @cont = COUNT(*), @dataFilm = ShowDateTime FROM Customer
				JOIN Ticket ON Customer.CustomerID = Ticket.CustomerID
				JOIN Showtime ON Ticket.ShowtimeID = Showtime.ShowtimeID
				JOIN Movie ON Showtime.MovieID = Movie.MovieID
				WHERE Customer.CustomerID = @idCliente 
					AND Movie.MovieID = @idFilm;

			IF @cont <> 0 AND @dataFilm >= CURRENT_TIMESTAMP
				INSERT INTO Review (MovieID, CustomerID, ReviewText, Rating, ReviewDate) VALUES
				(@idFilm, @idCliente, @testo, @valutazione, CURRENT_TIMESTAMP)
				
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT 'ERRORE: ' + ERROR_MESSAGE()
	END CATCH
END;

EXEC SubmitReview @valutazione = 4, @testo = 'Decente', @idFilm = 4, @idCliente = 1;

SELECT * FROM Review;