SELECT count(distinct u.IdUser) AS Nºusers, Country 
FROM Sessions s
INNER JOIN Users u ON s.IdUser = u.IdUser AND DAY(s.StartSession)= DAY(DATE_ADD(u.DateCreation, INTERVAL 7 DAY))
GROUP BY Country
