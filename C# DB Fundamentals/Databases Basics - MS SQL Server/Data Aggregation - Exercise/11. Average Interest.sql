SELECT DepositGroup, IsDepositExpired, FORMAT(AVG(DepositInterest), 'N2')
FROM WizzardDeposits
WHERE DepositStartDate > '01-01-1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--SELECT * from WizzardDeposits
