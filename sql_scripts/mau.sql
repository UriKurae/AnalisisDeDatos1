SELECT count(distinct u.IdUser) AS Users, DATE_FORMAT(s.StartSession, '%Y-%m')  AS month, u.Country    
FROM Users u, Sessions s
WHERE u.IdUser = s.IdUser
GROUP BY MONTH(s.StartSession), u.Country
