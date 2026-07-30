select * from OrderItems



select *from orders

select * from Customers

select * from products




SELECT 
    p.Name AS ProductName,
    oi.Qty,
    oi.Price * oi.Qty AS Price
FROM OrderItems oi
JOIN Products p ON oi.ProductId = p.Id
JOIN Orders o ON oi.OrderId = o.Id
JOIN Customers c ON o.CustomerId = c.Id and c.UserId=1;



select 
p.Name AS ProductName,
    c.Email AS CustomerName,
    oi.Qty,
    p.Price 
from OrderItems  oi 
join products p on oi.Productid=p.Id
join orders o on oi.OrderId=o.Id
join Customers c on o.CustomerId=o.Id and c.UserId>0;



select * from AspNetUsers