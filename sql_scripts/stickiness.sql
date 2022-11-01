SELECT 
    CONCAT(CAST(DAU/MAU*100 AS DECIMAL(5, 2)),"%") AS Stickiness
FROM
    (SELECT 
        COUNT(DISTINCT s.IdUser) AS dau
    FROM
        Sessions s, Users u
    WHERE
        s.IdUser = u.IdUser
            AND DAY(s.StartSession) = DAY('2022-10-28')
    GROUP BY DAY(s.StartSession)
    ORDER BY s.StartSession ASC) AS Dau,
    (SELECT 
        COUNT(DISTINCT u.IdUser) AS mau
    FROM
        Users u, Sessions s
    WHERE
        u.IdUser = s.IdUser
	AND MONTH(s.StartSession) = MONTH('2022-10-27') GROUP BY MONTH(s.StartSession)) AS Mau

