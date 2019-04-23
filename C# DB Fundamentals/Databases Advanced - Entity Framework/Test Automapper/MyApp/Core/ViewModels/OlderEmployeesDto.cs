namespace MyApp.Core.Command.ViewModels
{
    using Models;

    public class OlderEmployeesDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public Employee Manager { get; set; }
    }
}