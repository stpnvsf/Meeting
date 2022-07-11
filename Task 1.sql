SELECT a.Name, a.Surname, SUM(b.Quantity)as quantity 
FROM Sellers a
INNER JOIN Sales b 
	ON a.ID = b.IDSel
INNER JOIN Arrivals c 
	ON b.ID = c.IDProd
WHERE c.Date >= '20130907' AND c.Date <= '20131007'
GROUP BY b.IDSel, a.Surname, a.Name
ORDER BY a.Surname, a.Name; 


SELECT a.Name, (b.quantity/SUM(c.Quantity))*100, b.Name, b.Surname 
FROM Products a 
INNER JOIN 
(
	SELECT a.Name, a.Surname, SUM(b.Quantity)as Quantity, c.ID 
	FROM Sellers a
	INNER JOIN Sales b 
		ON a.ID = b.IDSel
	INNER JOIN Arrivals c 
		ON b.ID = c.IDProd
	WHERE c.Date >= 01.10.2013 AND c.Date <= 07.10.2013
	GROUP BY b.Quantity
) b
ON b.Id = a.Id
INNER JOIN Sales c
ON c.IDProd = a.Id
WHERE c.Date >= 01.10.2013 AND c.Date <= 07.10.2013
GROUP BY c.Quantity, b.Name, 
ORDER BY a.Name, b.Surname, b.Name;
