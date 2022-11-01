SELECT count(distinct IdSession) AS "Sessions", Country
FROM Sessions, Users
WHERE Sessions.IdUser = Users.IdUser
GROUP BY Country 
