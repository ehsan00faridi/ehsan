SELECT 
    p.Name AS ProductName,
    c.Name AS CustomerName,
    oi.Price,
    oi.Qty,
    oi.Price * oi.Qty AS TotalPrice
FROM OrderItems oi
JOIN Products p ON oi.ProductId = p.Id 
JOIN Orders o ON oi.OrderId = o.Id
JOIN Customers c ON o.CustomerId = c.Id
where c.Id=1


select * from Customers


select * from OrderItems

select * from orders