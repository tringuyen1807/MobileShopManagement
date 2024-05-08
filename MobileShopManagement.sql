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
    ('MB01', 'Samsung', 'Galaxy J7 Prime', '16GB', 5000000),
	('MB02', 'Iphone', '6 Plus', '32GB', 6000000),
	('MB03', 'OPPO', 'Neo 5', '16GB', 3200000);

INSERT INTO Customer 
VALUES
    ('C01', N'Nguyễn Minh Trí', 'Male', 'Samsung Galaxy J7 Prime', 5000000),
	('C02', N'Quang Chí Vĩ', 'Male', 'Iphone XS Max', 12000000),
	('C03', N'Nguyen Van A', 'Male', 'Samsung Galaxy S22', 25000000);