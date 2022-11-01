SELECT u.Country, count(distinct s.IdUser) AS Nconects, DATE_FORMAT(s.StartSession, '%Y-%m-%d') AS DateDay
FROM Sessions s, Users u 
WHERE s.IdUser = u.IdUser 
GROUP BY DAY(s.StartSession), u.Country ORDER BY s.StartSession ASC;
