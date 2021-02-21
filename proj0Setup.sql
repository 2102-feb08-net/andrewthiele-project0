--CREATE SCHEMA StoreApp;
--DROP TABLE IF EXISTS Products;
CREATE TABLE Products 
(
	productID INT NOT NULL PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT 'product',
	price SMALLMONEY NULL DEFAULT 0.00, 
	quantity INT NOT NULL DEFAULT 0
)

--DROP TABLE IF EXISTS Customers;
CREATE TABLE Customers
(
	customerID INT NOT NULL PRIMARY KEY,
	firstName NVARCHAR(100) NOT NULL DEFAULT 'Bob',
	lastName NVARCHAR(100) NOT NULL DEFAULT 'Jones',
	balance MONEY NOT NULL DEFAULT 0.00
	--defaultLocation INT NULL 
)

--DROP TABLE IF EXISTS Locations;
CREATE TABLE Locations
(
	locationID INT NOT NULL PRIMARY KEY,
	nickname NVARCHAR(100) NOT NULL DEFAULT '',
	address1 NVARCHAR(100) NOT NULL DEFAULT 'THIS STREET',
	address2 NVARCHAR(100) NOT NULL DEFAULT '',
	city NVARCHAR(100) NOT NULL DEFAULT 'CITYTOWN',
	state NVARCHAR(50) NOT NULL DEFAULT 'STATE',
)

ALTER TABLE Locations
ALTER COLUMN nickname NVARCHAR(100)



--DROP TABLE IF EXISTS Invoices;
CREATE TABLE Invoices
(
	InvoiceID INT NOT NULL PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
	timeOfOrder DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
	LocationID INT FOREIGN KEY REFERENCES Locations(LocationID)	
);

--DROP TABLE IF EXISTS Orders;
CREATE TABLE Orders
(
	orderID INT NOT NULL PRIMARY KEY,
	invoiceID INT FOREIGN KEY REFERENCES Invoices(InvoiceID),
	productID INT FOREIGN KEY REFERENCES Products(ProductID),
	
	quantity INT NOT NULL DEFAULT 0,
)

INSERT INTO Customers(customerID, firstName, lastName, balance) VALUES
(0,'Bob','Smith',100),
(1,'Fred','Jones',0),
(2,'Mark','Johnson',20)

INSERT INTO Products(productID, name, price, quantity) VALUES
(0,'bread',1.50,1),
(1,'milk',2.30,2),
(2,'eggs',5.60,3),
(3,'vegetable',7.80,4),
(4,'fruit',8.20,5)

INSERT INTO Locations(locationID, nickname, address1, address2, city, state) VALUES
(0,'OKCI1','Here','Apt 15','Oklahoma City','OK'),
(1,'CHIC1','Here','Apt 15','Chicago City','IL'),
(2,'KC1','Here','Apt 15','Kansas City','UT'),
(3,'FLOR1','Here','Apt 15','Florida City','ND'),
(4,'LOCK2','Here','Apt 15','Big City','TX'),
(5,'BIGFUN3','Here','Apt 15','Little City','NH')

INSERT INTO Invoices(InvoiceID,CustomerID,timeOfOrder,LocationID) VALUES
(0,2,SYSDATETIMEOFFSET(),5),
(1,0,SYSDATETIMEOFFSET(),4),
(2,0,SYSDATETIMEOFFSET(),3),
(3,1,SYSDATETIMEOFFSET(),2),
(4,1,SYSDATETIMEOFFSET(),1),
(5,2,SYSDATETIMEOFFSET(),1)

INSERT INTO Orders(orderID, invoiceID, productID, quantity) VALUES
(0,3,2,5),
(1,0,0,10),
(2,2,1,1),
(3,1,3,3),
(4,4,4,4),
(5,5,4,5)