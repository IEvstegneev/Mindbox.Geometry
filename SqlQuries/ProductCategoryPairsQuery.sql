USE master;

DROP DATABASE IF EXISTS Store;
GO

CREATE DATABASE Store;
GO

USE Store;

CREATE TABLE Products (Id int PRIMARY KEY IDENTITY, Name nvarchar(50));
CREATE TABLE Categories (Id int PRIMARY KEY IDENTITY, Name nvarchar(50));

CREATE TABLE ProductCategory (
	ProductId int NOT NULL,
	CategoryId int NOT NULL,
	CONSTRAINT pk_product_category PRIMARY KEY (ProductId, CategoryId),
	CONSTRAINT fk_product_id FOREIGN KEY (ProductId) REFERENCES Products (Id) ON DELETE CASCADE,
	CONSTRAINT fk_category_id FOREIGN KEY (CategoryId) REFERENCES Categories (Id) ON DELETE NO ACTION
);
GO

INSERT INTO Categories (Name)
VALUES ('Toys'), ('Books'), ('Pets');

INSERT INTO Products VALUES ('Car'), ('Ball'), ('Cat'), ('Dog'), ('Fairy Tales'), ('CookBook'), ('Note');

INSERT INTO ProductCategory (ProductId, CategoryId) 
		  SELECT p.Id, c.Id FROM Products p JOIN Categories c ON p.Name = 'Car' AND c.Name = 'Toys'
	UNION SELECT p.Id, c.Id FROM Products p JOIN Categories c ON p.Name = 'Ball' AND c.Name = 'Toys'
	UNION SELECT p.Id, c.Id FROM Products p JOIN Categories c ON p.Name = 'Cat' AND c.Name = 'Pets'
	UNION SELECT p.Id, c.Id FROM Products p JOIN Categories c ON p.Name = 'Dog' AND c.Name = 'Pets'
	UNION SELECT p.Id, c.Id FROM Products p JOIN Categories c ON p.Name = 'Fairy Tales' AND c.Name = 'Books'
	UNION SELECT p.Id, c.Id FROM Products p JOIN Categories c ON p.Name = 'CookBook' AND c.Name = 'Books';
GO

SELECT p.Name AS [Product], c.Name AS [Category] From Products p 
	LEFT JOIN ProductCategory pc ON pc.ProductId  = p.Id
	LEFT JOIN Categories c ON c.Id = pc.CategoryId;


