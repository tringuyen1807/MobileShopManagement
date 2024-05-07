create database MobileShopManagement
use MobileShopManagement

create table Product (
	MobileID VARCHAR(10) primary key,
	MobileName VARCHAR(50),
	Series VARCHAR(50),
	Storage VARCHAR(50),
	Price FLOAT
);

create table Customer (
	CustomerID VARCHAR(10) primary key,
	CustomerName VARCHAR(50),
	Gender VARCHAR(8),
	PurchasedMobile VARCHAR(50),
	Bill FLOAT
);


--------------------------
INSERT INTO Product 
VALUES
    ('MB01', 'Samsung', 'Galaxy J7 Prime', '16GB', 5000000);

INSERT INTO Customer 
VALUES
    ('C01', N'Nguyễn Minh Trí', 'Male', 'Samsung Galaxy J7 Prime', 5000000);