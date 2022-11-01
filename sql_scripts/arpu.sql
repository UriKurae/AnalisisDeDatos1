SELECT CAST(SUM(PricePurchases.Price)/count(distinct UsersSessions.IdUser) AS DECIMAL(5, 2)) AS "ARPU", UsersSessions.Country
FROM UsersSessions
LEFT JOIN PricePurchases ON UsersSessions.IdSession = PricePurchases.IdSession
GROUP BY UsersSessions.Country
