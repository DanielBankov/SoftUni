CREATE PROC usp_EmployeesBySalaryLevel @levelSalary VARCHAR(10) AS
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelSalary

--EXEC usp_EmployeesBySalaryLevel 'Average'