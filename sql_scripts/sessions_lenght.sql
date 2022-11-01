SELECT Users.Name, Users.Country, Sessions.StartSession, Sessions.EndSession, 
timestampdiff(minute, Sessions.StartSession, Sessions.EndSession) AS "Length(Minutes)"
FROM Users, Sessions
WHERE Users.IdUser = Sessions.IdUser
