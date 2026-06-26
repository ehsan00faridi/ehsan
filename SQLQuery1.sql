select * from AspNetUsers

﻿select * from orders


CREATE UNIQUE CLUSTERED INDEX IX_vw_ProductSales
ON vw_ProductSales(ProductId);

DROP INDEX IX_OrderItems_OrderId ON OrderItems;

CREATE NONCLUSTERED INDEX IX_OrderItems_Covering
ON OrderItems (OrderId)
INCLUDE (ProductId, Price, Qty); 

SELECT 
    p.Name AS ProductName,
    c.Name AS CustomerName,
    oi.Price,
    oi.Qty,
    oi.Price * oi.Qty AS TotalPrice
FROM OrderItems oi
JOIN Products p ON oi.ProductId = p.Id
JOIN Orders o ON oi.OrderId = o.Id
JOIN Customers c ON o.CustomerId = c.Id;


CREATE PROCEDURE GetCustomerOrders
    @CustomerId INT
AS
BEGIN
    SELECT 
        p.Name AS ProductName,
        c.Name AS CustomerName,
        oi.Price,
        oi.Qty
    FROM OrderItems oi
    JOIN Products p ON oi.ProductId = p.Id
    JOIN Orders o ON oi.OrderId = o.Id
    JOIN Customers c ON o.CustomerId = c.Id
    WHERE c.Id = @CustomerId;
END;



CREATE VIEW vw_SalesReport AS
SELECT 
    o.Id AS OrderId,
    c.Id AS CustomerId,
    c.Name AS CustomerName,
    p.Id AS ProductId,
    p.Name AS ProductName,
    oi.Price,
    oi.Qty,
    oi.Price * oi.Qty AS TotalPrice
FROM OrderItems AS oi
INNER JOIN Products AS p ON oi.ProductId = p.Id
INNER JOIN Orders AS o ON oi.OrderId = o.Id
INNER JOIN Customers AS c ON o.CustomerId = c.Id;


--  products 
SELECT 
    ProductId,
    ProductName,
    SUM(Qty) AS TotalQty,
    SUM(TotalPrice) AS TotalSales
FROM vw_SalesReport
GROUP BY ProductId, ProductName;


---
SELECT 
    CustomerId,
    CustomerName,
    SUM(Qty) AS TotalItems,
    SUM(TotalPrice) AS TotalPurchase
FROM vw_SalesReport
GROUP BY CustomerId, CustomerName;



SELECT 
    ProductName,
    CustomerName,
    Price,
    Qty,
    TotalPrice
FROM vw_SalesReport
WHERE CustomerId = 1;
