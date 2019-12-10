namespace Google
{
    public class Company
    {
        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            if (this.Name == null || this.Department == null || this.Salary == 0) 
            {
                return "";
            }

            return $"{this.Name} {this.Department} {this.Salary:f2}\n";
        }
    }
}
