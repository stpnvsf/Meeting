SELECT a.Name, a.Surname, SUM(b.Quantity)as quantity 
FROM Sellers a
INNER JOIN Sales b 
	ON a.ID = b.IDSel
INNER JOIN Arrivals c 
	ON b.ID = c.IDProd
WHERE c.Date >= '20130907' AND c.Date <= '20131007'
GROUP BY b.IDSel, a.Surname, a.Name
ORDER BY a.Surname, a.Name; 
