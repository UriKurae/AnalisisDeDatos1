SELECT CAST(SUM(i.Price)/count(distinct u.IdUser)AS DECIMAL(5, 2)) AS "ARPPU", u.Country
FROM Purchases p, Items i, Sessions s, Users u
WHERE p.IdItem = i.ItemID AND s.IdSession = p.IdSession AND s.IdUser = u.IdUser
GROUP BY u.Country
