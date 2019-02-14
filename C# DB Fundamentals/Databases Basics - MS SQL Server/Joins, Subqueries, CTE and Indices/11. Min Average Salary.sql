SELECT MIN(a.AverageSalary) FROM
(
	SELECT DepartmentID, AVG(Salary) AS [AverageSalary] FROM Employees
	GROUP BY DepartmentID
)  AS a